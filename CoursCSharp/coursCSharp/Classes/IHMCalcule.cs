using System;
using System.Collections.Generic;
using System.Text;

namespace coursCSharp.Classes
{
    public class IHMCalcule
    {
        public static void Start(ICalcule<double> calcule)
        {
           Console.WriteLine(calcule.Addition("coucou", 10, 30));
        }
    }
}
