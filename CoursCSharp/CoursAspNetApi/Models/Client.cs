using CoursAspNetApi.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CoursAspNetApi.Models
{
    public class Client
    {
        private int id;
        private string nom;
        private string prenom;
        private string telephone;
        private static SqlCommand command;
        private static SqlDataReader reader;
        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Telephone { get => telephone; set => telephone = value; }

        public bool Save()
        {
            command = new SqlCommand("INSERT INTO client (nom, prenom, telephone) OUTPUT INSERTED.ID values (@nom, @prenom, @telephone)", DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@nom", Nom));
            command.Parameters.Add(new SqlParameter("@prenom", Prenom));
            command.Parameters.Add(new SqlParameter("@telephone", Telephone));
            DataBase.Connection.Open();
            Id = (int)command.ExecuteScalar();
            command.Dispose();
            DataBase.Connection.Close();
            return Id > 0;
        }

        public bool Update()
        {
            command = new SqlCommand("update client set nom=@nom, prenom = @prenom, telephone = @telephone where id = @id", DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@nom", Nom));
            command.Parameters.Add(new SqlParameter("@prenom", Prenom));
            command.Parameters.Add(new SqlParameter("@telephone", Telephone));
            command.Parameters.Add(new SqlParameter("@id", Id));
            DataBase.Connection.Open();
            int nombreLigne = command.ExecuteNonQuery();
            command.Dispose();
            DataBase.Connection.Close();
            return nombreLigne > 0;
        }

        public static List<Client> GetClients()
        {
            List<Client> liste = new List<Client>();
            string request = "SELECT * FROM client";
            command = new SqlCommand(request, DataBase.Connection);
            DataBase.Connection.Open();
            reader = command.ExecuteReader();
            while(reader.Read())
            {
                Client c = new Client
                {
                    Id = reader.GetInt32(0),
                    Nom = reader.GetString(1),
                    Prenom = reader.GetString(2),
                    Telephone = reader.GetString(3),
                };
                liste.Add(c);
            }
            reader.Close();
            command.Dispose();
            DataBase.Connection.Close();
            return liste;
        }

        public static List<Client> GetClientByName(string nom)
        {
            List<Client> liste = new List<Client>();
            string request = "SELECT * FROM client where nom like @nom";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@nom", "%" + nom + "%"));
            DataBase.Connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Client c = new Client
                {
                    Id = reader.GetInt32(0),
                    Nom = reader.GetString(1),
                    Prenom = reader.GetString(2),
                    Telephone = reader.GetString(3),
                };
                liste.Add(c);
            }
            reader.Close();
            command.Dispose();
            DataBase.Connection.Close();
            return liste;
        }

        public static Client GetClientById(int id)
        {
            Client client = null;
            string request = "SELECT * FROM client where id=@id";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            DataBase.Connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                client = new Client
                {
                    Id = reader.GetInt32(0),
                    Nom = reader.GetString(1),
                    Prenom = reader.GetString(2),
                    Telephone = reader.GetString(3),
                };
               
            }
            reader.Close();
            command.Dispose();
            DataBase.Connection.Close();
            return client;
        }
    }
}
