using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursWPF.Classes
{
    public class Contact
    {
        private int id;
        private string nom;
        private string prenom;
        private string telephone;
        private static SqlCommand command;
        private static SqlDataReader reader;

        public string Nom { get => nom; set => nom = value; }
        public int Id { get => id; set => id = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Telephone { get => telephone; set => telephone = value; }

        public void Save()
        {
            command = new SqlCommand("INSERT INTO contact (nom, prenom, telephone) OUTPUT INSERTED.ID VALUES(@nom,@prenom,@telephone)", Configuration.connection);
            command.Parameters.Add(new SqlParameter("@nom", Nom));
            command.Parameters.Add(new SqlParameter("@prenom", Prenom));
            command.Parameters.Add(new SqlParameter("@telephone", Telephone));
            Configuration.connection.Open();
            Id = (int)command.ExecuteScalar();
            command.Dispose();
            Configuration.connection.Close();
        }

        public bool Update()
        {
            bool result = false;
            command = new SqlCommand("UPDATE contact  set nom = @nom, prenom= @prenom, telephone = @telephone where id=@id", Configuration.connection);
            command.Parameters.Add(new SqlParameter("@nom", Nom));
            command.Parameters.Add(new SqlParameter("@prenom", Prenom));
            command.Parameters.Add(new SqlParameter("@telephone", Telephone));
            command.Parameters.Add(new SqlParameter("@id", Id));
            Configuration.connection.Open();
            if(command.ExecuteNonQuery() > 0)
            {
                result = true;
            }
            command.Dispose();
            Configuration.connection.Close();
            return result;
        }

        public static List<Contact> GetContacts()
        {
            List<Contact> liste = new List<Contact>();
            command = new SqlCommand("SELECT * FROM contact", Configuration.connection);
            Configuration.connection.Open();
            reader = command.ExecuteReader();
            while(reader.Read())
            {
                Contact c = new Contact
                {
                    Id = reader.GetInt32(0),
                    Nom = reader.GetString(1),
                    Prenom = reader.GetString(2),
                    Telephone = reader.GetString(3)
                };
                liste.Add(c);
            }
            reader.Close();
            command.Dispose();
            Configuration.connection.Close();
            return liste;
        }

        public override string ToString()
        {
            return $"Nom : {Nom}, Prénom : {Prenom}, Telephone : {Telephone}";
        }
    }
}
