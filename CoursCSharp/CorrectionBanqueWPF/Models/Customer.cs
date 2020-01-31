using CorrectionBanqueWPF.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrectionBanqueWPF.Models
{
    public class Customer
    {
        private int id;
        private string firstName;
        private string lastName;
        private string phone;
        private static string request;
        private static SqlCommand command;


        public int Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Phone { get => phone; set => phone = value; }

        public bool Save()
        {
            request = "INSERT INTO customer " +
                "(firstName, lastName, phone) " +
                "OUTPUT INSERTED.ID " +
                "values (@firstname, @lastname, @phone)";
            command = new SqlCommand(request, Configuration.connection);
            command.Parameters.Add(new SqlParameter("@firstname", FirstName));
            command.Parameters.Add(new SqlParameter("@lastname", LastName));
            command.Parameters.Add(new SqlParameter("@phone", Phone));
            Configuration.connection.Open();
            Id = (int)command.ExecuteScalar();
            command.Dispose();
            Configuration.connection.Close();
            return Id > 0;
        }

        public static Customer GetCustomerByPhone(string phone)
        {
            Customer customer = null;
            request = "SELECT id, firstName, lastName " +
                "from customer where phone = @phone";
            command = new SqlCommand(request, Configuration.connection);
            command.Parameters.Add(new SqlParameter("@phone", phone));
            Configuration.connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if(reader.Read())
            {
                customer = new Customer
                {
                    Id = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Phone = phone
                };
            }
            reader.Close();
            command.Dispose();
            Configuration.connection.Close();
            return customer;
        }
    }
}
