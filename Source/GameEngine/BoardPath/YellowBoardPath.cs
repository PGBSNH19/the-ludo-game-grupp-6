namespace GameEngine.BoardPath
{
    public class YellowBoardPath : IBoardPath
    {
        public int BoardPathID { get; set; }
        public BoardSquare[] BoardPath { get; private set; }
    }
}
