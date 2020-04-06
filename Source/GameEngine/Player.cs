using GameEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace GameEngine
{
    [Table("Player")]
    public abstract class Player
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlayerID { get; set; }
        public string Name { get; set; }
        public int Score { get; set; } = 0;

        [NotMapped]
        public int StartX { get; set; }
        [NotMapped]
        public int StartY { get; set; }
        [NotMapped]
        public PlayerColor PlayerColor;
        [NotMapped]
        public string ColorName => GetType().ToString().Substring(11);
        [NotMapped]
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
    }

    public class BluePlayer : Player
    {
        public BluePlayer()
        {
            StartX = 1;
            StartY = 6;
            PlayerColor = PlayerColor.Blue;
        }
    }

    public class GreenPlayer : Player
    {
        public GreenPlayer()
        {
            StartX = 13; 
            StartY = 8;
            PlayerColor = PlayerColor.Green;
        }
    }

    public class RedPlayer : Player
    {
        public RedPlayer()
        {
            StartX = 8;
            StartY = 1;
            PlayerColor = PlayerColor.Red;
        }
    }

    public class YellowPlayer : Player
    {
        public YellowPlayer()
        {
            StartX = 6;
            StartY = 13;
            PlayerColor = PlayerColor.Yellow;
        }
    }
}
