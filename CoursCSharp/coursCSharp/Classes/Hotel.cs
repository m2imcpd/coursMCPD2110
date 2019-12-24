using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace coursCSharp.Classes
{
    public class Hotel
    {
        private string nom;
        private List<Chambre> chambres;
        private List<Client> clients;
        private List<Reservation> reservations;

        public string Nom { get => nom; set => nom = value; }
        public List<Chambre> Chambres { get => chambres; set => chambres = value; }
        public List<Client> Clients { get => clients; set => clients = value; }
        public List<Reservation> Reservations { get => reservations; set => reservations = value; }

        public Hotel()
        {

        }

        public Hotel(string n)
        {
            Nom = n;
            if(File.Exists(Nom + "-clients.json"))
            {
                LireClientsJson();
            }
            else
            {
                Clients = new List<Client>();
            }
            if (File.Exists(Nom + "-reservations.json"))
            {
                LireReservationsJson();
            }
            else
            {
                Reservations = new List<Reservation>();
            }
            if (File.Exists(Nom + "-chambres.json"))
            {
                LireChambresJson();
            }
            else
            {
                Chambres = new List<Chambre>();
            }
        }

        private void LireClientsJson()
        {
            StreamReader reader = new StreamReader(File.Open(Nom + "-clients.json", FileMode.Open));
            Clients = JsonConvert.DeserializeObject<List<Client>>(reader.ReadToEnd());
            reader.Dispose();
        }
        private void LireReservationsJson()
        {
            StreamReader reader = new StreamReader(File.Open(Nom + "-reservations.json", FileMode.Open));
            Reservations = JsonConvert.DeserializeObject<List<Reservation>>(reader.ReadToEnd());
            reader.Dispose();
        }
        private void LireChambresJson()
        {
            StreamReader reader = new StreamReader(File.Open(Nom + "-chambres.json", FileMode.Open));
            Chambres = JsonConvert.DeserializeObject<List<Chambre>>(reader.ReadToEnd());
            reader.Dispose();
        }

        private void SauvegardeClients()
        {
            StreamWriter writer = new StreamWriter(File.Open(Nom + "-clients.json", FileMode.Create));
            writer.WriteLine(JsonConvert.SerializeObject(Clients));
            writer.Dispose();
        }
        private void SauvegardeChambres()
        {
            StreamWriter writer = new StreamWriter(File.Open(Nom + "-chambres.json", FileMode.Create));
            writer.WriteLine(JsonConvert.SerializeObject(Chambres));
            writer.Dispose();
        }
        private void SauvegardeReservations()
        {
            StreamWriter writer = new StreamWriter(File.Open(Nom + "-reservations.json", FileMode.Create));
            writer.WriteLine(JsonConvert.SerializeObject(Reservations));
            writer.Dispose();
        }

        public void AjouterClient(Client c)
        {
            Clients.Add(c);
            SauvegardeClients();
        }

        public void AjouterChambre(Chambre c)
        {
            Chambres.Add(c);
            SauvegardeChambres();
        }

        public void AjouterReservation(Reservation r)
        {
            Reservations.Add(r);
            SauvegardeReservations();
        }

        public Client GetClientById(int numero)
        {
            Client client = null;
            foreach(Client c in Clients)
            {
                if(c.Numero == numero)
                {
                    client = c;
                    break;
                }
            }
            return client;
        }

        public Chambre GetChambreById(int numero)
        {
            Chambre chambre = null;
            foreach (Chambre c in Chambres)
            {
                if (c.Numero == numero)
                {
                    chambre = c;
                    break;
                }
            }
            return chambre;
        }

        public void UpdateChambre(int numero, string status)
        {
            foreach (Chambre c in Chambres)
            {
                if (c.Numero == numero)
                {
                    c.Status = status;
                    break;
                }
            }
            SauvegardeChambres();
        }

    }
}
