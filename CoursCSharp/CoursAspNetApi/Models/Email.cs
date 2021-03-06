﻿using CoursAspNetApi.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CoursAspNetApi.Models
{
    public class Email
    {
        private int id;
        private string mail;
        private static SqlCommand command;
        private static SqlDataReader reader;

        public int Id { get => id; set => id = value; }
        public string Mail { get => mail; set => mail = value; }

        public override string ToString()
        {
            return $"{Mail}";
        }

        public bool Save(int contactId)
        {
            bool result = false;
            string request = "INSERT INTO email(mail, contact_id) OUTPUT INSERTED.ID values (@mail,@contactid)";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@mail", Mail));
            command.Parameters.Add(new SqlParameter("@contactid", contactId));
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

        public static List<Email> GetEmailContact(int contactId)
        {
            List<Email> liste = new List<Email>();
            string request = "SELECT id, mail FROM email where contact_id = @contactid";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@contactid", contactId));
            DataBase.Connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Email e = new Email { Id = reader.GetInt32(0), Mail = reader.GetString(1) };
                liste.Add(e);
            }
            reader.Dispose();
            command.Dispose();
            DataBase.Connection.Close();
            return liste;
        }

        public void Delete()
        {
            string request = "DELETE FROM email where id=@id";
            command = new SqlCommand(request, DataBase.Connection);
            command.Parameters.Add(new SqlParameter("@id", Id));
            DataBase.Connection.Open();
            command.ExecuteNonQuery();
            command.Dispose();
            DataBase.Connection.Close();
        }
    }
}
