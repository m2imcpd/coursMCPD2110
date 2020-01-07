using System;
using System.Collections.Generic;
using System.Text;

namespace coursCSharp.Classes
{
    public abstract class Figure
    {
        private float posX;
        private float posY;

        public float PosX { get => posX; set => posX = value; }
        public float PosY { get => posY; set => posY = value; }

        public abstract void Affiche();

        public Figure(float posX,float posY)
        {
            PosX = posX;
            PosY = posY;
        }
    }
}
