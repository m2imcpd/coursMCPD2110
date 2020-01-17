using System;
using System.Collections.Generic;
using System.Text;

namespace coursCSharp.Classes
{
    public class De : IDe
    {
        private int valeur;
        public int Valeur => valeur;
        private Random r = new Random();

        public void Lancer()
        {
            valeur = r.Next(1, 7);
        }
    }
}
