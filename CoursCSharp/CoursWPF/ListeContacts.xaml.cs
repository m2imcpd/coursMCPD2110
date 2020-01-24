using CoursWPF.Classes;
using System;
using System.Collections.Generic;
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

namespace CoursWPF
{
    /// <summary>
    /// Logique d'interaction pour ListeContacts.xaml
    /// </summary>
    public partial class ListeContacts : Window
    {
        public ListeContacts()
        {
            InitializeComponent();
            listeContacts.ItemsSource = Contact.GetContacts();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Contact c = (Contact)listeContacts.SelectedItem;
            //MessageBox.Show(c.Id.ToString());
            AddContact w = new AddContact(c);
            w.Show();
            Close();
        }
    }
}
