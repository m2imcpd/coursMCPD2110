using System;
using System.Collections.Generic;
using System.Text;

namespace coursCSharp.Classes
{
    public abstract class Personne
    {
        private string nom;
        private string prenom;
        protected string propsProtected;
        private DateTime dateNaissance;

        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public DateTime DateNaissance { get => dateNaissance; set => dateNaissance = value; }

        public Personne()
        {

        }
        public Personne(string n, string p)
        {
            Nom = n;
            Prenom = p;
            
        }

        public Personne(string n, string p, DateTime d)
        {
            Nom = n;
            Prenom = p;
            dateNaissance = d;
        }

        public virtual void Afficher()
        {
            Console.WriteLine("Nom : " + Nom + " Prénom : " + Prenom + " Date de naissance : "+ DateNaissance);
        }

        public virtual void Marcher()
        {
            Console.WriteLine("Une personne qui marche");
        }
    }
}
