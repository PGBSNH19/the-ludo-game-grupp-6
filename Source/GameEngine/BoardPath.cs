namespace GameEngine
{
    public abstract class BoardPath
    {
        public int BoardPathID { get; set; }
        public BoardSquare[] Path { get; set; }
        // Placeholder value
        internal readonly int _pathSize = 50;
    }

    public class RedBoardPath : BoardPath
    {
        public RedBoardPath() => Path = new BoardSquare[_pathSize];
    }

    public class BlueBoardPath : BoardPath
    {
        public BlueBoardPath() => Path = new BoardSquare[_pathSize];
    }

    public class GreenBoardPath : BoardPath
    {
        public GreenBoardPath() => Path = new BoardSquare[_pathSize];
    }

    public class YellowBoardPath : BoardPath
    {
        public YellowBoardPath() => Path = new BoardSquare[_pathSize];
    }
}
