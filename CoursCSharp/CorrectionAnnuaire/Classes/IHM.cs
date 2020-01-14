using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectionAnnuaire.Classes
{
    public class IHM
    {
        public void Start()
        {
            Console.OutputEncoding = Encoding.UTF8;
            string choix;
            do
            {
                Menu();
                choix = Console.ReadLine();
                Console.Clear();
                switch (choix)
                {
                    case "1":
                        AjouterContact();
                        break;
                    case "2":
                        break;
                    case "3":
                        RechercherContact();
                        break;
                    case "4":
                        SupprimerContact();
                        break;

                }
            } while (choix != "0");
        }

        private void Menu()
        {
            Console.WriteLine("1---Ajouter un contact");
            Console.WriteLine("2---Modifier un contact");
            Console.WriteLine("3---Rechercher un contact");
            Console.WriteLine("4---Supprimer un contact");
        }

        private void AjouterContact()
        {
            Console.Write("Le téléphone du contact ? ");
            string telephone = Console.ReadLine();
            if(Contact.GetContactByTelephone(telephone) != null)
            {
                Console.WriteLine("Numéro de téléphone déjà utilisé");
            }
            else
            {
                Console.Write("Nom du contact ?");
                string nom = Console.ReadLine();
                Console.Write("Prénom du contact ?");
                string prenom = Console.ReadLine();
                Contact contact = new Contact { Nom = nom, Prenom = prenom, Telephone = telephone };
                if(contact.Save())
                {
                    Console.WriteLine("Merci de saisir les emails");
                    string email;
                    do
                    {
                        email = Console.ReadLine();
                        Email e = new Email { Mail = email };
                        if(email != "0" && e.Save(contact.Id))
                        {
                            Console.WriteLine("Mail ajouté");
                        }
                    } while (email != "0");

                    Console.WriteLine("Contact ajouté");
                }
            }
        }

        private void RechercherContact()
        {
            Console.Write("Téléphone contact ? ");
            string telephone = Console.ReadLine();
            Contact contact = Contact.GetContactByTelephone(telephone);
            if(contact == null)
            {
                Console.WriteLine("aucun contact avec ce numéro");
            }
            else
            {
                contact.Emails = Email.GetEmailContact(contact.Id);
                Console.WriteLine(contact);
            }
        }

        private void SupprimerContact()
        {
            Console.Write("Téléphone contact ? ");
            string telephone = Console.ReadLine();
            Contact contact = Contact.GetContactByTelephone(telephone);
            if (contact == null)
            {
                Console.WriteLine("aucun contact avec ce numéro");
            }
            else
            {
               if(contact.Delete())
               {
                    Console.WriteLine("Contact supprimé");
               }
            }
        }
    }
}
