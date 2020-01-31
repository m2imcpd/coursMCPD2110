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
    /// Logique d'interaction pour Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddProduct w = new AddProduct();
            w.Show();
        }

        private void SaveCustomer_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel v = DataContext as MainViewModel;
            v.SaveCustomer();
        }

        private void SearchProducts_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel v = DataContext as MainViewModel;
            v.GetProducts();
        }

        private void AddProductToCart_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel v = DataContext as MainViewModel;
            v.AddProductToCart();
        }

        private void SaveCart_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel v = DataContext as MainViewModel;
            v.SaveCart();
        }
    }
}
