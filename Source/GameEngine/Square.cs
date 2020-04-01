using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine
{
    public class Square : Point
    {
        public int BoardSquareID { get; set; }
        public Path BoardPath { get; set; }
        public int BoardPathID { get; set; }
    }
}
