using GameEngine;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TheLudoGame.Context;
using TheLudoGame.Modules;

namespace TheLudoGame
{
    public class PresentationService : IHostedService
    {
        private readonly LudoContext ludoContext;
        public Game Game { get; set; }
        public GameConsole GameConsole { get; set; }
        public List<ScoreBoard> ScoreBoards { get; set; }

        public PresentationService(LudoContext ludoContext)
        {
            this.ludoContext = ludoContext;
            GameConsole = new GameConsole();
            ScoreBoards = new List<ScoreBoard>();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {

            ApplyGlobalAppSettings();

            // Start a game or load unsaved
            Game = new Game()
                .AddPlayer(new Player { PlayerType = PlayerType.Red, Name = "Anders" })
                .AddPlayer(new Player { PlayerType = PlayerType.Blue, Name = "Pierre" })
                .AddPlayer(new Player { PlayerType = PlayerType.Green, Name = "Nor" })
                .AddPlayer(new Player { PlayerType = PlayerType.Yellow, Name = "Oscar" })
                .Build()
                .Start();

            PopulateScoreBoards();

            SaveGame();

            while (true)
            {
                Console.ReadLine();

                int dice = Dice.Roll();
                GameConsole.ConsolePrint(Game.Players.First(), $"rolls a {dice}");
                Game.Action(dice);
                Game.DrawBoard();
                ScoreBoards.ForEach(s => s.Draw());


                if (Game.Finished())
                {
                    // UpdateFinished();
                    return Task.CompletedTask;
                }

                Game.NextPlayer();
                //Update();
            }
        }

        private void SaveGame() 
        {
            ludoContext.Game.Add(Game);
            ludoContext.SaveChanges();
        }

        void PopulateScoreBoards() => Game.Players.ForEach(p => ScoreBoards.Add(new ScoreBoard(p)));

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        private void ApplyGlobalAppSettings()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.CursorVisible = false;

            Console.WindowHeight = 45;
            Console.WindowWidth = 85;
            Console.BufferHeight = 45;
            Console.BufferWidth = 85;

            Console.Title = "TheLudoGame Group 6";
        }
    }
}
