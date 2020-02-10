using CoursAspNetApi.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CoursAspNetApi.Models
{
    public class Contact
    {
        private int id;
        private string nom;
        private string prenom;
        private string telephone;
        private List<Email> emails;
        private static SqlCommand command;
        private static SqlDataReader reader;

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public List<Email> Emails { get => emails; set => emails = value; }

        public Contact()
        {
            Emails = new List<Email>();
        }

        public static Contact GetContactByTelephone(string phone)
        {
            Contact contact = null;
            string request = "SELECT TOP 1 id, nom, prenom FROM contact where telephone = @telephone";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@telephone", phone));
            DataBase.Connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                contact = new Contact()
                {
                    Id = reader.GetInt32(0),
                    Nom = reader.GetString(1),
                    Prenom = reader.GetString(2),
                    Telephone = phone
                };
            }
            reader.Dispose();
            command.Dispose();
            DataBase.Connection.Close();
            return contact;
        }

        public static List<Contact> GetContacts()
        {
            List<Contact> contacts = new List<Contact>();
            string request = "SELECT id, nom, prenom, telephone FROM contact";
            command = new SqlCommand(request, DataBase.Connection);
            DataBase.Connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Contact contact = new Contact()
                {
                    Id = reader.GetInt32(0),
                    Nom = reader.GetString(1),
                    Prenom = reader.GetString(2),
                    Telephone = reader.GetString(3),
                    //Emails = Email.GetEmailContact(reader.GetInt32(0))
                };
                contacts.Add(contact);
            }
            reader.Dispose();
            command.Dispose();
            DataBase.Connection.Close();
            return contacts;
        }

        public bool Save()
        {
            bool result = false;
            string request = "INSERT INTO contact(nom, prenom, telephone) OUTPUT INSERTED.ID" +
                " values (@nom, @prenom, @telephone)";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@nom", Nom));
            command.Parameters.Add(new SqlParameter("@prenom", Prenom));
            command.Parameters.Add(new SqlParameter("@telephone", Telephone));
            DataBase.Connection.Open();
            Id = (int)command.ExecuteScalar();
            if (Id > 0)
            {
                result = true;
            }
            command.Dispose();
            DataBase.Connection.Close();
            return result;
        }

        public bool Update()
        {
            bool result = false;
            string request = "UPDATE contact set nom=@nom, prenom=@prenom, telephone=@telephone where id=@id";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@nom", Nom));
            command.Parameters.Add(new SqlParameter("@prenom", Prenom));
            command.Parameters.Add(new SqlParameter("@telephone", Telephone));
            command.Parameters.Add(new SqlParameter("@id", Id));
            DataBase.Connection.Open();
            if (command.ExecuteNonQuery() > 0)
            {
                result = true;
            }
            command.Dispose();
            DataBase.Connection.Close();
            return result;
        }

        public bool Delete()
        {
            bool result = false;
            string request = "DELETE FROM contact where id=@id";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@id", Id));
            DataBase.Connection.Open();
            if (command.ExecuteNonQuery() > 0)
            {
                result = true;
            }
            command.Dispose();
            DataBase.Connection.Close();
            return result;
        }
        public override string ToString()
        {
            string retour = $"Id : {Id}, Nom : {Nom}, Prenom : {Prenom}, Téléphone : {Telephone} \n";
            foreach (Email e in Emails)
            {
                retour += e.ToString() + "\n";
            }
            return retour;
        }
    }
}
