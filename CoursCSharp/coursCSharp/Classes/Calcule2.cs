using System;
using System.Collections.Generic;
using System.Text;

namespace coursCSharp.Classes
{
    public class Calcule2 : ICalcule<double>
    {
        public double Addition(string message, params int[] parametre)
        {
            Console.WriteLine("Calcule 2 "+message);
            double s = 0;
            foreach (int a in parametre)
            {
                s += a;
            }
            return s;
        }

        public double Soustraction(string message, params int[] parametre)
        {
            Console.WriteLine("Calcule 2 "+message);
            double s = (parametre.Length > 0) ? parametre[0] : 0;
            for (int i = 1; i < parametre.Length; i++)
            {
                s -= parametre[i];
            }
            return s;
        }
    }
}
