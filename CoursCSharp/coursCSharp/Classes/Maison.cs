using System;
using System.Collections.Generic;
using System.Text;

namespace coursCSharp.Classes
{
    public class Maison : Batiment
    {
        private int nbPieces;

        public int NbPieces { get => nbPieces; set => nbPieces = value; }
        
        public Maison()
        {

        }
        public Maison(string a, int n) : base(a)
        {
            NbPieces = n;
        }

        public string ToString()
        {
            return "Adresse : " + Adresse + " NbPieces : " + NbPieces;
        }
    }
}
