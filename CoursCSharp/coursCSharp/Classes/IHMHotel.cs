using System;
using System.Collections.Generic;
using System.Text;

namespace coursCSharp.Classes
{
    public class IHMHotel
    {
        private Hotel hotel;
        public void Start()
        {
            Console.Write("Nom hotel : ");
            string nom = Console.ReadLine();
            hotel = new Hotel(nom);
            string choix;
            do
            {
                MenuHotel();
                choix = Console.ReadLine();
                switch(choix)
                {
                    case "1":
                        AjouterChambre();
                        break;
                    case "2":
                        AjouterClient();
                        break; 
                    case "3":
                        AjouterReservation();
                        break;
                    case "4":
                        ListeChambres();
                        break;
                    case "5":
                        ListeClients();
                        break;
                    case "6":
                        ListeReservations();
                        break;
                }
            } while (choix != "0");
        }

        private void MenuHotel()
        {
            Console.WriteLine("1---Ajouter une chambre");
            Console.WriteLine("2---Ajouter un client");
            Console.WriteLine("3---Ajouter une réservations");
            Console.WriteLine("4---Liste des chambres");
            Console.WriteLine("5---Liste des clients");
            Console.WriteLine("6---Liste des réservations");
        }
        
        private void AjouterChambre()
        {
            Console.Write("N° Chambre : ");
            int numero = Convert.ToInt32(Console.ReadLine());
            Console.Write("Prix de la chambre : ");
            decimal prix = Convert.ToDecimal(Console.ReadLine());
            Chambre chambre = new Chambre() { Numero = numero, Prix = prix };
            hotel.AjouterChambre(chambre);
            Console.WriteLine("Chabmre ajoutée");
        }
        private Client AjouterClient()
        {
            Console.Write("Nom : ");
            string nom = Console.ReadLine();
            Console.Write("Prénom : ");
            string prenom = Console.ReadLine();
            Console.Write("Téléphone : ");
            string telephone = Console.ReadLine();
            Client c = new Client(nom , prenom, telephone);
            hotel.AjouterClient(c);
            Console.WriteLine("Client ajouté");
            return c;
        }
        private void AjouterReservation()
        {
            Reservation reservation = new Reservation();
            Console.Write("Client existe ? (o/n)");
            string c = Console.ReadLine();
            Client client = null;
            if(c == "o")
            {
                ListeClients();
                Console.Write("Numero du client : ");
                int numeroClient = Convert.ToInt32(Console.ReadLine());
                client = hotel.GetClientById(numeroClient);
            }
            else
            {
                client = AjouterClient();
            }
            reservation.Client = client;
            ListeChambres();
            Console.Write("N° de la chambre : ");
            int numeroChambre = Convert.ToInt32(Console.ReadLine());
            Chambre chambre = hotel.GetChambreById(numeroChambre);
            if(chambre.Status == "Libre")
            {
                reservation.Chambre = chambre;
            }
            else
            {
                Console.WriteLine("Chambre non libre");
            }
            reservation.Status = "valide";
            hotel.AjouterReservation(reservation);
            hotel.UpdateChambre(chambre.Numero, "Occupée");
        }
        private void ListeChambres()
        {
            Console.WriteLine("--------Liste chambres--------");
            foreach(Chambre c in hotel.Chambres)
            {
                Console.WriteLine(c);
            }
        }

        private void ListeClients()
        {
            Console.WriteLine("--------Liste clients--------");
            foreach (Client c in hotel.Clients)
            {
                Console.WriteLine(c);
            }
        }

        public void ListeReservations()
        {
            Console.WriteLine("--------Liste reservations--------");
            foreach (Reservation r in hotel.Reservations)
            {
                Console.WriteLine(r);
            }
        }
    }
}
