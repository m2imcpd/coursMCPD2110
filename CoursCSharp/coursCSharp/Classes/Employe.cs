using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace coursCSharp.Classes
{
    public class Employe : Personne
    {
        private decimal salaire;
        private string telephone;

        public decimal Salaire { get => salaire; set
            {
                if (value >= 0)
                    salaire = value;
                else
                    throw new SalaireException();
            }
        }

        public string Telephone { get => telephone; set {
                string pattern = @"^0\d{1}((-\d{2}){4}|(\.\d{2}){4}|(\s\d{2}){4})$";
                if (Regex.IsMatch(value, pattern))
                    telephone = value;
                else
                    throw new Exception("Erreur telephone");
            }
        }

        public Employe()
        {

        }
        public Employe(string n, string p, DateTime d, decimal s) : base(n,p,d)
        {
            Salaire = s;
        }

        public override void Afficher()
        {
            base.Afficher();
            Console.WriteLine("Employé avec un salaire de : " + Salaire);
        }
    }
}
