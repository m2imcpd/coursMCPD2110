using CorrectionAnnonce.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CorrectionAnnonce.Models
{
    public class Annonce
    {
        private int id;
        private string titre;
        private string description;
        private string image;
        private decimal prix;
        private Categorie categorie;
        private static SqlCommand command;

        public int Id { get => id; set => id = value; }
        public string Titre { get => titre; set => titre = value; }
        public string Description { get => description; set => description = value; }
        public string Image { get => image; set => image = value; }
        public Categorie Categorie { get => categorie; set => categorie = value; }
        public decimal Prix { get => prix; set => prix = value; }

        public bool Save()
        {
            string request = "INSERT INTO annonce " +
                "(titre, description, image, categorie, prix) " +
                "OUTPUT INSERTED.ID " +
                "values (@titre, @description, @image, @categorie, @prix)";
            command = new SqlCommand(request, DataBase.connection);
            command.Parameters.Add(new SqlParameter("@titre", Titre));
            command.Parameters.Add(new SqlParameter("@description", Description));
            command.Parameters.Add(new SqlParameter("@image", Image));
            command.Parameters.Add(new SqlParameter("@categorie", Categorie));
            command.Parameters.Add(new SqlParameter("@prix", prix));
            DataBase.connection.Open();
            Id = (int)command.ExecuteScalar();
            command.Dispose();
            DataBase.connection.Close();
            return Id > 0;
        }

        public static List<Annonce> GetAnnonces(dynamic request)
        {
            List<Annonce> liste = new List<Annonce>();
            string stringRequest = "SELECT * FROM " +
                "annonce " +
                "where categorie = @categorie and titre like @title";
            command = new SqlCommand(stringRequest, DataBase.connection);
            command.Parameters.Add(new SqlParameter("@title", "%"+request.search+"%"));
            Categorie c = (Categorie)request.categorie;
            command.Parameters.Add(new SqlParameter("@categorie", c));
            DataBase.connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                Annonce a = new Annonce
                {
                    Id = reader.GetInt32(0),
                    Titre = reader.GetString(1),
                    Description = reader.GetString(2),
                    Image = reader.GetString(4),
                    Prix = reader.GetDecimal(5),
                    Categorie = c
                };
                liste.Add(a);
            }
            reader.Close();
            command.Dispose();
            DataBase.connection.Close();
            return liste;
        }

        public static Annonce GetAnnonceById(int id)
        {
            Annonce annonce = null;
            string stringRequest = "SELECT * FROM " +
                "annonce " +
                "where id = @id";
            command = new SqlCommand(stringRequest, DataBase.connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            DataBase.connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                annonce = new Annonce
                {
                    Id = reader.GetInt32(0),
                    Titre = reader.GetString(1),
                    Description = reader.GetString(2),
                    Image = reader.GetString(4),
                    Prix = reader.GetDecimal(5),
                    Categorie = (Categorie)reader.GetInt32(3)
                };
                
            }
            reader.Close();
            command.Dispose();
            DataBase.connection.Close();
            return annonce;
        }
    }

    public enum Categorie
    {
        Voiture,
        Téléphone
    }
}
