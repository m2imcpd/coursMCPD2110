using CoursAspNetCore.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursAspNetCore.Models
{
    public class Product
    {
        private int id;
        private string title;
        private decimal price;
        private static string request;
        private static SqlCommand command;

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set {
                if (value.Length > 3)
                    title = value;
                else
                    throw new Exception("Error title");
            }
        }
        public string Price { get => price.ToString(); set  {
                try
                {
                    price = Convert.ToDecimal(value);
                }
                catch(Exception e)
                {
                    throw new Exception("Error price");
                }
                
            }
        }

        public bool Save()
        {
            request = "INSERT INTO " +
                "product (title, price) " +
                "OUTPUT INSERTED.ID values (@title, @price)";
            command = new SqlCommand(request, Configuration.connection);
            command.Parameters.Add(new SqlParameter("@title", Title));
            command.Parameters.Add(new SqlParameter("@price", Price));
            Configuration.connection.Open();
            Id = (int)command.ExecuteScalar();
            command.Dispose();
            Configuration.connection.Close();
            return Id > 0;
        }

        public static ObservableCollection<Product> GetProductsByTitle(string title)
        {
            ObservableCollection<Product> products = new ObservableCollection<Product>();
            request = "SELECT id, title, price " +
                "FROM product " +
                "where title like @title";
            command = new SqlCommand(request, Configuration.connection);
            command.Parameters.Add(new SqlParameter("@title", "%" + title + "%"));
            Configuration.connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                Product p = new Product
                {
                    Id = reader.GetInt32(0),
                    Title = reader.GetString(1),
                    Price = reader.GetString(2)
                };
                products.Add(p);
            }
            reader.Close();
            command.Dispose();
            Configuration.connection.Close();
            return products;
        }

        public static List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            request = "SELECT id, title, price " +
                "FROM product " +
                "order by id desc";
            command = new SqlCommand(request, Configuration.connection);
            Configuration.connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Product p = new Product
                {
                    Id = reader.GetInt32(0),
                    Title = reader.GetString(1),
                    Price = reader.GetDecimal(2).ToString()
                };
                products.Add(p);
            }
            reader.Close();
            command.Dispose();
            Configuration.connection.Close();
            return products;
        }
    }
}
