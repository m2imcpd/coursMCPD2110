using coursCSharp.Classes;
using System;

namespace coursCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Personne p = new Personne();

            //Etudiant e1 = new Etudiant();
            //e1.Nom = "toto";
            //e1.Prenom = "tata";
            //e1.Afficher();
            //Etudiant e2 = new Etudiant("titi", "minet");
            //e2.Afficher();
            Personne e3 = new Etudiant("tt", "aa", 1);
            Personne s1 = new Salarie("Snom", "Sprenom");
            Personne[] tabPersonne = new Personne[2];
            tabPersonne[0] = e3;
            tabPersonne[1] = s1;
            foreach(Personne p in tabPersonne)
            {
                if(p.GetType() == typeof(Etudiant))
                {
                    (p as Etudiant).AfficherEtudiant();
                }
                if (p.GetType() == typeof(Salarie))
                {
                    (p as Salarie).AfficherSalarie();
                }
                Console.WriteLine(p.GetType());
            }
            Console.ReadLine();
        }
    }
}