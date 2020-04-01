using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine
{
    public class Square
    {
        public int BoardSquareID { get; set; }
        public string Visual { get; set; }
        public ConsoleColor BackgroundColor { get; set; }

        public Point Location { get; set; }

        public Square(Point point) => Location = point;

        public void SetColor(string colorCode)
        {
            BackgroundColor = colorCode switch
            {
                "R" => ConsoleColor.Red,
                "G" => ConsoleColor.Green,
                "B" => ConsoleColor.Blue,
                "Y" => ConsoleColor.DarkYellow,
                "W" => ConsoleColor.White,
                _ => ConsoleColor.Black,
            };
        }
    }
}
