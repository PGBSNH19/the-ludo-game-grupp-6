using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine
{
    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public bool Equals(Point point)
        {
            return point.X == this.X && point.Y == this.Y;
        }
    }
}
