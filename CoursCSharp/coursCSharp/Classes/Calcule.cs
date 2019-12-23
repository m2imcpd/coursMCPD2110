using System;
using System.Collections.Generic;
using System.Text;

namespace coursCSharp.Classes
{
    public class Calcule
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

        public static double Addition(string message, params int[] parametre)
        {
            Console.WriteLine(message);
            double s = 0;
            foreach(int a in parametre)
            {
                s += a;
            }
            return s;
        }
    }
}
