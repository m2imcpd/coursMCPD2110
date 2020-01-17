using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectionBataille.Classes
{
    public class Joueur : IJoueur
    {
        private List<Carte> cartes;

        public List<Carte> Cartes { get => cartes; set => cartes = value; }

        public Joueur()
        {
            Cartes = new List<Carte>();
        }
    }
}
