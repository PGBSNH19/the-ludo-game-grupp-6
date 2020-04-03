using GameEngine.Modules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GameEngine
{
    public class Board
    {
        public List<Tile> Tiles { get; set; }
        public List<Piece> Pieces { get; set; }

        public OuterPath OuterPath { get; set; }
        public RedInnerPath RedPath { get; set; }
        public BlueInnerPath BluePath { get; set; }
        public GreenInnerPath GreenPath { get; set; }
        public YellowInnerPath YellowPath { get; set; }

        private readonly int PADDING_LEFT = 5;
        private readonly int PADDING_TOP = 2;

        public void Build()
        {
            Pieces = new List<Piece>();
            //Tiles = new List<Tile>();

            OuterPath = (OuterPath)new OuterPath().Build();
            RedPath = (RedInnerPath)new RedInnerPath().Build();
            BluePath = (BlueInnerPath)new BlueInnerPath().Build();
            GreenPath = (GreenInnerPath)new GreenInnerPath().Build();
            YellowPath = (YellowInnerPath)new YellowInnerPath().Build();

            //var pathData = File.ReadAllLines("Paths/outer_path_coords.txt");
            //foreach(var data in pathData)
            //{
            //    var tileData = data.Split(',');
            //    var tile = new Tile
            //    {
            //        X = int.Parse(tileData[0]),
            //        Y = int.Parse(tileData[1])
            //    };
            //    tile.SetColor(tileData[2]);

            //    Tiles.Add(tile);
            //}
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

        public void MovePiece(Player player, int steps, GameConsole gc)
        {
            var path = OuterPath.Tiles;

            var piece = Pieces.Where(p => p.Player == player).FirstOrDefault();
            var currentTile = path.First(t => t.Equals(piece));
            
            var desiredLocationIndex = path.IndexOf(currentTile) + steps;

            if (desiredLocationIndex >= path.Count)
                desiredLocationIndex -= path.Count;

            piece.Move(path[desiredLocationIndex].X, path[desiredLocationIndex].Y, steps);
            gc.ConsolePrint(" ");
            gc.ConsolePrint("Total of " + piece.Steps + " steps");
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
