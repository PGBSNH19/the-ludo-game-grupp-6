using GameEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace GameEngine
{
    public interface IPlayer
    {
        public int PlayerID { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public int GameID  { get; set; }
        public Game Game { get; set; }

        public int StartX { get; set; }
        public int StartY { get; set; }
        public PlayerColor PlayerColor { get; set; }
        public Path InnerPath { get; set; }

        public ConsoleColor GetColor()
        {
            return PlayerColor switch
            {
                PlayerColor.Red => ConsoleColor.Red,
                PlayerColor.Blue => ConsoleColor.Blue,
                PlayerColor.Green => ConsoleColor.Green,
                PlayerColor.Yellow => ConsoleColor.DarkYellow,
                _ => ConsoleColor.White
            };
        }

        public string ColorName() => GetType().ToString().Substring(11);
    }

    public class BluePlayer : IPlayer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlayerID { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        [ForeignKey("Game")]
        public int GameID { get; set; }
        public Game Game { get; set; }

        [NotMapped]
        public int StartX { get; set; }
        [NotMapped]
        public int StartY { get; set; }
        [NotMapped]
        public PlayerColor PlayerColor { get; set; }
        [NotMapped]
        public Path InnerPath { get; set; }

        public BluePlayer()
        {
            StartX = 1;
            StartY = 6;
            PlayerColor = PlayerColor.Blue;
        }
    }

    public class GreenPlayer : IPlayer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlayerID { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        [ForeignKey("Game")]
        public int GameID { get; set; }
        public Game Game { get; set; }

        [NotMapped]
        public int StartX { get; set; }
        [NotMapped]
        public int StartY { get; set; }
        [NotMapped]
        public PlayerColor PlayerColor { get; set; }
        [NotMapped]
        public Path InnerPath { get; set; }

        public GreenPlayer()
        {
            StartX = 13; 
            StartY = 8;
            PlayerColor = PlayerColor.Green;
        }
    }

    public class RedPlayer : IPlayer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlayerID { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        [ForeignKey("Game")]
        public int GameID { get; set; }
        public Game Game { get; set; }

        [NotMapped]
        public int StartX { get; set; }
        [NotMapped]
        public int StartY { get; set; }
        [NotMapped]
        public PlayerColor PlayerColor { get; set; }
        [NotMapped]
        public Path InnerPath { get; set; }

        public RedPlayer()
        {
            StartX = 8;
            StartY = 1;
            PlayerColor = PlayerColor.Red;
        }
    }

    public class YellowPlayer : IPlayer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlayerID { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        [ForeignKey("Game")]
        public int GameID { get; set; }
        public Game Game { get; set; }

        [NotMapped]
        public int StartX { get; set; }
        [NotMapped]
        public int StartY { get; set; }
        [NotMapped]
        public PlayerColor PlayerColor { get; set; }
        [NotMapped]
        public Path InnerPath { get; set; }

        public YellowPlayer()
        {
            StartX = 6;
            StartY = 13;
            PlayerColor = PlayerColor.Yellow;
        }
    }
}
