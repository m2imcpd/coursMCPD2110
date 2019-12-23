using System;
using System.Collections.Generic;
using System.Text;

namespace coursCSharp.Classes
{
    public class Forum
    {
        private string nom;
        private DateTime dateCreation;

        public List<Nouvelle> Nouvelles;
        public List<Abonne> Abonnes;
        public Moderateur Moderateur;

        public string Nom { get => nom; set => nom = value; }
        public DateTime DateCreation { get => dateCreation; set => dateCreation = value; }

        public Forum()
        {
            Nouvelles = new List<Nouvelle>();
            Abonnes = new List<Abonne>();
            Abonne a = new Abonne(this) { Nom = "toto", Prenom = "tata", Age = 100 };
            Abonnes.Add(a);
            DateCreation = DateTime.Now;
        }

        public Forum(string n) : this()
        {
            Nom = n;
        }

        public Abonne SearchAbonne(string nom)
        {
            Abonne abonne = null;
            foreach(Abonne a in Abonnes)
            {
                if(a.Nom == nom)
                {
                    abonne = a;
                    break;
                }
            }
            return abonne;
        }
    }
}
