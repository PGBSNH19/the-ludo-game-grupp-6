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

                piece.MoveWithinInnerPath(currentLocationIndex, path, steps);
            }
            // Enter InnerPath
            else if (piece.Steps + steps > 50)
            {
                path = player.InnerPath;
                piece.MoveIntoInnerPath(path, steps);
            }
            // Move along OuterPath
            else
            {
                path = OuterPath;
                piece.MoveWithinOuterPath(path, steps);
            }
        }

        public void PlacePiece(Player activePlayer)
        {
            var piece = Pieces
               .Where(p => p.Player == activePlayer && !p.InPlay)
               .First();
            piece.Move(activePlayer.StartX, activePlayer.StartY);
        }
    }
}
