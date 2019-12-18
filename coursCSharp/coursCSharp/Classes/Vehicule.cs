using System;
using System.Collections.Generic;
using System.Text;

namespace coursCSharp.Classes
{
    public abstract class Vehicule
    {
        private int matricule;
        private int annee;
        private decimal prix;
        private static int compteur = 0;

        public int Matricule { get => matricule; set => matricule = value; }
        public int Annee { get => annee; set => annee = value; }
        public decimal Prix { get => prix; set => prix = value; }

        protected Vehicule()
        {
            compteur++;
            Matricule = compteur;
        }

        public Vehicule(int a, decimal p) : this()
        {
            Annee = a;
            Prix = p;
        }
        public string ToString()
        {
            return "Matricule : " + Matricule + " Annee : " + Annee + " Prix : " + Prix;
        }
        //public abstract void Demarrer();
        //public abstract void Accelerer();
    }
}
