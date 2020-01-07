using System;
using System.Collections.Generic;
using System.Text;

namespace coursCSharp.Classes
{
    class Carre : Figure,IDeformable
    {
        private float cote;

        public Carre(float posX, float posY, float cote) : base(posX, posY)
        {
            Cote = cote;
        }

        public float Cote { get => cote; set => cote = value; }

        public override void Affiche()
        {
            Console.WriteLine("Je suis un carré de cote " + cote + " et de centre X:" + PosX + " Y:" + PosY);
        }

        public Figure Deformation(float coeffH, float coeffV)
        {
            if (coeffH == coeffV)
            {
                return new Carre(PosX, PosY, Cote * coeffH);
            } else
            {
                return new Rectangle(PosX, PosY, Cote * coeffH, Cote * coeffV);
            }
        }
    }
}
