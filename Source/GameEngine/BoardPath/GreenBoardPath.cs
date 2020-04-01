namespace GameEngine.BoardPath
{
    public class GreenBoardPath : IBoardPath
    {
        public int BoardPathID { get; set; }
        public BoardSquare[] BoardPath { get; private set; }
    }
}