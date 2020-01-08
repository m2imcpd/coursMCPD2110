using System;
using System.Collections.Generic;
using System.Text;

namespace coursCSharp.Classes
{
    public class Employe : Personne
    {
        private decimal salaire;

        public decimal Salaire { get => salaire; set
            {
                if (value >= 0)
                    salaire = value;
                else
                    throw new SalaireException();
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
