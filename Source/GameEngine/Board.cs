using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GameEngine
{
    public class Board
    {
        public List<Square> Tiles { get; set; }

        public const int BOARD_WIDTH = 15;
        public const int BOARD_HEIGHT = 15;

        public Board() => Tiles = new List<Square>();

        public void Create()
        {
            var tiles = File.ReadAllLines("OuterPath.txt");
            foreach(var tile in tiles)
            {
                var tileData = tile.Split(',');
                var square = new Square();

                square.X = int.Parse(tileData[0]);
                square.Y = int.Parse(tileData[1]);
                square.SetColor(tileData[2]);

                Tiles.Add(square);
            }
        }

        public void Draw() => Tiles.ForEach(t => {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = t.BackgroundColor;
                Console.SetCursorPosition(t.X, t.Y);
                Console.WriteLine(t.Visual);
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            });
    }
}
