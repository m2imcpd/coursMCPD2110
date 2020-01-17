using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CorrectionBataille.Classes
{
    public class Jeu
    {
        private Deck deck;
        private List<Carte> tas;
        
        public Jeu()
        {
            tas = new List<Carte>();
            Deck = new Deck();
        }

        public Deck Deck { get => deck; set => deck = value; }
        

        public void JouerUnTour(IJoueur joueur1, IJoueur joueur2)
        {
            Carte c1, c2;
            do
            {
                c1 = joueur1.Cartes[0];
                c2 = joueur2.Cartes[0];
                joueur1.Cartes.RemoveAt(0);
                joueur2.Cartes.RemoveAt(0);
                tas.Add(c1);
                tas.Add(c2);
                Console.WriteLine($"J1 : {c1.Valeur}, J2 : {c2.Valeur}");
                Thread.Sleep(200);
            } while (c1.Valeur == c2.Valeur);
            if(c1.Valeur > c2.Valeur)
            {
                joueur1.Cartes.AddRange(tas);
            }
            else
            {
                joueur2.Cartes.AddRange(tas);
            }
            Console.WriteLine($"Nombre carte J1 : {joueur1.Cartes.Count}, Nombre carte J2 : {joueur2.Cartes.Count}");
            tas.Clear();
        }

        public string Jouer(IJoueur joueur1, IJoueur joueur2)
        {
            while(joueur1.Cartes.Count > 0 && joueur2.Cartes.Count > 0)
            {
                JouerUnTour(joueur1, joueur2);
            }
            if(joueur2.Cartes.Count > 0)
            {
                return "j2 win";
            }
            else
            {
                return "j1 win";
            }
        }
    }
}
