using System;
using System.Collections.Generic;
using System.Text;

namespace coursCSharp.Classes
{
    public class Pile<T>
    {
        private T[] tabElements;
        private int taille;
        private int compteur;

        public Pile(int t)
        {
            taille = t;
            tabElements = new T[taille];
            compteur = 0;
        }

        public bool Empiler(T element)
        {
            if(compteur < taille)
            {
                tabElements[compteur] = element;
                compteur++;
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public bool Depiler()
        {
            if(compteur >= 0)
            {
                tabElements[compteur - 1] = default(T);
                compteur--;
                return true;
            }
            else
            {
                return false;
            }
        }
        public T GetElement(int index)
        {
            if(index >= 0 && index < compteur)
            {
                return tabElements[index];
            }
            else
            {
                return default(T);
            }
        }
    }
}
