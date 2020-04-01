using GameEngine.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace GameEngine
{
    public class Game
    {
        public Board Board { get; set; }
        public List<Player> Players { get; set; }

        [NotMapped]
        public GameConsole GameConsole { get; set; }

        public Game()
        {
            GameConsole = new GameConsole();
            Board = new Board();
            Players = new List<Player>();
            Board.Create();
            Board.Draw();
            Console.ReadLine();
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

        public Game Start()
        {
            int floodControl = 0;
            while (true)
            {
                // Move this shit somewhere else
                if(floodControl == 4)
                {
                    Console.Clear();
                    floodControl = 0;
                    GameConsole.Reset();
                }
                Board.Draw();

                var activePlayer = Players.First();
                int diceRoll = Dice.Roll();
                GameConsole.ConsolePrint($"{activePlayer.PlayerName} rolls a {diceRoll}");


                activePlayer.PlacePiece(Board);

                NextTurn();
                floodControl++;
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Turn succession 
        /// Next players turn (First in list)
        /// </summary>
        private void NextTurn() => Players = Players.Skip(1).Concat(Players.Take(1)).ToList();

        private bool PlayerOfTypeExists(Type playerType)
        {
            return Players.Any(x => x.GetType() == playerType);
        }
    }
}
