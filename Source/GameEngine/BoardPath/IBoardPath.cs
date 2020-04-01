namespace GameEngine
{
    public interface IBoardPath
    {
        public int BoardPathID { get; set; }
        public BoardSquare[] BoardPath { get; }
    }
}
