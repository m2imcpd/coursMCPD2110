using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectionMediatheque.Classes
{
    public class DVD : Oeuvre
    {
        private double duree;

        public double Duree { get => duree; set => duree = value; }

        public DVD() : base()
        {

        }
    }
}
