using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectionMediatheque.Classes
{
    public class BD : Oeuvre
    {
        private int nombreDessin;

        public int NombreDessin { get => nombreDessin; set => nombreDessin = value; }

        public BD() : base()
        {

        }
    }
}
