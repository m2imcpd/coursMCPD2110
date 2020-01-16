using CorrectionPanier.Classes;
using System;
using System.Text;

namespace CorrectionPanier
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            IHM ihm = new IHM();
            ihm.Start();
            Console.ReadLine();
        }
    }
}
