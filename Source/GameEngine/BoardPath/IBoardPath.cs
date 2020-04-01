using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine
{
    interface IBoardPath
    {
        public int BoardPathID { get; set; }
        public BoardSquare[] BoardPath { get; set; }
    }
}
