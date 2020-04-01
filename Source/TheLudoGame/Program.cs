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

            var game = new Game()
                .AddPlayer(new RedPlayer())
                .AddPlayer(new BluePlayer())
                .AddPlayer(new RedPlayer());

            Console.WriteLine(configuration.GetConnectionString("DefaultConnection"));
            Console.ReadLine();
        }
    }
}
