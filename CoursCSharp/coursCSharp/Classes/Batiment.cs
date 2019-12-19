using System;
using System.Collections.Generic;
using System.Text;

namespace coursCSharp.Classes
{
    public class Batiment
    {
        private string adresse;

        public string Adresse { get => adresse; set => adresse = value; }

        public Batiment()
        {

        }
        public Batiment(string a)
        {
            Adresse = a;
        }

        public string ToString()
        {
            return "Adresse : " + Adresse;
        }
    }
}
