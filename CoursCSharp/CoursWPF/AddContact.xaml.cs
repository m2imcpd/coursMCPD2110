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
    /// Logique d'interaction pour AddContact.xaml
    /// </summary>
    public partial class AddContact : Window
    {
        private Contact EditContact = null;
        public AddContact()
        {
            InitializeComponent();
        }

        public AddContact(Contact c) : this()
        {
            EditContact = c;
            nom.Text = c.Nom;
            prenom.Text = c.Prenom;
            telephone.Text = c.Telephone;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(EditContact == null)
            {
                Contact c = new Contact { Nom = nom.Text, Prenom = prenom.Text, Telephone = telephone.Text };
                c.Save();
                if (c.Id > 0)
                {
                    MessageBox.Show("Contact ajouté ");
                    ListeContacts window = new ListeContacts();
                    window.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Erreur serveur");
                }
            }
            else
            {
                EditContact.Nom = nom.Text;
                EditContact.Prenom = prenom.Text;
                EditContact.Telephone = prenom.Text;
                if(EditContact.Update())
                {
                    MessageBox.Show("Contact modifé ");
                    ListeContacts window = new ListeContacts();
                    window.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Erreur serveur");
                }
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ListeContacts w = new ListeContacts();
            w.Show();
            Close();
        }
    }
}
