using System;
using System.Collections.Generic;
using System.Text;

namespace coursCSharp.Classes
{
    public class IHMCompte
    {
        private Compte[] comptes;
        private static int cle = 0;

        public IHMCompte()
        {
            comptes = new Compte[100];
        }
        public void Menu()
        {
            Console.WriteLine("1---Ouvrir un compte");
            Console.WriteLine("2---Effectuer un depot");
            Console.WriteLine("3---Effectuer un Retrait");
            Console.WriteLine("4---Liste operations");
        }

        public void Start()
        {
            string choix;
            do
            {
                Menu();
                choix = Console.ReadLine();
                switch(choix)
                {
                    case "1":
                        OuvrirCompte();
                        break;
                    case "2":
                        Depot();
                        break;
                    case "3":
                        Retrait();
                        break;
                    case "4":
                        ListeOperations();
                        break;

                }
            }
            while (choix != "0");
        }


        public void OuvrirCompte()
        {
            Console.Write("Numéro de téléphone du client : ");
            string telephone = Console.ReadLine();
            bool clientExist = false;
            foreach(Compte compte in comptes)
            {
                if(compte != null)
                {
                    if(compte.Client.Telephone == telephone)
                    {
                        clientExist = true;
                        break;
                    }
                }
            }
            if(clientExist)
            {
                Console.WriteLine("Client existe");
            }
            else
            {
                Console.Write("Le nom du client : ");
                string nom = Console.ReadLine();
                Console.Write("Le prénom du client : ");
                string prenom = Console.ReadLine();
                Client client = new Client(nom, prenom, telephone);
                Console.Write("Dépot initial : ");
                decimal depot = Convert.ToDecimal(Console.ReadLine());
                Compte c = new Compte(client, depot);
                comptes[cle] = c;
                cle++;
                Console.WriteLine("Compte crée avec comme numero : " + c.Numero);
            }
        }

        public void Depot()
        {
            Compte compte = RechercherCompte();
            if (compte != null)
            {
                Console.WriteLine(compte);
                Console.Write("Montant du depot : ");
                decimal depot = Convert.ToDecimal(Console.ReadLine());
                compte.Deposer(depot);
                Console.WriteLine(compte);
            }
            else
            {
                Console.WriteLine("Compte n'existe pas");
            }
        }
        
        public void Retrait()
        {
            Compte compte = RechercherCompte();
            if (compte != null)
            {
                Console.WriteLine(compte);
                Console.Write("Montant du retrait : ");
                decimal depot = Convert.ToDecimal(Console.ReadLine());
                if(compte.Retirer(depot))
                {
                    Console.WriteLine(compte);
                }
                else
                {
                    Console.WriteLine("Error solde");
                }
                
            }
            else
            {
                Console.WriteLine("Compte n'existe pas");
            }
        }
        public void ListeOperations()
        {
            Compte compte = RechercherCompte();
            if (compte != null)
            {
                Console.WriteLine(compte);
                foreach(Operation o in compte.Operations)
                {
                    if(o != null)
                    {
                        Console.WriteLine(o);
                    }
                }

            }
            else
            {
                Console.WriteLine("Compte n'existe pas");
            }
        }

        public Compte RechercherCompte()
        {
            Console.Write("Numero de compte : ");
            int numeroCompte = Convert.ToInt32(Console.ReadLine());
            Compte compte = null;
            foreach (Compte c in comptes)
            {
                if (c != null)
                {
                    if (c.Numero == numeroCompte)
                    {
                        compte = c;
                        break;
                    }
                }
            }

            return compte;
        }
    }
}
