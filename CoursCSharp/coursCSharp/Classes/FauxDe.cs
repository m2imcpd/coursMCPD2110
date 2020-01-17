using System;
using System.Collections.Generic;
using System.Text;

namespace coursCSharp.Classes
{
    public class FauxDe : IDe
    {
        private int valeur;
        public int Valeur => valeur;

        public FauxDe(int v)
        {
            valeur = v;
        }

        public void Lancer()
        {
            
        }
    }
}
