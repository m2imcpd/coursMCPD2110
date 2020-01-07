using System;
using System.Collections.Generic;
using System.Text;

namespace coursCSharp.Classes
{
    public class Voiture : Vehicule
    {
        public event Action<decimal> Promotion;

        public Voiture() : base()
        {

        }

        public Voiture(int a, decimal p) : base(a, p)
        {

        }

        public override void Demarrer()
        {
            Console.WriteLine("Voiture qui demarre");
        }

        public override void Accelerer()
        {
            Console.WriteLine("Voiture qui accelere");
        }

        public void ChangerPrix(decimal newPrice)
        {
            if(newPrice < Prix)
            {
                Promotion?.Invoke(newPrice);
            }
            Prix = newPrice;

        }
    }
}
