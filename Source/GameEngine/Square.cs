using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine
{
    public class Square : Point
    {
        public int BoardSquareID { get; set; }
        public string Visual { get; set; }
        public ConsoleColor BackgroundColor { get; set; }

        public Square() => Visual = " ";

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
