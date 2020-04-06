using GameEngine.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace GameEngine
{
    public class Board
    {
        public List<Piece> Pieces { get; set; }

        public OuterPath OuterPath { get; set; }
        public RedInnerPath RedPath { get; set; }
        public BlueInnerPath BluePath { get; set; }
        public GreenInnerPath GreenPath { get; set; }
        public YellowInnerPath YellowPath { get; set; }
        public List<Player> Players { get; set; }

        [NotMapped]
        public GameConsole GameConsole { get; set; }

        private readonly int PADDING_LEFT = 5;
        private readonly int PADDING_TOP = 2;

        public Board()
        {
            Pieces = new List<Piece>();
        }

        public void Build(List<Player> players)
        {
            OuterPath = (OuterPath)new OuterPath().Build();
            RedPath = (RedInnerPath)new RedInnerPath().Build();
            BluePath = (BlueInnerPath)new BlueInnerPath().Build();
            GreenPath = (GreenInnerPath)new GreenInnerPath().Build();
            YellowPath = (YellowInnerPath)new YellowInnerPath().Build();

            players.ForEach(p => {
                switch(p.GetType().ToString().Substring(11))
                {
                    case "RedPlayer":
                        p.InnerPath = RedPath;
                        break;
                    case "BluePlayer":
                        p.InnerPath = BluePath;
                        break;
                    case "GreenPlayer":
                        p.InnerPath = GreenPath;
                        break;
                    case "YellowPlayer":
                        p.InnerPath = YellowPath;
                        break;
                }
            });
        }

        public void Draw() 
        {
            DrawPath(OuterPath);
            DrawPath(RedPath);
            DrawPath(BluePath);
            DrawPath(GreenPath);
            DrawPath(YellowPath);
            Pieces.Where(p => p.InPlay).ToList().ForEach(p =>
            {
                Console.ForegroundColor = p.Player.GetColor();
                Console.BackgroundColor = ConsoleColor.White;
                Console.SetCursorPosition(p.X + PADDING_LEFT, p.Y + PADDING_TOP);
                Console.WriteLine(p.Visual);
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            });
        }

        private void DrawPath(Path pathObj)
        {
            pathObj.Tiles.ForEach(t =>
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = t.BackgroundColor;
                Console.SetCursorPosition(t.X + PADDING_LEFT, t.Y + PADDING_TOP);
                Console.WriteLine(t.Visual);
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            });
        }

        private Piece GetPieceInBoard(Point point)
        {
            Piece piece = Pieces.FirstOrDefault(p => p.Equals(point));
            return piece;
        }

        public void MovePiece(Player player, int steps)
        {
            var piece = Pieces.Where(p => p.Player == player).FirstOrDefault();
            Path path = null;

            // Already in InnerPath
            if (piece.Steps > 50)
            {
                path = player.InnerPath;

                var currentLocationIndex = path.Tiles
                    .IndexOf(path.Tiles.First(t => t.Equals(piece)));

                MoveWithinInnerPath(piece, currentLocationIndex, path, steps);
            }
            // Enter InnerPath
            else if (piece.Steps + steps > 50)
            {
                path = player.InnerPath;
                MoveIntoInnerPath(piece, path, steps);
            }
            // Move along OuterPath
            else
            {
                path = OuterPath;
                MoveWithinOuterPath(piece, path, steps);
            }
            Piece existingPiece = GetPieceInBoard(piece);

            if (existingPiece != null)
            {
                //Kick!
            }
        }

        public void PlacePiece(Player activePlayer)
        {
            var piece = Pieces
               .Where(p => p.Player == activePlayer && !p.InPlay)
               .First();
            piece.Move(activePlayer.StartX, activePlayer.StartY);
        }

        public void MoveWithinInnerPath(Piece piece, int currentLocationIndex, Path path, int steps)
        {
            var pathLength = path.Tiles.Count;
            int nextLocationIndex;

            if (currentLocationIndex == pathLength - 1)
            {
                if (steps != 6)
                    return;

                piece.PassGoal();
                return;
            }
            else if (currentLocationIndex + steps > pathLength - 1)
            {
                var diff = currentLocationIndex + steps - (pathLength - 1);
                nextLocationIndex = (pathLength - 1) - Math.Abs(diff);
                if (nextLocationIndex < 1) nextLocationIndex = 0;
            }
            else
            {
                nextLocationIndex = currentLocationIndex + steps;
            }

            piece.Move(path.Tiles[nextLocationIndex].X, path.Tiles[nextLocationIndex].Y, steps);
        }

        public void MoveIntoInnerPath(Piece piece, Path path, int steps)
        {
            int nextLocationIndex = piece.Steps + (steps - 1) - 50;
            if (nextLocationIndex > path.Tiles.Count - 1)
                nextLocationIndex--;
            piece.Move(path.Tiles[nextLocationIndex].X, path.Tiles[nextLocationIndex].Y, steps);
        }

        public void MoveWithinOuterPath(Piece piece, Path path, int steps)
        {
            var currentTile = path.Tiles.First(t => t.Equals(this));

            int nextLocationIndex = path.Tiles.IndexOf(currentTile) + steps;

            if (nextLocationIndex >= path.Tiles.Count)
                nextLocationIndex -= path.Tiles.Count;

            piece.Move(path.Tiles[nextLocationIndex].X, path.Tiles[nextLocationIndex].Y, steps);
        }
    }
}
