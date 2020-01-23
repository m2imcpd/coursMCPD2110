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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CoursWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            maGrille.RowDefinitions.Add(new RowDefinition { Height = new GridLength(100) });
            maGrille.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            maGrille.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Star) });
            maGrille.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            maGrille.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            Button b = new Button { Content = "je suis un bouton" };
            b.Click += B1_Click;
            maGrille.Children.Add(b);
            Grid.SetRow(b, 0);
            Grid.SetColumn(b, 1);
        }

        private void B1_Click(object sender, RoutedEventArgs e)
        {
            Button bClick = sender as Button;
            MessageBox.Show(bClick.Content.ToString());
        }
    }
}
