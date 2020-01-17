using CorrectionBataille.Classes;
using System;

namespace CorrectionBataille
{
    class Program
    {
        static void Main(string[] args)
        {
            Jeu jeu = new Jeu();
            Joueur j1 = new Joueur();
            Joueur j2 = new Joueur();
            jeu.Deck.Create();
            jeu.Deck.Shuffle();
            jeu.Deck.Distribuer(j1, j2);
            Console.WriteLine(jeu.Jouer(j1, j2));
            Console.ReadLine();
        }
    }
}
