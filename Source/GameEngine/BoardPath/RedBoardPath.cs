using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.BoardPath
{
    public class RedBoardPath : IBoardPath
    {
        public int BoardPathID { get; set; }
        public BoardSquare[] BoardPath { get; set; }
    }
}
