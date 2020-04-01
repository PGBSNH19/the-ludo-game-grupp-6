using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine
{
    public class Game
    {
        public Board Board { get; set; }
        public Game()
        {
            Console.WriteLine("New game of Ludo");
            Board = new Board();
            Board.Create();
            Board.Draw();
            Console.ReadLine();
        }
    }
}
