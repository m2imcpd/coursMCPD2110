using System;
using System.Collections.Generic;
using System.Text;

namespace coursCSharp.Classes
{
    public class Voiture : Vehicule
    {
        public Voiture() : base()
        {

        }

        public Voiture(int a, decimal p) : base(a, p)
        {

        }

        public void Demarrer()
        {
            Console.WriteLine("Voiture qui demarre");
        }

        public void Accelerer()
        {
            Console.WriteLine("Voiture qui accelere");
        }
    }
}
