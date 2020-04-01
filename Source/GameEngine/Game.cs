using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine
{
    public class Game
    {
        public Board Board { get; set; }
        public List<Player> Players { get; set; }
        public Game()
        {
            Console.WriteLine("New game of Ludo");
            Board = new Board();
            Board.Create();
            Board.Draw();
            Console.ReadLine();
            Players = new List<Player>();
        }

        public Game AddPlayer(Player player)
        {
            if (Players.Count == 4)
            {
                throw new ArgumentOutOfRangeException("Can't add more than four players.");
            }
            else if (PlayerOfTypeExists(player.GetType()))
            {
                throw new ArgumentException("Player of type " + player.GetType() + " already exists.");
            }

            Players.Add(player);

            return this;
        }
        
        private bool PlayerOfTypeExists(Type playerType)
        {
            return Players.Any(x => x.GetType() == playerType);
        }
    }
}
