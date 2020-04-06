using System.Collections.Generic;
using System.IO;

namespace GameEngine
{
    public abstract class Path
    {
        public List<Tile> Tiles { get; set; }
        public string PathUrl { get; set; }

        public Path() => Tiles = new List<Tile>();

        public Path Build()
        {
            var pathList = File.ReadAllLines(PathUrl);
            foreach(var data in pathList)
            {
                var tileData = data.Split(',');
                var tile = new Tile
                {
                    X = int.Parse(tileData[0]),
                    Y = int.Parse(tileData[1])
                };
                tile.SetColor(tileData[2]);

                Tiles.Add(tile);
            }
            return this;
        }
    }

    public class OuterPath : Path
    {
        public OuterPath()
        {
            PathUrl = "Paths/outer_path_coords.txt";
        }
    }

    public class RedInnerPath : Path
    {
        public RedInnerPath()
        {
            PathUrl = "Paths/red_path_coords.txt";
        }
    }

    public class BlueInnerPath : Path
    {
        public BlueInnerPath()
        {
            PathUrl = "Paths/blue_path_coords.txt";
        }
    }

    public class GreenInnerPath : Path
    {
        public GreenInnerPath()
        {
            PathUrl = "Paths/green_path_coords.txt";
        }
    }

    public class YellowInnerPath : Path
    {
        public YellowInnerPath()
        {
            PathUrl = "Paths/yellow_path_coords.txt";
        }
    }
}
