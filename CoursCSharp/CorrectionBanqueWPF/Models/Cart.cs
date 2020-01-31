using CorrectionBanqueWPF.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrectionBanqueWPF.Models
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
                    "OUTPUT INSERTED.ID (@customerId, @total)";
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
    }
}
