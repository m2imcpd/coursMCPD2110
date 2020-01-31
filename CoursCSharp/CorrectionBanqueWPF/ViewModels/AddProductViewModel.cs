using CorrectionBanqueWPF.Models;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrectionBanqueWPF.ViewModels
{
    public class AddProductViewModel : ViewModelBase
    {
        private Product product;
        private string result;
        public string Title
        {
            get => product.Title;
            set => product.Title = value;
        }
        public decimal Price
        {
            get => product.Price;
            set => product.Price = value;
        }

        public string Result
        {
            get => result;
        }
        public AddProductViewModel()
        {
            product = new Product();
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
        }
    }
}
