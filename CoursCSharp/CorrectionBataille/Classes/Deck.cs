using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectionBataille.Classes
{
    public class Deck
    {
        private List<Carte> cartes;

        public List<Carte> Cartes { get => cartes; set => cartes = value; }

        public Deck()
        {
            Cartes = new List<Carte>();
        }

        public void Create()
        {
            for(int i=2; i<=14; i++)
            {
                for(int j=1; j <= 1; j++)
                {
                    Carte c = new Carte { Valeur = i };
                    Cartes.Add(c);
                }
            }
        }

        public void Shuffle()
        {
            Random r = new Random();
            for(int i=0; i < Cartes.Count; i++)
            {
                int tmp = r.Next(0, Cartes.Count);
                Carte cTmp = Cartes[tmp];
                Cartes[tmp] = Cartes[i];
                Cartes[i] = cTmp;
            }
        }

        public void Distribuer(IJoueur j1, IJoueur j2)
        {
            for(int i=0; i < Cartes.Count; i++)
            {
                if (i % 2 == 0)
                {
                    j1.Cartes.Add(Cartes[i]);
                }
                else
                {
                    j2.Cartes.Add(Cartes[i]);
                }
            }
        }
    }
}
