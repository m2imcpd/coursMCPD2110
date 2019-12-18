using coursCSharp.Classes;
using System;

namespace coursCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Etudiant e1 = new Etudiant();
            e1.Nom = "toto";
            e1.Prenom = "tata";
            e1.Afficher();
            Etudiant e2 = new Etudiant("titi", "minet");
            e2.Afficher();
            Etudiant e3 = new Etudiant("tt", "aa", 1);

            Console.ReadLine();
        }
    }
}