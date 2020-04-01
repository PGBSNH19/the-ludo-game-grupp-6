namespace GameEngine.BoardPath
{
    public class BlueBoardPath : IBoardPath
    {
        public int BoardPathID { get; set; }
        public BoardSquare[] BoardPath { get; private set; }
    }
}
