using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectionMediatheque.Classes
{
    public class CD : Oeuvre
    {
        private int nombrePiste;

        public int NombrePiste { get => nombrePiste; set => nombrePiste = value; }

        public CD() :base()
        {

        }
    }
}
