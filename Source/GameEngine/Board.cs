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

        private readonly int PADDING_LEFT = 5;
        private readonly int PADDING_TOP = 2;

        public void Create()
        {
            Pieces = new List<Piece>();
            Tiles = new List<Tile>();
            var tiles = File.ReadAllLines("Paths/outer_path_coords.txt");
            foreach(var tile in tiles)
            {
                var tileData = tile.Split(',');
                var square = new Tile
                {
                    X = int.Parse(tileData[0]),
                    Y = int.Parse(tileData[1])
                };
                square.SetColor(tileData[2]);

                Tiles.Add(square);
            }
        }

        public void Draw() 
        {
            Tiles.ForEach(t =>
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = t.BackgroundColor;
                Console.SetCursorPosition(t.X + PADDING_LEFT, t.Y + PADDING_TOP);
                Console.WriteLine(t.Visual);
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            });
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

        public void MovePiece(Player player, int steps, GameConsole gc)
        {
            var piece = Pieces.Where(p => p.Player == player).FirstOrDefault();
            var currentTile = Tiles.First(t => t.X == piece.X && t.Y == piece.Y);
            
            var desiredLocationIndex = Tiles.IndexOf(currentTile) + steps;

            if (desiredLocationIndex >= Tiles.Count)
                desiredLocationIndex -= Tiles.Count;

            piece.Move(Tiles[desiredLocationIndex].X, Tiles[desiredLocationIndex].Y, steps);
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
