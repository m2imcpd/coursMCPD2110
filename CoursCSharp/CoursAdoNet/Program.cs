using System;
using System.Data.SqlClient;
using System.Text;

namespace CoursAdoNet
{
    class Program
    {
        static SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\coursSql;Integrated Security=True");
        static SqlCommand command;
        static SqlDataReader reader;
        static void Main(string[] args)
        {
            #region cours AdoNet partie 1
            ////Connxion à la base de donnée
            //string connectionString = @"Data Source=(LocalDb)\coursSql;Integrated Security=True";
            //SqlConnection connection = new SqlConnection(connectionString);
            ////string sql = "INSERT INTO client (nom, prenom, dateNaissance) values ('tt','ii','01-01-2001')";
            //Console.Write("Merci de saisir le nom : ");
            //string nom = Console.ReadLine();
            //Console.Write("Merci de saisir le prenom : ");
            //string prenom = Console.ReadLine();
            //Console.Write("Merci de saisir la date de naissance");
            //DateTime dateNaissance;
            //DateTime.TryParse(Console.ReadLine(), out dateNaissance);
            //string sql = "INSERT INTO client (nom, prenom, dateNaissance) OUTPUT INSERTED.ID values (@nom,@prenom,@dateNaissance)";
            ////string sql = "SELECT * FROM client";
            //SqlCommand command = new SqlCommand(sql, connection);
            //command.Parameters.Add(new SqlParameter("@nom", nom));
            //command.Parameters.Add(new SqlParameter("@prenom", prenom));
            //command.Parameters.Add(new SqlParameter("@dateNaissance", dateNaissance));
            //connection.Open();
            ////int nbLigne = command.ExecuteNonQuery();
            //int id = (int)command.ExecuteScalar();
            //Console.WriteLine(id);
            ////SqlDataReader reader = command.ExecuteReader();
            ////while(reader.Read())
            ////{
            ////    Console.WriteLine($"ID {reader.GetInt32(0)}, Nom : {reader.GetString(1)}, Prenom : {reader.GetString(2)}, Date de naissance : {reader.GetDateTime(3)}");
            ////}
            //command.Dispose();
            //connection.Close();
            #endregion
            Console.OutputEncoding = Encoding.UTF8;
            string choix;
            do
            {
                Menu();
                choix = Console.ReadLine();
                Console.Clear();
                switch (choix)
                {
                    case "3":
                        Question3();
                        break;
                    case "4":
                        Question4();
                        break;
                    case "10":
                        Question10();
                        break;
                }
            } while (choix != "0");
            Console.ReadLine();
        }

        static void Menu()
        {
            Console.WriteLine("3--- Question 3");
            Console.WriteLine("4--- Question 4");
            Console.WriteLine("10--- Question 10");
        }

        static void Question3()
        {
            Console.Write("Indiquer le debut du code postal : ");
            string postCode = Console.ReadLine();
            string request = @"SELECT departement_code, departement_nom FROM departement where departement_code like @code";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@code", postCode+"%"));
            connection.Open();
            reader = command.ExecuteReader();
            while(reader.Read())
            {
                Console.WriteLine($"Code departement {reader.GetString(0)}, Nom : {reader.GetString(1)}");
            }
            command.Dispose();
            connection.Close();
        }

        static void Question4()
        {
            Console.Write("Indiquer le nombre de ville : ");
            int nombre = Convert.ToInt32(Console.ReadLine());
            string request = @"SELECT TOP "+nombre+" d.departement_nom, v.ville_nom FROM villes_france_free as v left join departement as d on d.departement_code = v.ville_departement order by v.ville_population_2012 DESC";
            command = new SqlCommand(request, connection);
            //command.Parameters.Add(new SqlParameter("@nombre", nombre));
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"Nom departement {reader.GetString(0)}, ville : {reader.GetString(1)}");
            }
            command.Dispose();
            connection.Close();
        }
        static void Question10()
        {
            Console.Write("Indiquer le nombre de la population : ");
            int nombre = Convert.ToInt32(Console.ReadLine());
            string request = @"SELECT ville_departement, SUM(ville_population_2012) as nombre from villes_france_free "+
                " group by ville_departement "+
                "HAVING SUM(ville_population_2012) >= @nombre "+
                "ORDER BY nombre DESC";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nombre", nombre));
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"code departement {reader.GetString(0)}, Population : {reader.GetInt32(1)}");
            }
            command.Dispose();
            connection.Close();
        }
    }
}