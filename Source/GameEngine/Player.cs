using GameEngine.BoardPath;

namespace GameEngine
{
    public abstract class Player
    {
        public int PlayerID { get; set; }
        public string PlayerName { get; set; }
        public IBoardPath BoardPath { get; set; }
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
