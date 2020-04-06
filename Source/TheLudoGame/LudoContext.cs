using GameEngine;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TheLudoGame
{
    class LudoContext: DbContext
    {
        private IConfigurationRoot _configuration;
        
        public DbSet<Board> Board { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<RedPlayer> RedPlayer { get; set; }
        public DbSet<BluePlayer> BluePlayer { get; set; }
        public DbSet<GreenPlayer> GreenPlayer { get; set; }
        public DbSet<YellowPlayer> YellowPlayer { get; set; }
        public DbSet<Piece> Piece { get; set; }

        public LudoContext() { }

        public LudoContext(IConfigurationRoot configuration)
        {
            this._configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.EnableSensitiveDataLogging(true);
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
