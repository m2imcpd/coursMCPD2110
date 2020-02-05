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
        private string urlImage;
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

        public string UrlImage { get => urlImage; set => urlImage = value; }

        public bool Save()
        {
            request = "INSERT INTO " +
                "product (title, price, urlImage) " +
                "OUTPUT INSERTED.ID values (@title, @price, @urlImage)";
            command = new SqlCommand(request, Configuration.connection);
            command.Parameters.Add(new SqlParameter("@title", Title));
            command.Parameters.Add(new SqlParameter("@price", Price));
            command.Parameters.Add(new SqlParameter("@urlImage", urlImage));
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
            request = "SELECT id, title, price, urlImage " +
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
                try
                {
                    p.UrlImage = reader.GetString(3);
                }catch(Exception e)
                {
                    p.UrlImage = "images/default.png";
                }
                products.Add(p);
            }
            reader.Close();
            command.Dispose();
            Configuration.connection.Close();
            return products;
        }
        public static Product GetProductById(int id)
        {
            Product p = null;
            request = "SELECT id, title, price, urlImage " +
                "FROM product " +
                "where id = @id";
            command = new SqlCommand(request, Configuration.connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            Configuration.connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                p = new Product
                {
                    Id = reader.GetInt32(0),
                    Title = reader.GetString(1),
                    Price = reader.GetDecimal(2).ToString()
                };
                try
                {
                    p.UrlImage = reader.GetString(3);
                }
                catch (Exception e)
                {
                    p.UrlImage = "images/default.png";
                }
                
            }
            reader.Close();
            command.Dispose();
            Configuration.connection.Close();
            return p;
        }
    }
}
