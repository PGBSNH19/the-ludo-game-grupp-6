using GameEngine;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameEngine
{
    [Table("Player")]
    public abstract class Player
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlayerID { get; set; }
        public string PlayerName { get; set; }
        [NotMapped]
        public Path BoardPath { get; set; }
        public Point StartLocation { get; set; }
    }

    public class BluePlayer : Player
    {
        public BluePlayer()
        {
            BoardPath = new BlueBoardPath();
            StartLocation = new Point(1, 6);
        }
    }

    public class GreenPlayer : Player
    {
        public GreenPlayer()
        {
            BoardPath = new GreenBoardPath();
            StartLocation = new Point(13, 8);
        }
    }

    public class RedPlayer : Player
    {
        public RedPlayer()
        {
            BoardPath = new RedBoardPath();
            StartLocation = new Point(8, 1);
        }
    }

    public class YellowPlayer : Player
    {
        public YellowPlayer()
        {
            BoardPath = new YellowBoardPath();
            StartLocation = new Point(6, 13);
        }
    }
}
