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
    /// Logique d'interaction pour AddPersonne.xaml
    /// </summary>
    public partial class AddPersonne : Window
    {
        public AddPersonne()
        {
            InitializeComponent();
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            Personne p = new Personne() { Nom = firstName.Text, Prenom = lastName.Text };

            ListePersonnes window = new ListePersonnes(p);
            window.Show();
            Close();
            //MessageBox.Show(firstName.Text + " " + lastName.Text);
        }
    }
}
