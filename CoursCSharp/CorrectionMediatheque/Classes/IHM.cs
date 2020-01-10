using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CorrectionMediatheque.Classes
{
    public class IHM
    {
        private Mediatheque mediatheque;

        public IHM()
        {
            mediatheque = new Mediatheque();
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
                        AddAdherent();
                        break;
                    case "2":
                        AddOeuvre();
                        break;
                }
            }while(choix != "0");
        }
        private void Menu()
        {
            Console.WriteLine("1--Ajouter un adherent");
            Console.WriteLine("2--Ajouter une Oeuvre");
            Console.WriteLine("3--Emprunter une Oeuvre");
        }

        private void MenuOeuvre()
        {
            Console.WriteLine("1---Livre");
            Console.WriteLine("2---BD");
            Console.WriteLine("3---DVD");
            Console.WriteLine("4---CD");
        }

        private void AddAdherent()
        {
            Adherent adherent = new Adherent();
            Console.Write("Nom adhérent : ");
            bool error = false;
            do
            {
                try
                {
                    adherent.Nom = Console.ReadLine();
                    error = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    error = true;
                }
            } while(error);
            Console.Write("Le prénom de l'adhérent : ");
            do
            {
                try
                {
                    adherent.Prenom = Console.ReadLine();
                    error = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    error = true;
                }
            } while (error);

            Console.Write("Le numéro de téléphone de l'adherent : ");
            do
            {
                try
                {
                    adherent.Telephone = Console.ReadLine();
                    error = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    error = true;
                }
            } while (error);
            if(mediatheque.Adherents.FirstOrDefault(x=>x.Telephone == adherent.Telephone) == null)
            {
                if (mediatheque.AddAdherent(adherent))
                {
                    Console.WriteLine("Adherent ajouté");
                }
            }
            else
            {
                Console.WriteLine("Adherent existe");
            }
            
        }

        private void AddOeuvre()
        {
            Oeuvre oeuvre;
            Console.Write("Titre de l'oeuvre : ");
            string titre = Console.ReadLine();
            Console.Write("Autheur de l'oeuvre : ");
            string autheur = Console.ReadLine();
            Console.Write("Date de sortie (dd-mm-yyyy): ");
            DateTime dateSortie;
            DateTime.TryParse(Console.ReadLine(), out dateSortie);
            Console.Write("Type de l'oeuvre");
            MenuOeuvre();
            string choix = Console.ReadLine();
            switch(choix)
            {
                case "1":
                    Console.Write("Nombre de page : ");
                    int nombrePage;
                    Int32.TryParse(Console.ReadLine(), out nombrePage);
                    oeuvre = new Livre() { Titre = titre, Autheur= autheur, DateSortie =dateSortie, NombrePage = nombrePage};
                    mediatheque.AddOeuvre(oeuvre);
                    break;
                case "2":
                    Console.Write("Nombre de dessin : ");
                    int nombreDeDessin;
                    Int32.TryParse(Console.ReadLine(), out nombreDeDessin);
                    oeuvre = new BD { Titre = titre, Autheur = autheur, DateSortie = dateSortie, NombreDessin = nombreDeDessin };
                    mediatheque.AddOeuvre(oeuvre);
                    break;
            }
        }
    }
}
