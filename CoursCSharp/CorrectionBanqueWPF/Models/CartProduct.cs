using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrectionBanqueWPF.Models
{
    public class CartProduct : INotifyPropertyChanged
    {
        private Product product;

        private int qty;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Qty { get => qty; set
            {
                qty = value;
                NotifyProperty("Qty");
            }
        }
        public Product Product { get => product; set => product = value; }

        public CartProduct()
        {
            Product = new Product();
        }

        private void NotifyProperty(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
