using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectionPanier.Classes
{
    public class Panier
    {
        private int id;
        private string nomClient;
        private string telClient;
        private decimal total;
        private List<Produit> produits;

        public int Id { get => id; set => id = value; }
        public string NomClient { get => nomClient; set => nomClient = value; }
        public string TelClient { get => telClient; set => telClient = value; }
        public decimal Total { get => total; set => total = value; }
        public List<Produit> Produits { get => produits; set => produits = value; }

        public Panier()
        {
            Produits = new List<Produit>();
        }
    }
}
