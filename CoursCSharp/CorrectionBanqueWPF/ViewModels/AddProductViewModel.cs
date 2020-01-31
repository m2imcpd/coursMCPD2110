using CorrectionBanqueWPF.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CorrectionBanqueWPF.ViewModels
{
    public class AddProductViewModel : ViewModelBase
    {
        private Product product;
        private string result;

        public ICommand AddProductCommand { get; set; }
        public string Title
        {
            get => product.Title;
            set => product.Title = value;
        }
        public decimal Price
        {
            get => product.Price;
            set => product.Price = Convert.ToDecimal(value);
        }

        public string Result
        {
            get => result;
        }
        public AddProductViewModel()
        {
            product = new Product();
            AddProductCommand = new RelayCommand(Save);
        }
        public void Save()
        {
            if(product.Save())
            {
                result = "Product Added";
            }
            else
            {
                result = "server Error";
            }
            RaisePropertyChanged("Result");
            //Reset du produit
            product = new Product();
            //Reset des champs
            RaisePropertyChanged("Title");
            RaisePropertyChanged("Price");
        }
    }
}
