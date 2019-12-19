using coursCSharp.Classes;
using System;
using System.Text;

namespace coursCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region cours héritage
            ////Personne p = new Personne();

            ////Etudiant e1 = new Etudiant();
            ////e1.Nom = "toto";
            ////e1.Prenom = "tata";
            ////e1.Afficher();
            ////Etudiant e2 = new Etudiant("titi", "minet");
            ////e2.Afficher();
            //Personne e3 = new Etudiant("tt", "aa", 1);
            //Personne s1 = new Salarie("Snom", "Sprenom");
            //Personne[] tabPersonne = new Personne[2];
            //tabPersonne[0] = e3;
            //tabPersonne[1] = s1;
            //foreach(Personne p in tabPersonne)
            //{
            //    if(p.GetType() == typeof(Etudiant))
            //    {
            //        (p as Etudiant).AfficherEtudiant();
            //    }
            //    if (p.GetType() == typeof(Salarie))
            //    {
            //        (p as Salarie).AfficherSalarie();
            //    }
            //    Console.WriteLine(p.GetType());
            //}
            #endregion

            //Correction ex1

            //Vehicule v = new Voiture(2000, 1000);
            //Vehicule c = new Camion(1999, 2000);
            //Vehicule[] tabVehicule = new Vehicule[2];
            //tabVehicule[0] = v;
            //tabVehicule[1] = c;
            //foreach(Vehicule ve in tabVehicule)
            //{
            //    Console.WriteLine(ve.ToString());
            //    if(ve.GetType() == typeof(Voiture))
            //    {
            //        (ve as Voiture).Demarrer();
            //        (ve as Voiture).Accelerer();
            //    }
            //    if (ve.GetType() == typeof(Camion))
            //    {
            //        (ve as Camion).Demarrer();
            //        (ve as Camion).Accelerer();
            //    }
            //}
            //Correction Exercice 2
            //Console.OutputEncoding = Encoding.UTF8;
            //Maison m = new Maison("tourcoing", 3);
            //Batiment b = new Batiment("tourcoing");
            //Console.WriteLine(m.ToString());
            //Console.WriteLine(b.ToString());

            //Etudiant e = new Etudiant();
            //e.Marcher();
            //Salarie s = new Salarie();
            //s.Marcher();
            Personne e = new Etudiant();
            e.Marcher();
            Personne s = new Salarie();
            s.Marcher();
            DateTime date = new DateTime(1987, 09, 11);
            Console.ReadLine();
        }
    }
}