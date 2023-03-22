using MaterialDesignThemes.Wpf;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Finance
{
    public partial class MainWindow : Window
    {
        BindingList<Note> notes = new BindingList<Note>();

        public MainWindow()
        {
            string About_notes = File.ReadAllText("Notes.json");
            notes = JsonConvert.DeserializeObject<BindingList<Note>>(About_notes);
            InitializeComponent();
            ComboboxItemsUpdate();
            Date.SelectedDate = DateTime.Now;
            UpdateInfo();
        }

        private void createNewType_Click(object sender, RoutedEventArgs e)
        {
            CreateNewType createNewType = new CreateNewType();
            createNewType.parent = this;
            createNewType.Show();
        }

        public void ComboboxItemsUpdate(string item = null)
        {
            string About_items = File.ReadAllText("About_items.json");
            List<string> items = JsonConvert.DeserializeObject<List<string>>(About_items);
           
            if (item != null) { items.Add(item); }

            typeOfNotes.Items.Clear();
            for (int i = 0; i < items.Count; i++)
            {
                typeOfNotes.Items.Add(items[i]);
            }

            string json = JsonConvert.SerializeObject(items);
            File.WriteAllText("About_items.json", json);
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            foreach (Note note in notes)
            {
                if (note == notesList.SelectedItem)
                {
                    note.Money = Convert.ToDouble(Money.Text);
                    note.Name = createNewNote.Text;
                    note.Type = typeOfNotes.Text;
                    break;
                }
            }
            UpdateInfo();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Note note = new Note(createNewNote.Text, typeOfNotes.Text, Convert.ToDouble(Money.Text), Date.SelectedDate.Value, false);
                notes.Add(note);
            }
            catch (Exception) { }
            UpdateInfo();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            foreach (Note note in notes)
            {
                if (note == notesList.SelectedItem)
                {
                    notes.Remove(note);
                    break;
                }
            }
            UpdateInfo();
        }

        private void UpdateInfo()
        {
            BindingList<Note> FoundNotes = new BindingList<Note>();
            foreach (Note note in notes)
            {
                if (note.date == Date.SelectedDate)
                {
                    FoundNotes.Add(note);
                }

                if (note.Money > 0)
                {
                    note.isIncrease = true;
                }
                else
                {
                    note.isIncrease = false;
                }

                notesList.ItemsSource = FoundNotes;
            }
            double balance = 0;

            foreach (Note note in notes)
            {
                balance += note.Money;
            }
            Balance.Text = "Итог: " + balance;

            string json = JsonConvert.SerializeObject(notes);
            File.WriteAllText("Notes.json", json);
        }

        private void notesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Note note in notes)
            {
                if (note == notesList.SelectedItem)
                {
                    Money.Text = Convert.ToString(note.Money);
                    createNewNote.Text = Convert.ToString(note.Name);
                    typeOfNotes.SelectedItem = Convert.ToString(note.Type);
                }
            }
        }

        private void Date_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateInfo();
        }
    }
}
