using System;
using System.Collections.Generic;
using System.Text;

namespace coursCSharp.Classes
{
    public class Directeur : Chef
    {
        private string societe;

        public string Societe { get => societe; set => societe = value; }

        public Directeur()
        {

        }

        public Directeur(string n, string p, DateTime d, decimal s, string service, string soc) : base(n,p,d,s,service)
        {
            Societe = soc;
        }

        public override void Afficher()
        {
            base.Afficher();
            Console.WriteLine("Directeur de la société : " + Societe);
        }
    }
}
