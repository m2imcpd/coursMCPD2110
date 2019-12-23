using System;
using System.Collections.Generic;
using System.Text;

namespace coursCSharp.Classes
{
    public class Generic<T>
    {
        public T[] tab;

        public Generic()
        {
            tab = new T[10];
        }

        public void AfficherElement()
        {
            foreach(T a in tab)
            {
                Console.WriteLine(a);
            }
        }
    }
}
