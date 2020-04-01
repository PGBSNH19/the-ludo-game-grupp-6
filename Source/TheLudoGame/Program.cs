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
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var context = new LudoContext(configuration);

            var game = new Game();

                game
                .AddPlayer(new RedPlayer { PlayerName = "Player Red" })
                .AddPlayer(new BluePlayer { PlayerName = "Player Blue" })
                .AddPlayer(new GreenPlayer { PlayerName = "Player Green" })
                .AddPlayer(new YellowPlayer { PlayerName = "Player Yellow" })
                .Start();

            Console.ReadLine();
        }
    }
}
