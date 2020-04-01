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
    }

    public class BluePlayer : Player
    {
        public BluePlayer()
        {
            BoardPath = new BlueBoardPath();
        }
    }

    public class GreenPlayer : Player
    {
        public GreenPlayer()
        {
            BoardPath = new GreenBoardPath();
        }
    }

    public class RedPlayer : Player
    {
        public RedPlayer()
        {
            BoardPath = new RedBoardPath();
        }
    }

    public class YellowPlayer : Player
    {
        public YellowPlayer()
        {
            BoardPath = new YellowBoardPath();
        }
    }
}
