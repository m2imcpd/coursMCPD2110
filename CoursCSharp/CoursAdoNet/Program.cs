using System;
using System.Data.SqlClient;

namespace CoursAdoNet
{
    class Program
    {
        static void Main(string[] args)
        {
            //Connxion à la base de donnée
            string connectionString = @"Data Source=(LocalDb)\coursSql;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            //string sql = "INSERT INTO client (nom, prenom, dateNaissance) values ('tt','ii','01-01-2001')";
            Console.Write("Merci de saisir le nom : ");
            string nom = Console.ReadLine();
            Console.Write("Merci de saisir le prenom : ");
            string prenom = Console.ReadLine();
            Console.Write("Merci de saisir la date de naissance");
            DateTime dateNaissance;
            DateTime.TryParse(Console.ReadLine(), out dateNaissance);
            string sql = "INSERT INTO client (nom, prenom, dateNaissance) OUTPUT INSERTED.ID values (@nom,@prenom,@dateNaissance)";
            //string sql = "SELECT * FROM client";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.Add(new SqlParameter("@nom", nom));
            command.Parameters.Add(new SqlParameter("@prenom", prenom));
            command.Parameters.Add(new SqlParameter("@dateNaissance", dateNaissance));
            connection.Open();
            //int nbLigne = command.ExecuteNonQuery();
            int id = (int)command.ExecuteScalar();
            Console.WriteLine(id);
            //SqlDataReader reader = command.ExecuteReader();
            //while(reader.Read())
            //{
            //    Console.WriteLine($"ID {reader.GetInt32(0)}, Nom : {reader.GetString(1)}, Prenom : {reader.GetString(2)}, Date de naissance : {reader.GetDateTime(3)}");
            //}
            command.Dispose();
            connection.Close();
            Console.ReadLine();
        }
    }
}