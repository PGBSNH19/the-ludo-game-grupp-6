using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public bool Equals(Point point) => point.X == this.X && point.Y == this.Y;
    }

    public abstract class NewPoint
    {
        public int X { get; set; }
        public int Y { get; set; }

        public bool Equals(NewPoint point) => X == point.X && Y == point.Y;
    }
}
