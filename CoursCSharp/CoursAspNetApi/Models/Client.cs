﻿using CoursAspNetApi.Tools;
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
    }
}
