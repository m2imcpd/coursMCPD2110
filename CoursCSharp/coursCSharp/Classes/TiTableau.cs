using System;
using System.Collections.Generic;
using System.Text;

namespace coursCSharp.Classes
{
    public class TiTableau
    {
        private int[] substrat;
        private int taille;

        private int[] Substrat { get => substrat; set => substrat = value; }
        public int Taille { get => Substrat.Length;  }
        public bool Vide { get => Taille == 0; }
        public int this[int n]
        {
            get => (n < taille) ?Substrat[n] : 0;
            set => Substrat[n] = value;
        }
        public TiTableau(int t)
        {
            Substrat = new int[t];
        }

        public bool Contient(int a)
        {
            foreach(int i in Substrat)
            {
                if(i == a)
                {
                    return true;
                }
            }
            return false;
        }
        public override string ToString()
        {
            string chaine = "";
            foreach(int i in Substrat)
            {
                chaine += $"{i} ";
            }
            return chaine;
        }

        public static bool operator ==(TiTableau t1, TiTableau t2)
        {
            if(t1.Taille != t2.Taille)
            {
                return false;
            }
            for(int i=0; i < t1.Taille; i++)
            {
                if(t1[i] != t2[i])
                {
                    return false;
                }
            }
            return true;
        }
        public static bool operator !=(TiTableau t1, TiTableau t2)
        {
            return !(t1 == t2);
        }

        public static bool operator <(TiTableau t1, TiTableau t2)
        {
            if (t1.Taille != t2.Taille)
                return false;
            for(int i=0; i< t1.Taille; i++)
            {
                if(t1[i] > t2[i])
                {
                    return false;
                } 
            }
            return true;
        }
        public static bool operator <=(TiTableau t1, TiTableau t2)
        {
            if (t1.Taille != t2.Taille)
                return false;
            return !(t1 > t2);
        }
        public static bool operator >(TiTableau t1, TiTableau t2)
        {
            if (t1.Taille != t2.Taille)
                return false;
            return t2 < t1;
        }
        public static bool operator >=(TiTableau t1, TiTableau t2)
        {
            if (t1.Taille != t2.Taille)
                return false;
            return !(t1 < t2);
        }

        public static int[] operator +(TiTableau t1, TiTableau t2)
        {
            int max = t1.Taille > t2.Taille ? t1.Taille : t2.Taille;
            int[] tab = new int[max];
            for(int i=0; i < max; i++)
            {
                tab[i] = t1[i] + t2[i];
            }
            return tab;
        }
        public static int[] operator -(TiTableau t1, TiTableau t2)
        {
            int max = t1.Taille > t2.Taille ? t1.Taille : t2.Taille;
            int[] tab = new int[max];
            for (int i = 0; i < max; i++)
            {
                tab[i] =(t1.Taille > t2.Taille) ? t1[i] - t2[i] : t2[i] - t1[i];
            }
            return tab;
        }
    }
}
