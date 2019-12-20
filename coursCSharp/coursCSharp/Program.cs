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
            //foreach (Vehicule ve in tabVehicule)
            //{
            //    Console.WriteLine(ve);
            //    ve.Demarrer();
            //    ve.Accelerer();
            //}
            //Correction Exercice 2
            Console.OutputEncoding = Encoding.UTF8;
            //Maison m = new Maison("tourcoing", 3);
            //Batiment b = new Batiment("tourcoing");
            //Console.WriteLine(m.ToString());
            //Console.WriteLine(b.ToString());

            //Etudiant e = new Etudiant();
            //e.Marcher();
            //Salarie s = new Salarie();
            //s.Marcher();
            //Personne e = new Etudiant();
            //e.Marcher();
            //Personne s = new Salarie();
            //s.Marcher();
            //DateTime date = new DateTime(1987, 09, 11);

            //Correction ex3

            //Personne[] tab = new Personne[8];
            //tab[0] = new Employe("en1", "ep1", new DateTime(1900, 01, 01), 1000);
            //tab[1] = new Employe("en2", "ep2", new DateTime(1900, 01, 02), 1001);
            //tab[2] = new Employe("en3", "ep3", new DateTime(1900, 01, 03), 1002);
            //tab[3] = new Employe("en4", "ep4", new DateTime(1900, 01, 04), 1003);
            //tab[4] = new Employe("en5", "ep5", new DateTime(1900, 01, 05), 1004);
            //tab[5] = new Chef("cn1", "cp1", new DateTime(1800, 01, 01), 10000, "informatique");
            //tab[6] = new Chef("cn2", "cp2", new DateTime(1800, 01, 02), 10001, "RH");
            //tab[7] = new Directeur("dn1", "dp1", new DateTime(1700, 01, 01), 100000, "directeur", "M2I");
            //foreach(Personne p in tab)
            //{
            //    p.Afficher();
            //}

            //Correction compte bancaire version 1

            IHMCompte ihmCompte = new IHMCompte();
            ihmCompte.Start();
            Console.ReadLine();
        }
    }
}