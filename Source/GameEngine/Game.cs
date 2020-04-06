using GameEngine.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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
        }

        public Game AddPlayer(Player player)
        {
            ValidateNewPlayerEntry(player);
            AddPieces(player);
            Players.Add(player);
            GameConsole.ConsolePrint($"{player.ColorName} enters game");
            GameConsole.ConsolePrint($" ");
            return this;
        }

        /// <summary>
        /// For now all players only have 1 piece
        /// </summary>
        /// <param name="owner"></param>
        private void AddPieces(Player owner)
        {
            //for(int i = 0; i < 4; i++)
            //{
            var piece = new Piece { Player = owner };
            piece.Reset();
            Board.Pieces.Add(new Piece { Player = owner });
            //}
        }

        /// <summary>
        /// Throws Exception if player of Type T already exists
        /// Throws Exception if Player count more than 4
        /// </summary>
        private void ValidateNewPlayerEntry(Player player)
        {
            if (Players.Count == 4)
            {
                throw new ArgumentOutOfRangeException("Can't add more than four players.");
            }
            else if (PlayerOfTypeExists(player.GetType()))
            {
                throw new ArgumentException("Player of type " + player.GetType() + " already exists.");
            }
        }

        public Game Start()
        {
            ReadyStateCheck();
            Board.Build(Players);
            Board.GameConsole = GameConsole;
            Board.Draw();
            while (true)
            {
                var activePlayer = Players.First();
                Action(activePlayer, Dice.Roll());

                Board.Draw();
                
                NextTurn();
                Console.ReadLine();
            }
        }
        
        private void Action(Player activePlayer, int result)
        {
            GameConsole.ConsolePrint($"{activePlayer.ColorName} rolls a {result}");

            if (result == 6 && Board.Pieces.Any(p => !p.InPlay && p.Player == activePlayer))
            {
                // Place a piece
                GameConsole.ConsolePrint($"\t{activePlayer.ColorName} puts a Piece into play");
                Board.PlacePiece(activePlayer);
            }
            else if (Board.Pieces.Any(p => p.InPlay && p.Player == activePlayer))
            {
                // Move a piece
                GameConsole.ConsolePrint($"\t{activePlayer.ColorName} moves a piece");
                Board.MovePiece(activePlayer, result);
            }
            else
            {
                // No action available
                GameConsole.ConsolePrint($"\t{activePlayer.ColorName} was unable to take action");
            }
        }

        /// <summary>
        /// Throws exception if less than 2 players or more than 4 players
        /// </summary>
        private void ReadyStateCheck()
        {
            //if(Players.Count() < 2)
            //    throw new Exception("More than one player is necessary to start.");
            if (Players.Count() > 4)
                throw new Exception("Four players or less is necessary to start.");
        }

        /// <summary>
        /// Turn succession 
        /// Next players turn (First in list)
        /// </summary>
        private void NextTurn() => Players = Players.Skip(1).Concat(Players.Take(1)).ToList();

        private bool PlayerOfTypeExists(Type playerType) => Players.Any(x => x.GetType() == playerType);
    }
}
