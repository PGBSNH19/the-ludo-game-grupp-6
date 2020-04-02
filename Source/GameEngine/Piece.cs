using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine
{
    public enum PlayerColor
    {
        Red,
        Blue,
        Green,
        Yellow
    }

    public class Piece : Point
    {
        public int BoardPieceID { get; set; }
        public Player Player { get; set; }
        public string Visual { get; set; } = "◙";
        public bool InPlay { get => X != 0 && Y != 0; }

        public Piece() => KickOut();

        public void KickOut()
        {
            X = 0;
            Y = 0;
        }

        public void Move(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
