using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenduMVVM.Classes
{
    public class Pendu
    {
        private static List<string> mots = new List<string>() { "google", "maison", "ordinateur", "newyork" };

        private string mot;

        private string masque;

        private string motEnCours;
        private int compteur;
        public string Mot { get => mot; }
        public string Masque { get => masque; }
        public string MotEnCours { get => motEnCours; set => motEnCours = value; }
        public int Compteur { get => compteur; }
        public Pendu()
        {
            Random r = new Random();
            int nbre = r.Next(0, mots.Count);
            mot = mots[nbre];
            masque = "";
            for(int i=0; i<mot.Length; i++)
            {
                masque += "*";
            }
            compteur = 10;
        }

        public bool TesterLettre(string lettre)
        {
            string masqueTmp = "";
            bool result = false;
            for(int i=0; i < mot.Length; i++)
            {
                if(mot[i].ToString() == lettre)
                {
                    masqueTmp += lettre;
                    result = true;
                }
                else
                {
                    masqueTmp += masque[i];
                }
            }
            masque = masqueTmp;
            if (!result)
            {
                compteur--;
            }
            return result;
        }

        
    }
}
