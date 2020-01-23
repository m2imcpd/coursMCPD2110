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
        private Label l;

        
        private bool NewNumber = true;
        private string operation;
        private double resultat;
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
            l = new Label() { Content = "0", VerticalContentAlignment = VerticalAlignment.Center, HorizontalContentAlignment = HorizontalAlignment.Right };
            l.FontSize = 40;
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
                    b.Click += ClickElement;
                    index++;
                    maGrille.Children.Add(b);
                    Grid.SetColumn(b, j);
                    Grid.SetRow(b, i);
                }
            }
        }

        public void ClickElement(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            string valueBouton = b.Content.ToString();
            int nombre;
            if(Int32.TryParse(valueBouton, out nombre))
            {
                if (NewNumber)
                {
                    l.Content = valueBouton;
                    NewNumber = false;
                }
                else
                {
                    l.Content += valueBouton;
                }
            }
            else
            {
                NewNumber = true;
                switch(valueBouton)
                {
                    case "+":
                        if(operation != null)
                        {
                            Calcule(operation);
                        }
                        else
                        {
                            resultat = Convert.ToDouble(l.Content);
                        }
                        operation = "+";
                        break;
                    case "-":
                        if (operation != null)
                        {
                            Calcule(operation);
                        }
                        else
                        {
                            resultat = Convert.ToDouble(l.Content);
                        }
                        operation = "-";
                        break;
                    case "X":
                        if (operation != null)
                        {
                            Calcule(operation);
                        }
                        else
                        {
                            resultat = Convert.ToDouble(l.Content);
                        }
                        operation = "X";
                        break;
                    case "/":
                        if (operation != null)
                        {
                            Calcule(operation);
                        }
                        else
                        {
                            resultat = Convert.ToDouble(l.Content);
                        }
                        operation = "/";
                        break;

                }
            }
               
        }

        private void Calcule(string operation)
        {
            switch(operation)
            {
                case "+":
                    resultat = resultat + Convert.ToDouble(l.Content);
                    l.Content = resultat.ToString(); 
                    break;
                case "-":
                    resultat = resultat - Convert.ToDouble(l.Content);
                    l.Content = resultat.ToString();
                    break;
                case "X":
                    resultat = resultat * Convert.ToDouble(l.Content);
                    l.Content = resultat.ToString();
                    break;
                case "/":
                    resultat = resultat / Convert.ToDouble(l.Content);
                    l.Content = resultat.ToString();
                    break;
            }
        }

    }
}
