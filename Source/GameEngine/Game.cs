using GameEngine.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace GameEngine
{
    [Table("Game")]
    public class Game
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GameID { get; set; }
        [ForeignKey("Board")]
        public int BoardID { get; set; }
        public Board Board { get; set; }

        [NotMapped]
        public GameConsole GameConsole { get; set; }
        [NotMapped]
        public List<ScoreBoard> ScoreBoards { get; set; }
        [NotMapped]
        public List<Player> Players { get; set; }
        [NotMapped]
        public LudoContext Context  { get; set; }

        public Game()
        {
            Context = new LudoContext();
            GameConsole = new GameConsole();
            Board = new Board();
            ScoreBoards = new List<ScoreBoard>();
            Players = new List<Player>();
        }

        public Game AddPlayer(Player player)
        {
            ValidateNewPlayerEntry(player);
            AddPieces(player);

            Players.Add(player);
            GameConsole.ConsolePrint(player, "enters game");
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
                throw new ArgumentOutOfRangeException("Can't add more than four players.");
            else if (PlayerOfTypeExists(player.PlayerType))
                throw new ArgumentException("Player of type " + player.GetType() + " already exists.");
        }

        public Game Build()
        {
            GameStateReady();

            Board.GameConsole = GameConsole;
            Board.Build(Players);

            return this;
        }

        public Game AddScoreBoards()
        {
            Players.ForEach(p => ScoreBoards.Add(new ScoreBoard(p)));
            return this;
        }

        public Game Start()
        {
            this.Add();
            while (true)
            {
                Console.ReadLine();
                Action(Players.First(), Dice.Roll());

                RenderScreen();

                if (GameStateFinished())
                    return this;

                NextPlayer();
            }
        }

        private void Add()
        {
            Context.Set<Game>().Add(this);
            Context.SaveChanges();
            Console.WriteLine("Game successfully saved");
        }

        private void RenderScreen()
        {
            ScoreBoards.ForEach(s => s.Draw());
            Board.Draw();
        }

        private bool GameStateFinished()
        {
            Player winner = GetWinner();

            if (winner == null)
                return false;

            Console.WriteLine(winner.Name + " has won!");
            Console.ReadLine();
            return true;
        }

        public Player GetWinner() => Players.FirstOrDefault(x => x.Score == 4);

        private void Action(Player activePlayer, int result)
        {
            GameConsole.ConsolePrint(activePlayer, $"rolls a {result}");

            if (result == 6 && Board.Pieces.Any(p => !p.InPlay && p.Player == activePlayer && !p.Completed))
            {
                GameConsole.ConsolePrint(activePlayer, "puts a Piece into play");
                Board.PlacePiece(activePlayer);
            }
            else if (Board.Pieces.Any(p => p.InPlay && p.Player == activePlayer))
            {
                GameConsole.ConsolePrint(activePlayer, "moves a Piece");
                Board.MovePiece(activePlayer, result);
            }
            else
                GameConsole.ConsolePrint(activePlayer, "was unable to take action");
        }

        /// <summary>
        /// Throws exception if  more than 4 players
        /// </summary>
        private void GameStateReady()
        {
            if (Players.Count() > 4)
                throw new Exception("Four players or less is necessary to start.");
        }

        /// <summary>
        /// Turn succession 
        /// Next players turn (First in list)
        /// </summary>
        private void NextPlayer() => Players = Players.Skip(1).Concat(Players.Take(1)).ToList();

        private bool PlayerOfTypeExists(PlayerType playerType) => Players.Any(x => x.PlayerType == playerType);
    }
}
