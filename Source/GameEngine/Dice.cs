using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine
{
    public class Dice
    {
        public Random Random { get; set; }
        public Dice() => Random = new Random();
        public int Roll() => Random.Next(1, 6 + 1);
        
    }
}
