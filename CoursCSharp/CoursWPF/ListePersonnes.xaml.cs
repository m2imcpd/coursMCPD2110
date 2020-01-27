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
    /// Logique d'interaction pour ListePersonnes.xaml
    /// </summary>
    public partial class ListePersonnes : Window
    {
        public ListePersonnes()
        {
            InitializeComponent();
        }

        public ListePersonnes(Personne  personne) : this()
        {
            Personne.listes.Add(personne);
            maDataGrid.ItemsSource = Personne.listes;
            //nom.Content = personne.Nom;
            //prenom.Content = personne.Prenom;
        }
    }
}
