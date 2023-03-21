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
using System.Windows.Shapes;

namespace Finance
{
    public partial class CreateNewType : Window
    {
        public MainWindow parent { get; set; }
        public CreateNewType()
        {
            InitializeComponent();
            TextBoxAddCombo.Text = null;
        }

        private void ComboItemAddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxAddCombo.Text != null)
            {
                parent.ComboboxItemsUpdate(TextBoxAddCombo.Text);
            }
            this.Close();
        }
    }

}
