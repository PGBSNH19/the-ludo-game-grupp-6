using System;
using System.IO;
using GameEngine;
using Microsoft.Extensions.Configuration;

namespace TheLudoGame
{
    class Program
    {
        const int WINDOW_HEIGHT = 40;
        const int WINDOW_WIDTH = 90;
        const string TITLE = "TheLudoGame Group 6";

        static void Main(string[] args)
        {
            ApplyGlobalAppSettings();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var context = new LudoContext(configuration);

            var game = new Game()
                .AddPlayer(new RedPlayer { Name = "Player Red" })
                .AddPlayer(new BluePlayer { Name = "Player Blue" })
                .AddPlayer(new GreenPlayer { Name = "Player Green" })
                .AddPlayer(new YellowPlayer { Name = "Player Yellow" })
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
