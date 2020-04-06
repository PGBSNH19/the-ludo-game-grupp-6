using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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
        public string Visual { get; } = "◙";
        public int Steps { get; set; }
        public bool Completed { get; set; } = false;
        [NotMapped]
        public bool InPlay { get => !(X == 0 && Y == 0); }
        [NotMapped]
        public Player Player { get; set; }

        public Piece() 
        {
            MoveOut();
            Completed = false;
        }

        public void PassGoal()
        {
            this.Completed = true;
            Player.Score++;
            MoveOut();
        }

        public void MoveOut()
        {
            X = 0;
            Y = 0;
            Reset();
        }

        public void Reset() => Steps = 0;

        public void Move(int x, int y, int steps = 0)
        {
            X = x;
            Y = y;
            Steps += steps;
        }
    }
}
