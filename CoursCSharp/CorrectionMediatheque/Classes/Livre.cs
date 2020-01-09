using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectionMediatheque.Classes
{
    public class Livre
    {
        private int nombrePage;

        public int NombrePage { get => nombrePage; set => nombrePage = value; }

        public Livre() : base()
        {

        }
    }
}
