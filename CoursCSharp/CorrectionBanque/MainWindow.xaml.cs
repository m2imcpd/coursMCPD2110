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
        private Compte compte;
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
                compte = SearchCustomerById();
                searchResult.Content = compte.ToString();
                listeOperations.ItemsSource = null;
                listeOperations.ItemsSource = compte.Operations;
                searchById.Text = "";
            }
            else if(searchByPhone.Text != "")
            {
                compte = SearchCustomerByPhone();
                searchResult.Content = compte.ToString();
                listeOperations.ItemsSource = null;
                listeOperations.ItemsSource = compte.Operations;
                searchByPhone.Text = "";
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
        private Compte SearchCustomerByPhone()
        {
            Compte compte = Compte.SearchByClientPhone(searchByPhone.Text);
            return compte;
        }

        private void Depot_Click(object sender, RoutedEventArgs e)
        {
            Operation windowOperation = new Operation(compte, "depot");
            windowOperation.Show();
        }
        private void Retrait_Click(object sender, RoutedEventArgs e)
        {
            Operation windowOperation = new Operation(compte, "retrait");
            windowOperation.Show();
        }
    }
}
