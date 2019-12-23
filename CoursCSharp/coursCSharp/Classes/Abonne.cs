using System;
using System.Collections.Generic;
using System.Text;

namespace coursCSharp.Classes
{
    public class Abonne
    {
        private string nom;
        private string prenom;
        private int age;
        protected Forum forum;

        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public int Age { get => age; set => age = value; }

        public Abonne(Forum f)
        {
            forum = f;
        }

        public void AjouterNouvelle(Nouvelle n)
        {
            forum.Nouvelles.Add(n);
        }

        public override string ToString()
        {
            return "Nom : " + Nom + " Prénom : " + Prenom + " Age : " + Age;
        }


    }
}
