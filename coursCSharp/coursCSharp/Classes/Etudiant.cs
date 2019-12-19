using System;
using System.Collections.Generic;
using System.Text;

namespace coursCSharp.Classes
{
    public sealed class Etudiant : Personne
    {
        private int niveau;

        public Etudiant() : base()
        {

        }

        public Etudiant(string n, string p) : base(n,p)
        {

        }

        public Etudiant(string n, string p, int l) : base(n, p)
        {
            Niveau = l;
        }

        public int Niveau { get => niveau; set => niveau = value; }

        public void EditPropsProtected(string p)
        {
            propsProtected = p;
        }

        public void AfficherEtudiant()
        {
            Console.WriteLine("Je suis un etudiant"); 
        }

        public override void Marcher()
        {
            //base.Marcher();
            Console.WriteLine("Un etudiant qui marche");
        }
    }
}
