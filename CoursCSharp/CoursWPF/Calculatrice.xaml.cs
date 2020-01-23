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

namespace CoursWPF
{
    /// <summary>
    /// Logique d'interaction pour Calculatrice.xaml
    /// </summary>
    public partial class Calculatrice : Window
    {
        private string[] tab = new string[] { "CE", "C", "supprimer", "%", "7", "8", "9", "X", "4", "5", "6", "-", "1", "2", "3", "+", "(+/-)", "0", ",", "=" };
        public Calculatrice()
        {
            InitializeComponent();
            CreateRowsAndCols();
            CreateElements();

        }

        private void CreateRowsAndCols()
        {
            for(int i=0; i < 6; i++)
            {
                maGrille.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                if (i < 4)
                    maGrille.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });              
            }
        }

        private void CreateElements()
        {
            Label l = new Label() { Content = "0", VerticalContentAlignment = VerticalAlignment.Center, HorizontalContentAlignment = HorizontalAlignment.Right };
            maGrille.Children.Add(l);
            Grid.SetColumn(l, 0);
            Grid.SetRow(l, 0);
            Grid.SetColumnSpan(l, 4);
            int index = 0;
            for(int i= 1; i < 6; i++)
            {
                for(int j=0; j < 4; j++)
                {
                    Button b = new Button { Content = tab[index] };
                    index++;
                    maGrille.Children.Add(b);
                    Grid.SetColumn(b, j);
                    Grid.SetRow(b, i);
                }
            }
        }

    }
}
