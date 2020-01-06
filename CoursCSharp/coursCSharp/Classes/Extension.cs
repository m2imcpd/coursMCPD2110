using System;
using System.Collections.Generic;
using System.Text;

namespace coursCSharp.Classes
{
    public static class Extension
    {
        public static void Shuffle<T>(this List<T> liste)
        {
            Random r = new Random();
            for(int i = 0; i < liste.Count; i++)
            {
                int aleatoire = r.Next(liste.Count);
                T tmp = liste[aleatoire];
                liste[aleatoire] = liste[i];
                liste[i] = tmp;
            }
        }
    }
}
