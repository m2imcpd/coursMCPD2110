﻿using CorrectionAnnuaire.Classes;
using System;

namespace CorrectionAnnuaire
{
    class Program
    {
        static void Main(string[] args)
        {
            IHM ihm = new IHM();
            ihm.Start();
            Console.ReadLine();
            
        }
    }
}