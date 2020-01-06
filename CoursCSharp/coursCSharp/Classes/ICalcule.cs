using System;
using System.Collections.Generic;
using System.Text;

namespace coursCSharp.Classes
{
    public interface ICalcule<T> where T : IComparable
    {
        T Addition(string message, params int[] parametre);
        T Soustraction(string message, params int[] parametre);
    }
}
