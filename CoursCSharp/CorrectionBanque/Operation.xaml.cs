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
using System.Windows.Shapes;

namespace CorrectionBanque
{
    /// <summary>
    /// Logique d'interaction pour Operation.xaml
    /// </summary>
    public partial class Operation : Window
    {
        private Compte compte;
        private string typeOperation;
        private Operation()
        {
            InitializeComponent();
        }

        public Operation(Compte c, string t) : this()
        {
            compte = c;
            typeOperation = t;
            infoCompte.Content = c.ToString();
            type.Content = t;
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            if(typeOperation == "depot")
            {
                compte.Deposer(Convert.ToDecimal(montant.Text));
                MessageBox.Show("Depot effectué");
            }
            else if(typeOperation == "retrait")
            {
                if(compte.Retirer(Convert.ToDecimal(montant.Text)))
                {
                    MessageBox.Show("Retrait effectué");
                }
                else
                {
                    MessageBox.Show("erreur retrait");
                }
            }
        }
    }
}
