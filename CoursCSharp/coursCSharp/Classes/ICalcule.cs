using System;
using System.Collections.Generic;
using System.Text;

namespace coursCSharp.Classes
{
    public interface ICalcule
    {
        double Addition(string message, params int[] parametre);
        double Soustraction(string message, params int[] parametre);
    }
}
