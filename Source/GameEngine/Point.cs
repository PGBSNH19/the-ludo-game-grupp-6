﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine
{
    public abstract class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public bool Equals(Point point)
        {
            return point.X == this.X && point.Y == this.Y;
        }
    }
}
