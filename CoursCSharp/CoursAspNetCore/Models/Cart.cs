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
    public class Cart
    {
        private int id;
        private Customer customer;
        private ObservableCollection<CartProduct> products;
        private decimal total;
        private static string request;
        private static SqlCommand command;
        public int Id { get => id; set => id = value; }
        public Customer Customer { get => customer; set => customer = value; }
        public ObservableCollection<CartProduct> Products { get => products; set => products = value; }
        public decimal Total { get => total; }

        public Cart()
        {
            Products = new ObservableCollection<CartProduct>();
        }

        public void AddProductToCart(Product product)
        {
            bool found = false;
            foreach (CartProduct p in Products)
            {
                if (p.Product.Id == product.Id)
                {
                    found = true;
                    p.Qty++;
                    break;
                }
            }
            if (!found)
            {
                Products.Add(new CartProduct { Product = product, Qty = 1 });
            }
            UpdateTotal();
        }

        public void RemoveProductFromCart(Product product)
        {
            CartProduct productToDelete = null;
            foreach (CartProduct p in Products)
            {
                if (p.Product.Id == product.Id)
                {
                    
                    p.Qty--;
                    if(p.Qty == 0)
                    {
                        productToDelete = p;
                    }
                    break;
                }
            }
            if(productToDelete != null)
            {
                Products.Remove(productToDelete);
            }
            UpdateTotal();
        }

        private void UpdateTotal()
        {
            total = 0;
            foreach(CartProduct p  in Products)
            {
                total += p.Product.Price * p.Qty;
            }
        }

        public bool Save()
        {
            bool result = false;
            if(Customer != null)
            {
                request = "INSERT INTO " +
                    "cart (customerId, total) " +
                    "OUTPUT INSERTED.ID values(@customerId, @total)";
                command = new SqlCommand(request, Configuration.connection);
                command.Parameters.Add(new SqlParameter("@customerId", Customer.Id));
                command.Parameters.Add(new SqlParameter("@total", Total));
                Configuration.connection.Open();
                Id = (int)command.ExecuteScalar();
                command.Dispose();
                if (Id > 0)
                {
                    foreach(CartProduct p in Products)
                    {
                        request = "INSERT INTO " +
                            "CartProduct(CartId, ProductId, Qty) " +
                            "values(@cartId, @productId, @qty)";
                        command = new SqlCommand(request, Configuration.connection);
                        command.Parameters.Add(new SqlParameter("@cartId", Id));
                        command.Parameters.Add(new SqlParameter("@productId", p.Product.Id));
                        command.Parameters.Add(new SqlParameter("@qty", p.Qty));
                        command.ExecuteNonQuery();
                        command.Dispose();
                    }
                    result= true;
                }
                else
                {
                    result= false;
                }
                Configuration.connection.Close();
            }
            return result;
        }

        public static List<Cart> GetAllCarts()
        {
            List<Cart> liste = new List<Cart>();
            request = "SELECT c.id as cartId, c.total," +
                " cu.id as customerId, cu.firstname, cu.lastname" +
                " from cart as c " +
                "inner join customer as cu " +
                "on c.customerId = cu.id";
            command = new SqlCommand(request, Configuration.connection);
            Configuration.connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                Cart c = new Cart
                {
                    Id = reader.GetInt32(0),
                    total = reader.GetDecimal(1),
                    Customer = new Customer
                    {
                        Id = reader.GetInt32(2),
                        FirstName = reader.GetString(3),
                        LastName = reader.GetString(4)
                    }
                };
                liste.Add(c);
            }
            reader.Close();
            command.Dispose();
            Configuration.connection.Close();
            foreach(Cart c in liste)
            {
                c.GetProducts();
            }
            return liste;
        }

        public void GetProducts()
        {
            request = "SELECT cp.qty, p.Id, p.title, p.price " +
                "FROM CartProduct as cp " +
                "inner join product as p " +
                "on p.Id = cp.productId " +
                "where cp.cartId = @cartid";
            command = new SqlCommand(request, Configuration.connection);
            command.Parameters.Add(new SqlParameter("@cartid", Id));
            Configuration.connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                Products.Add(new CartProduct
                {
                    Qty = reader.GetInt32(0),
                    Product = new Product
                    {
                        Id = reader.GetInt32(1),
                        Title = reader.GetString(2),
                        Price = reader.GetDecimal(3)
                    }
                });
            }
            reader.Close();
            command.Dispose();
            Configuration.connection.Close();
        }

        public static Cart GetCartById(int id)
        {
            Cart cart = null;
            request = "SELECT c.id as cartId, c.total," +
                " cu.id as customerId, cu.firstname, cu.lastname" +
                " from cart as c " +
                "inner join customer as cu " +
                "on c.customerId = cu.id where c.id = @id";
            command = new SqlCommand(request, Configuration.connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            Configuration.connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if(reader.Read())
            {
                cart = new Cart
                {
                    Id = reader.GetInt32(0),
                    total = reader.GetDecimal(1),
                    Customer = new Customer
                    {
                        Id = reader.GetInt32(2),
                        FirstName = reader.GetString(3),
                        LastName = reader.GetString(4)
                    }
                };   
            }
            reader.Close();
            command.Dispose();
            Configuration.connection.Close();
            cart?.GetProducts();
            return cart;
        }
    }
}
