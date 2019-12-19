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
        public override void Demarrer()
        {
            Console.WriteLine("Camion qui demarre");
        }

        public override void Accelerer()
        {
            Console.WriteLine("Camion qui accelere");
        }
    }
}
