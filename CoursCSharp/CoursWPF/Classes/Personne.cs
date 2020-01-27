using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursWPF.Classes
{
    public class Personne
    {
        private string nom;
        private string prenom;

        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set {
                if (value.Length > 4)
                    prenom = value;
                else
                    throw new Exception("Erreur prenom");
            }
        }

        public static List<Personne> listes = new List<Personne>();

        public override string ToString()
        {
            return $"{Nom} {Prenom}";
        }
    }
}
