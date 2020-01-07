using System;
using System.Collections.Generic;
using System.Text;

namespace coursCSharp.Classes
{
    public class Chien : IAnimal
    {
        private string nom;

        public string Nom { get => nom; set => nom = value; }

        public void Crier()
        {
            Console.WriteLine($"Le chien {Nom} aboie");
        }
    }
}
