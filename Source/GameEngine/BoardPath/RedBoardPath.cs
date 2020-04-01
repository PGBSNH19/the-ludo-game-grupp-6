﻿namespace GameEngine.BoardPath
{
    public class RedBoardPath : IBoardPath
    {
        public int BoardPathID { get; set; }
        public BoardSquare[] BoardPath { get; private set; }
    }
}
