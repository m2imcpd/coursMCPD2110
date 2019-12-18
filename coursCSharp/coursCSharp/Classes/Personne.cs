using System;
using System.Collections.Generic;
using System.Text;

namespace coursCSharp.Classes
{
    public class Personne
    {
        private string nom;
        private string prenom;
        protected string propsProtected;

        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }

        public Personne()
        {

        }

        public Personne(string n, string p)
        {
            Nom = n;
            Prenom = p;
        }

        public void Afficher()
        {
            Console.WriteLine("Nom : " + Nom + " Prénom : " + Prenom);
        }
    }
}
