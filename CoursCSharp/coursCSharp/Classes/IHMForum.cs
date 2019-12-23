using System;
using System.Collections.Generic;
using System.Text;

namespace coursCSharp.Classes
{
    public class IHMForum
    {
        private Forum forum;
        public void Start()
        {
            forum = new Forum("Notre forum");
            forum.Moderateur = new Moderateur(forum) { Nom = "abadi", Prenom="Ihab", Age=32};
            string choix;
            do
            {
                MenuInit();
                choix = Console.ReadLine();
                switch(choix)
                {
                    case "1":
                        StartModerateur();
                        break;
                    case "2":
                        StartAbonne();
                        break;
                }
            } while (choix != "0");
        }

        public void MenuInit()
        {
            Console.WriteLine("1---Vous êtes un moderateur");
            Console.WriteLine("2---Vous êtes un abonné");
        }

        public void StartModerateur()
        {

        }

        public void StartAbonne()
        {
            Console.Write("Votre nom ? ");
            Abonne abonne = forum.SearchAbonne(Console.ReadLine());
            if(abonne == null)
            {
                Console.WriteLine("aucun abonné avec ce nom");
            }
            else
            {
                string choix;
                do
                {
                    MenuAbonne();
                    choix = Console.ReadLine();
                    switch (choix)
                    {
                        case "1":
                            AjouterNouvelle(abonne);
                            break;
                        case "2":
                            AfficherNouvelles();
                            RepondreNouvelle(abonne);
                            break;
                        case "3":
                            AfficherNouvelles();
                            break;
                    }
                }while (choix != "0");
            }

        }

        public void MenuAbonne()
        {
            Console.WriteLine("1----Ajouter une nouvelle");
            Console.WriteLine("2----Répondre à une nouvelle");
            Console.WriteLine("3----Afficher les nouvelles");
        }

        public void AjouterNouvelle(Abonne abonne)
        {
            Console.Write("Titre de la nouvelle : ");
            string sujet = Console.ReadLine();
            Console.Write("Texte de la nouvelle : ");
            string texte = Console.ReadLine();
            Nouvelle nouvelle = new Nouvelle() { Sujet = sujet, Texte = texte };
            abonne.AjouterNouvelle(nouvelle);
        }

        public void AfficherNouvelles()
        {
            for(int i = 0; i < forum.Nouvelles.Count; i++)
            {
                Console.WriteLine("Cle : " + i + "Sujet Nouvelle : " + forum.Nouvelles[i].Sujet + " Texte Nouvelle : " + forum.Nouvelles[i].Texte);
            }
        }

        public void RepondreNouvelle(Abonne abonne)
        {
            Console.Write("Répondre à la nouvelle N° : ");
            int cle = Convert.ToInt32(Console.ReadLine());
            Console.Write("Texte de la nouvelle : ");
            string texte = Console.ReadLine();
            Nouvelle n = new Nouvelle() { Sujet = forum.Nouvelles[cle].Sujet, Texte = texte };
            abonne.AjouterNouvelle(n);
        }
        
    }
}
