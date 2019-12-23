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
            Console.Write("Votre nom ? ");
            string nom = Console.ReadLine();
            if(forum.Moderateur.Nom == nom)
            {
                string choix;
                do
                {
                    MenuModerateur();
                    choix = Console.ReadLine();
                    ActionAbonne(choix, forum.Moderateur);
                    ActionModerateur(choix);
                } while (choix != "0");

            }
            else
            {
                Console.WriteLine("Erreur moderateur");
            }
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
                    ActionAbonne(choix, abonne);
                    
                    
                }while (choix != "0");
            }

        }

        public void ActionAbonne(string choix, Abonne abonne)
        {
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
        }

        public void MenuAbonne()
        {
            Console.WriteLine("1----Ajouter une nouvelle");
            Console.WriteLine("2----Répondre à une nouvelle");
            Console.WriteLine("3----Afficher les nouvelles");
        }

        public void MenuModerateur()
        {
            MenuAbonne();
            Console.WriteLine("4----Supprimer une nouvelle");
            Console.WriteLine("5----Ajouter un abonné");
            Console.WriteLine("6----Afficher les abonnés");
            Console.WriteLine("7----Supprimer un abonné");
        }

        public void ActionModerateur(string choix)
        {
            switch(choix)
            {
                case "4":
                    SupprimerUneNouvelle();
                    break;
                case "5":
                    AjouterAbonne();
                    break;
                case "6":
                    AfficherAbonnes();
                    break;
                case "7":
                    SupprimerAbonne();
                    break;
            }
        }

        public void SupprimerUneNouvelle()
        {
            AfficherNouvelles();
            Console.Write("La clé de l'abonné à supprimer :");
            int cle = Convert.ToInt32(Console.ReadLine());
            forum.Nouvelles.RemoveAt(cle);
        }
        public void AjouterAbonne()
        {
            Console.Write("Le nom de l'abonné : ");
            string nom = Console.ReadLine();
            Abonne abonne = forum.SearchAbonne(nom);
            if(abonne == null)
            {
                Console.Write("Le prénom de l'abonné : ");
                string prenom = Console.ReadLine();
                Console.Write("L'age de l'abonné : ");
                int age = Convert.ToInt32(Console.ReadLine());
                Abonne a = new Abonne(forum) { Nom = nom, Prenom = prenom, Age = age };
                forum.Abonnes.Add(a);
                Console.WriteLine("Abonné correctement ajouté");
            }
            else
            {
                Console.WriteLine("Abonne existe deja");
            }
        }

        public void AfficherAbonnes()
        {
            for(int i = 0; i < forum.Abonnes.Count; i++)
            {
                Console.WriteLine("Cle : " + i + " Abonne : " + forum.Abonnes[i]);
            }
        }

        public void SupprimerAbonne()
        {
            AfficherAbonnes();
            Console.Write("La clé de l'abonné à supprimer :");
            int cle = Convert.ToInt32(Console.ReadLine());
            forum.Abonnes.RemoveAt(cle);
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
