using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CorrectionPanier.Classes
{
    public class IHM
    {
        public void Start()
        {
            string choix;
            do
            {
                Menu();
                choix = Console.ReadLine();
                Console.Clear();
                switch(choix)
                {
                    case "1":
                        GestionProduit();
                        break;
                }
            } while (choix != "0");
        }

        private void Menu()
        {
            Console.WriteLine("1---Gestion produits");
            Console.WriteLine("2---Gestion paniers");
        }
        private void MenuProduit()
        {
            Console.WriteLine("1---Ajouter un produit");
            Console.WriteLine("2---Supprimer un produit");
            Console.WriteLine("3---Afficher les produits");
            Console.WriteLine("4---sauvegarde");
        }

        private void GestionProduit()
        {
            Produit.Load();
            string choix;
            do
            {
                MenuProduit();
                choix = Console.ReadLine();
                Console.Clear();
                switch (choix)
                {
                    case "1":
                        AjouterProduit();
                        break;
                    case "2":
                        SupprimerProduit();
                        break;
                    case "3":
                        AfficherProduit();
                        break;
                    case "4":
                        Produit.Save();
                        break;
                }
            } while (choix != "0");
        }

        private void AjouterProduit()
        {
            Console.Write("Label du produit : ");
            string label = Console.ReadLine();
            Console.Write("Prix du produit : ");
            decimal prix = Convert.ToDecimal(Console.ReadLine());
            DataRow row = Configuration.DataSet.Tables["produit"].NewRow();
            row["label"] = label;
            row["prix"] = prix;
            Configuration.DataSet.Tables["produit"].Rows.Add(row);
            Console.WriteLine("produit ajouté");
        }

        private void SupprimerProduit()
        {
            Console.Write("Id du produit à supprimer : ");
            int id = Convert.ToInt32(Console.ReadLine());
            foreach(DataRow row in Configuration.DataSet.Tables["produit"].Rows)
            {
                if((int)row["id"] == id)
                {
                    row.Delete();
                }
            }
        }

        private void AfficherProduit()
        {
            Console.WriteLine("----Liste des produits-----");
            foreach (DataRow row in Configuration.DataSet.Tables["produit"].Rows)
            {
                if(row.RowState != DataRowState.Deleted)
                {
                    Console.WriteLine($"Id : {row["id"]}, Label : {row["label"]}, Prix : {row["prix"]}");
                }
            }
        }
    }
}
