using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectionMediatheque.Classes
{
    public class Livre :Oeuvre
    {
        private int nombrePage;

        public int NombrePage { get => nombrePage; set => nombrePage = value; }

        public Livre() : base()
        {

        }
    }
}
