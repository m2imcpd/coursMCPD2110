using System;
using System.Collections.Generic;
using System.Text;

namespace coursCSharp.Classes
{
    public class Calcule : ICalcule<double>
    {
        //public static void UpdateVariable(ref int a)
        //{
        //    a = a * 2;
        //    Console.WriteLine(a);
        //}

        //public static void UpdateVariable(out int a)
        //{
        //    a = 10;
        //    a = a * 2;
        //    Console.WriteLine(a);
        //}

        //public static void UpdateString(string[] test)
        //{
        //    test[0] = "Test";
        //    Console.WriteLine(test[0]);
        //}

        //public static double Addition(int a, int b)
        //{
        //    return a + b;
        //}
        //public static double Addition(int a, int b, int c)
        //{
        //    return a + b + c;
        //}
        public delegate double Operation(double a, double b);
        private Operation monOperation;

        public Operation MonOperation { get => monOperation; set => monOperation = value; }

        public double Addition(string message, params int[] parametre)
        {
            Console.WriteLine(message);
            double s = 0;
            foreach(int a in parametre)
            {
                s += a;
            }
            return s;
        }

        public double Soustraction(string message, params int[] parametre)
        {
            Console.WriteLine(message);
            double s = (parametre.Length > 0) ? parametre[0] : 0;
            for(int i = 1; i < parametre.Length; i++)
            {
                s -= parametre[i];
            }
            return s;
        }
        public static double Addition(double a, double b)
        {
            Console.WriteLine(a + b);
            return a + b;
        }

        public static double Souctraction(double a, double b)
        {
            return a - b;
        }
        public static double Calculatrice(double a, double b, Func<double, double, double> operation)
        {
            return operation(a, b);
        }

        public void Calculatrice(double a, double b)
        {
            Console.WriteLine(MonOperation(a, b)); 
        }

    }
}
