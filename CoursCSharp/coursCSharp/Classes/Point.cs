using System;
using System.Collections.Generic;
using System.Text;

namespace coursCSharp.Classes
{
    public class Point
    {
        private int x;
        private int y;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        //public static Point operator +(Point p1, Point p2)
        //{
        //    return new Point { x = p1.X + p2.X, Y = p1.Y + p2.Y };
        //}

        public static Point operator +(Point p1, Point p2) => new Point { x = p1.X + p2.X, Y = p1.Y + p2.Y };

        public static bool operator ==(Point p1, Point p2) => p1.X==p2.X && p1.Y == p2.Y;
        public static bool operator !=(Point p1, Point p2)!(p1.X == p2.X && p1.Y == p2.Y);
    }
}
