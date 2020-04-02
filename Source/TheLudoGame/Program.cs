using System;
using System.IO;
using GameEngine;
using Microsoft.Extensions.Configuration;

namespace TheLudoGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.CursorVisible = false;
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
    }
}
