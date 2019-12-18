using System;
using System.Collections.Generic;
using System.Text;

namespace coursCSharp.Classes
{
    public class Salarie : Personne
    {
        public Salarie() : base()
        {

        }

        public Salarie(string n, string p) : base (n,p)
        {

        }

        public void AfficherSalarie()
        {
            Console.WriteLine("Je suis un salarie");
        }
    }
}
