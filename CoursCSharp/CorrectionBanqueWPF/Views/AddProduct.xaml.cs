using CorrectionBanqueWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CorrectionBanqueWPF.Views
{
    /// <summary>
    /// Logique d'interaction pour AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        public AddProduct()
        {
            InitializeComponent();
            DataContext = new AddProductViewModel();
        }

        //private void SaveProduct_Click(object sender, RoutedEventArgs e)
        //{
        //    AddProductViewModel v = DataContext as AddProductViewModel;
        //    v.Save();
        //}
    }
}
