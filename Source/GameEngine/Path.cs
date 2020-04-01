namespace GameEngine
{
    public abstract class Path
    {
        public int BoardPathID { get; set; }
        public Point[] Points { get; set; }
        // Placeholder value
        internal readonly int _pathSize = 50;
    }

    public class RedBoardPath : Path
    {
        public RedBoardPath() => Points = new Point[_pathSize];
    }

    public class BlueBoardPath : Path
    {
        public BlueBoardPath() => Points = new Point[_pathSize];
    }

    public class GreenBoardPath : Path
    {
        public GreenBoardPath() => Points = new Point[_pathSize];
    }

    public class YellowBoardPath : Path
    {
        public YellowBoardPath() => Points = new Point[_pathSize];
    }
}
