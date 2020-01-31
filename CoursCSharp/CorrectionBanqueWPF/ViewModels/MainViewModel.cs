using CorrectionBanqueWPF.Models;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrectionBanqueWPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private Customer customer;
        private Product searchProduct;
        private Cart cart;

        public string FirstName
        {
            get => customer.FirstName;
            set => customer.FirstName = value;
        }

        public string LastName
        {
            get => customer.LastName;
            set => customer.LastName = value;
        }

        public string Phone
        {
            get => customer.Phone;
            set => customer.Phone = value;
        }
        //Propriété avec attribut
        public string ResultCustomer { get; set; }
        public string ResultCart { get; set; }
        public string SearchTitle { get; set; }

        public ObservableCollection<Product> SearchProducts { get; set; }
        public Product SearchProduct { get => searchProduct; set => searchProduct = value; }
        public Cart Cart { get => cart; set => cart = value; }
        public decimal Total
        {
            get => Cart.Total;
        }

        public MainViewModel()
        {
            customer = new Customer();
            Cart = new Cart();
            SearchProduct = new Product();
            SearchProducts = new ObservableCollection<Product>();
        }

        public void SaveCustomer()
        {
            Customer tmpCustomer = Customer.GetCustomerByPhone(Phone);
            if (tmpCustomer == null)
            {
                if(customer.Save())
                {
                    ResultCustomer = "Customer Added with id : " + customer.Id;
                }
                else
                {
                    ResultCustomer = "server Error";
                }
            }
            else
            {
                customer = tmpCustomer;
                ResultCustomer = "Customer Already exist with id : " + customer.Id;
            }
            RaisePropertyChanged("ResultCustomer");
        }

        public void GetProducts()
        {
            SearchProducts = Product.GetProductsByTitle(SearchTitle);
            SearchTitle = "";
            RaisePropertyChanged("SearchTitle");
        }

        public void AddProductToCart()
        {
            Cart.AddProductToCart(SearchProduct);
            SearchProduct = null;
            RaisePropertyChanged("SearchProduct");
            RaisePropertyChanged("Total");
        }

        public void SaveCart()
        {
            Cart.Customer = customer;
            if(Cart.Save())
            {
                ResultCart = "Cart Added with Id : " + Cart.Id;
                customer = new Customer();
                Cart = new Cart();
                SearchProduct = new Product();
                SearchProducts = new ObservableCollection<Product>();
            }
            else
            {
                ResultCart = "Server Error";
            }

        }

    }
}
