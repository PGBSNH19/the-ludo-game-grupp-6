using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine
{
    public enum PieceColor
    {
        Red,
        Blue,
        Green,
        Yellow
    }

    public class Piece
    {
        public int BoardPieceID { get; set; }
        public PieceColor PieceColor { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public ConsoleColor GetColor()
        {
            return PieceColor switch
            {
                PieceColor.Red => ConsoleColor.Red,
                PieceColor.Blue => ConsoleColor.Blue,
                PieceColor.Green => ConsoleColor.Green,
                PieceColor.Yellow => ConsoleColor.DarkYellow,
                _ => ConsoleColor.White
            };
        }
    }
}
