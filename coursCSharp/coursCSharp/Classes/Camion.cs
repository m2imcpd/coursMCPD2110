using System;
using System.Collections.Generic;
using System.Text;

namespace coursCSharp.Classes
{
    public class Camion : Vehicule
    {
        public Camion() : base()
        {

        }

        public Camion(int a, decimal p) :base(a,p)
        {

        }
        public void Demarrer()
        {
            Console.WriteLine("Camion qui demarre");
        }

        public void Accelerer()
        {
            Console.WriteLine("Camion qui accelere");
        }
    }
}
