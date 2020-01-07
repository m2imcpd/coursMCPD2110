using System;
using System.Collections.Generic;
using System.Text;

namespace coursCSharp.Classes
{
    class Rectangle : Figure,IDeformable
    {
        private float largeur;
        private float longueur;

        public float Largeur { get => largeur; set => largeur = value; }
        public float Longueur { get => longueur; set => longueur = value; }

        public override void Affiche()
        {
            Console.WriteLine("Un Rectangle de longueur " + Longueur + " et de largeur " + Largeur + " et de centre X:" + PosX + " Y:" + PosY);
        }

        public Rectangle(float posX,float posY, float largeur, float longueur) : base(posX,posY)
        {
            Largeur = largeur;
            Longueur = longueur;
        }

        public Figure Deformation(float coeffH, float coeffV)
        {
            if(Largeur*coeffH == Longueur * coeffV)
            {
                return new Carre(PosX, PosY, Largeur);
            } else
            {
                return new Rectangle(PosX, PosY, Largeur * coeffH, Longueur * coeffV);
            }
                
        }
    }
}
