﻿using GameEngine;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLudoGame.Context;

namespace TheLudoGame.Modules
{
    public class Menu
    {
        private LudoContext ludoContext;

        public Menu(LudoContext ludoContext)
        {
            this.ludoContext = ludoContext;
        }

        public Game GameSelectionMenu()
        {
            string choice = String.Empty;

            while (UnsavedGameExists())
            {
                choice = GetChoice("Unsaved game exists. Want to load? [Y/N]");

                if (choice == "Y")
                {
                    Console.WriteLine("Successfully loaded game.");
                    var loadedGame = LoadGame();
                    loadedGame.Board.Build(loadedGame.Players);
                    Console.ReadLine();
                    return loadedGame;
                }
                if (choice == "N")
                {
                    Task.Run(() => CompleteGames()).Wait();
                    Console.WriteLine("All ongoing games moved to history.");
                    Console.ReadLine();
                }
            }

            var game = new Game()
                .New()
                .AddPlayer(new Player { PlayerType = PlayerType.Red, Name = "Player one" })
                .AddPlayer(new Player { PlayerType = PlayerType.Blue, Name = "Player two" })
                .AddPlayer(new Player { PlayerType = PlayerType.Green, Name = "Player three" })
                .AddPlayer(new Player { PlayerType = PlayerType.Yellow, Name = "Player four" })
                .Build();
            SaveGame(game);

            return game;
        }

        private void SaveGame(Game game)
        {
            game.LastAction = DateTime.Now;
            ludoContext.Game.Add(game);
            ludoContext.SaveChanges();
        }

        internal void PrintMenuLogo() => Console.WriteLine(@"
    ______  ___      _____             ______  ___                   
    ___   |/  /_____ ___(_)______      ___   |/  /_______________  __
    __  /|_/ /_  __ `/_  /__  __ \     __  /|_/ /_  _ \_  __ \  / / /
    _  /  / / / /_/ /_  / _  / / /     _  /  / / /  __/  / / / /_/ / 
    /_/  /_/  \__,_/ /_/  /_/ /_/      /_/  /_/  \___//_/ /_/\__,_/  
                                                                 
        ");

        internal void GameHistoryView() =>
            ludoContext.Game.Include(p => p.Players).Where(g => g.Completed == true)
                .ToList()
                .ForEach(g => 
                {
                    Console.WriteLine($"ID: {g.GameID}\t Last action: {g.LastAction} \t Players: {g.Players.Count}");
                });

        private async Task CompleteGames()
        {
            var games = ludoContext.Game.Where(g => g.Completed == false).ToList();
            games.ForEach(g => {
                g.Completed = true;
                ludoContext.Entry(g).Property("Completed").IsModified = true;
            });
            await ludoContext.SaveChangesAsync();
        }

        private Game LoadGame() => 
            ludoContext.Game
                .Include(b => b.Board)
                .ThenInclude(p => p.Pieces)
                .ThenInclude(a => a.Player)
                .FirstOrDefault(g => g.Completed == false);

        private bool UnsavedGameExists() => ludoContext.Game.Any(g => g.Completed == false);

        private string GetChoice(string prompt)
        {
            string choice = string.Empty;
            while (!(choice == "N" || choice == "Y"))
            {
                Console.WriteLine(prompt);
                choice = Console.ReadLine().ToUpper();
            }
            return choice;
        }
    }
}
