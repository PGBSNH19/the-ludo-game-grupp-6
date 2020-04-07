using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GameEngine
{
    public class LudoContext : DbContext
    {
        private IConfigurationRoot _configuration;

        public DbSet<Game> Game { get; set; }
        public DbSet<Player> Player { get; set; }
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
            var playerTypeConverter = new EnumToNumberConverter<PlayerType, int>();

            modelBuilder.Entity<Player>(entity =>
            {
                entity.Property(e => e.PlayerType)
                    .HasConversion(playerTypeConverter)
                    .HasDefaultValueSql("((0))");

            });
            base.OnModelCreating(modelBuilder);
        }

    }
}
