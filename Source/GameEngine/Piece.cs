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

        private void TryMove(int nextLocationIndex, Path path, int steps)
        {
            try
            {
                Move(path.Tiles[nextLocationIndex].X, path.Tiles[nextLocationIndex].Y, steps);
            }
            catch
            {
                Move(path.Tiles[path.Tiles.Count - 1].X, path.Tiles[path.Tiles.Count - 1].Y, steps);
            }
        }

        internal void MoveWithinInnerPath(int currentLocationIndex, Path path, int steps)
        {
            var pathLength = path.Tiles.Count;
            int nextLocationIndex;

            if (currentLocationIndex == pathLength - 1)
            {
                if (steps != 6)
                    return;

                PassGoal();
                return;
            }
            else if (currentLocationIndex + steps > pathLength)
            {
                var diff = currentLocationIndex + steps - (pathLength - 1);
                nextLocationIndex = (pathLength - 1) - diff;
            }
            else
            {
                nextLocationIndex = currentLocationIndex + steps;
            }

            TryMove(nextLocationIndex, path, steps);
        }

        internal void MoveIntoInnerPath(Path path, int steps)
        {
            int nextLocationIndex = Steps + (steps - 1) - 50;
            TryMove(nextLocationIndex, path, steps);
        }

        internal void MoveWithinOuterPath(Path path, int steps)
        {
            var currentTile = path.Tiles.First(t => t.Equals(this));

            int nextLocationIndex = path.Tiles.IndexOf(currentTile) + steps;

            if (nextLocationIndex >= path.Tiles.Count)
                nextLocationIndex -= path.Tiles.Count;

            TryMove(nextLocationIndex, path, steps);
        }
    }
}
