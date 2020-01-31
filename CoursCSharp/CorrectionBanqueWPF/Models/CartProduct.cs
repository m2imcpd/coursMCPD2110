using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrectionBanqueWPF.Models
{
    public class CartProduct
    {
        private Product product;

        private int qty;

        public int Qty { get => qty; set => qty = value; }
        public Product Product { get => product; set => product = value; }

        public CartProduct()
        {
            Product = new Product();
        }
    }
}
