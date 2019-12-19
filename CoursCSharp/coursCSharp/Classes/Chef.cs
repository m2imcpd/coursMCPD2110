using System;
using System.Collections.Generic;
using System.Text;

namespace coursCSharp.Classes
{
    public class Chef : Employe
    {
        private string service;

        public string Service { get => service; set => service = value; }

        public Chef()
        {

        }
        public Chef(string n, string p, DateTime d, decimal s, string service) : base(n,p,d,s)
        {
            Service = service;
        }

        public override void Afficher()
        {
            base.Afficher();
            Console.WriteLine("chef de service : " + Service);
        }
    }
}
