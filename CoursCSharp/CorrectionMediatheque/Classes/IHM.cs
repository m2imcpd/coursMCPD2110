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
                }
            }while(choix != "0");
        }
        private void Menu()
        {
            Console.WriteLine("1--Ajouter un adherent");
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
    }
}
