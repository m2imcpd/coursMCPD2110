using System;
using System.Collections.Generic;
using System.Text;

namespace coursCSharp.Classes
{
    public interface IAnimal
    {
        string Nom { get; set; }
        void Crier();
    }
}
