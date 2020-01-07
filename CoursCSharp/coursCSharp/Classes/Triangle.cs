using System;
using System.Collections.Generic;
using System.Text;

namespace coursCSharp.Classes
{
    class Triangle : Figure
    {

        private float baseTriangle;
        private float hauteur;

        public Triangle(float posX, float posY, float baseTriangle, float hauteur) : base(posX, posY)
        {
            BaseTriangle = baseTriangle;
            Hauteur = hauteur;
        }

        public float BaseTriangle { get => baseTriangle; set => baseTriangle = value; }
        public float Hauteur { get => hauteur; set => hauteur = value; }

        public override void Affiche()
        {
            Console.WriteLine("Triangle base : " + BaseTriangle + " hauteur: " + Hauteur + " X:" + PosX + " Y:" + PosY);
        }
    }
}
