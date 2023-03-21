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
        private BindingList<Note> notes = new BindingList<Note>();

        public MainWindow()
        {
            InitializeComponent();
            ComboboxItemsUpdate();
            Date.DisplayDateStart = DateTime.Now;
            notes.Add(new Note("fdsff", "fsfsdf", 11000, true));
            notesList.ItemsSource = notes;
        }

        private void createNewType_Click(object sender, RoutedEventArgs e)
        {
            CreateNewType createNewType = new CreateNewType();
            createNewType.parent = this;
            createNewType.Show();
        }

        public void ComboboxItemsUpdate(string item = null)
        {
            string About_items = File.ReadAllText("C://Users//futbo//OneDrive//Рабочий стол//Dairy//About_items.json");
            List<string> items = JsonConvert.DeserializeObject<List<string>>(About_items);
            if (item != null) { items.Add(item); }

            typeOfNotes.Items.Clear();
            for (int i = 0; i < items.Count; i++)
            {
                typeOfNotes.Items.Add(items[i]);
            }

            string json = JsonConvert.SerializeObject(items);
            File.WriteAllText("C://Users//futbo//OneDrive//Рабочий стол//Dairy//About_items.json", json);
        }
    }
}
