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
        public string PlayerName { get; set; }
        public List<Piece> Pieces { get; set; }
        [NotMapped]
        public int StartX { get; set; }
        [NotMapped]
        public int StartY { get; set; }

        internal void PlacePiece(Board board)
        {
            board.Tiles.Where(t => t.X == StartX && t.Y == StartY).First().Visual = "X";
        } 
    }

    public class BluePlayer : Player
    {
        public BluePlayer()
        {
            StartX = 1;
            StartY = 6;
            Pieces = new List<Piece>();
            while(Pieces.Count() < 4) 
                Pieces.Add(new Piece { PieceColor = PieceColor.Blue });
        }
    }

    public class GreenPlayer : Player
    {
        public GreenPlayer()
        {
            StartX = 13; 
            StartY = 8;
            Pieces = new List<Piece>();
            while (Pieces.Count() < 4)
                Pieces.Add(new Piece { PieceColor = PieceColor.Green });
        }
    }

    public class RedPlayer : Player
    {
        public RedPlayer()
        {
            StartX = 8;
            StartY = 1;
            Pieces = new List<Piece>();
            while (Pieces.Count() < 4)
                Pieces.Add(new Piece { PieceColor = PieceColor.Red });
        }
    }

    public class YellowPlayer : Player
    {
        public YellowPlayer()
        {
            StartX = 6;
            StartY = 13;
            Pieces = new List<Piece>();
            while (Pieces.Count() < 4)
                Pieces.Add(new Piece { PieceColor = PieceColor.Yellow });
        }
    }
}
