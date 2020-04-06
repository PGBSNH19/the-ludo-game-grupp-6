using System;
using System.IO;
using GameEngine;
using Microsoft.Extensions.Configuration;

namespace TheLudoGame
{
    class Program
    {
        const int WINDOW_HEIGHT = 45;
        const int WINDOW_WIDTH = 85;
        const string TITLE = "TheLudoGame Group 6";

        static void Main(string[] args)
        {
            ApplyGlobalAppSettings();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var game = new Game()
                .AddPlayer(new Player { PlayerType = PlayerType.Red, Name = "Anders" })
                .AddPlayer(new Player { PlayerType = PlayerType.Blue, Name = "Pierre" })
                .AddPlayer(new Player { PlayerType = PlayerType.Green, Name = "Nor" })
                .AddPlayer(new Player { PlayerType = PlayerType.Yellow, Name = "Oscar" })
                .AddScoreBoards()
                .Build()
                .Start();

            Console.ReadLine();
        }

        private static void ApplyGlobalAppSettings()  
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.CursorVisible = false;

            Console.WindowHeight = WINDOW_HEIGHT;
            Console.WindowWidth = WINDOW_WIDTH;
            Console.BufferHeight = WINDOW_HEIGHT;
            Console.BufferWidth = WINDOW_WIDTH;

            Console.Title = TITLE;
        }
    }
}
