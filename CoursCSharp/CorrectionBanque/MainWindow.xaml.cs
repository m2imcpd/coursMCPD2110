using CorrectionBanque.Classes;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CorrectionBanque
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Ajouter_Client(object sender, RoutedEventArgs e)
        {
            Client client = new Client() { Nom = nom.Text, Prenom = prenom.Text, Telephone = telephone.Text };
            if (client.Save())
            {
                Compte compte = new Compte(client);
                if (compte.Save())
                {
                    MessageBox.Show("Client ajouté avec le numéro " + client.Id);
                    nom.Text = "";
                    prenom.Text = "";
                    telephone.Text = "";
                }
                
            }
            else
            {
                MessageBox.Show("Erreur serveur");
            }
        }

        private void Rechercher_Client(object sender, RoutedEventArgs e)
        {
            if(searchById.Text != "")
            {
                Compte compte = SearchCustomerById();
                searchResult.Content = compte.ToString();
                listeOperations.ItemsSource = null;
                listeOperations.ItemsSource = compte.Operations;
            }
            else if(searchByPhone.Text != "")
            {

            }
            else
            {
                MessageBox.Show("Merci de saisir un numéro de client ou de téléphone");
            }
        }

        private Compte SearchCustomerById()
        {
            Compte compte = Compte.SearchByClientId(Convert.ToInt32(searchById.Text));
            return compte;
        }
    }
}
