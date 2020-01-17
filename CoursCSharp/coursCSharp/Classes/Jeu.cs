using System;
using System.Collections.Generic;
using System.Text;

namespace coursCSharp.Classes
{
    public class Jeu
    {
        public bool Jouer(IDe dJoueur1, IDe dJoueur2)
        {
            bool result = false;
            dJoueur1.Lancer();
            dJoueur2.Lancer();
            if(dJoueur1.Valeur > dJoueur2.Valeur)
            {
                result = true;
            }
            return result;
        }
    }
}
