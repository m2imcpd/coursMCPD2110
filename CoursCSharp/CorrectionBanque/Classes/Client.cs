using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace CorrectionBanque.Classes
{
    public class Client
    {
        private int id;

        private string nom;

        private string prenom;

        private string telephone;

        private static SqlCommand command;

        //private static int compteur = 0;

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Telephone { get => telephone; set => telephone = value; }

        public Client()
        {
            //compteur++;
            //Numero = compteur;
            
        }

        public Client(string n, string p, string t)
        {
            Nom = n;
            Prenom = p;
            Telephone = t;
        }
        //public override string ToString()
        //{
        //    return "Numero : " + Numero + " Nom : " + Nom + " Prénom : " + Prenom + " Téléphone : " + Telephone;
        //}
        //public override string ToString() => "Numero : " + Numero + " Nom : " + Nom + " Prénom : " + Prenom + " Téléphone : " + Telephone;
        public override string ToString() => $"Numero : {Id}  Nom : {Nom} Prénom :  {Prenom}  Téléphone :  {Telephone}";

        public bool Save()
        {
            command = new SqlCommand("INSERT INTO client (nom, prenom, telephone) OUTPUT INSERTED.ID values (@nom, @prenom, @telephone)", Configuration.connection);
            command.Parameters.Add(new SqlParameter("@nom", Nom));
            command.Parameters.Add(new SqlParameter("@prenom", Prenom));
            command.Parameters.Add(new SqlParameter("@telephone", Telephone));
            Configuration.connection.Open();
            Id = (int)command.ExecuteScalar();
            command.Dispose();
            Configuration.connection.Close();
            return Id > 0;
        }

        
    }
}
