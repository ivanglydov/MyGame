using newGame.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace newGame
{   
    public class Map
    {
        public static Point LeftUpAngle = new Point(100,100);
        public int TilesCount = 5;
        public int TileLength;
        
        public Map()
        {
            TileLength = Form1.FormSize.Width / TilesCount;
        }

        public Tile GetTileByPosition(Point mapCoordinate, Point location)
        {
            if (mapCoordinate.Y < 0 || mapCoordinate.Y > MyMap.Count - 1 ||
                mapCoordinate.X < 0 || mapCoordinate.X > MyMap[0].Length - 1)
                return new Tile('W', location);
            return new Tile(MyMap[mapCoordinate.Y][mapCoordinate.X], location);
        }

        public Tile GetTileByPoint(Point point)
        {
            var y =  -(point.Y)/ TileLength;
            var x = -(point.X) / TileLength;
            var location = new Point(LeftUpAngle.X + x * TileLength, LeftUpAngle.Y + y * TileLength);
            var tilePosition = GetTileByPosition(new Point(x, y), location);
            return tilePosition;
        }

        public List<Tile> GetTilesByRectangle(Rectangle rectangle)
        {
            var listWall = new List<Tile>();
            var listAnglePoint = new List<Point> 
            {
                new Point(rectangle.Left , rectangle.Top ),
                new Point(rectangle.Right, rectangle.Top ),
                new Point(rectangle.Left , rectangle.Bottom ),
                new Point(rectangle.Right, rectangle.Bottom )
            };
            foreach(var anglePoint in listAnglePoint)
            {
                var tile = GetTileByPoint(anglePoint);
                if(tile.TileType == 'W')
                    listWall.Add(tile);
            }
            return listWall;
        }
        
        //W - стена
        //. - плитка
        //
        public static List<string> MyMap = new List<string>
        {

            "WWWWWWWWW",
            "W........",
            "W..W.W.WW",
            "W........",
            "W..W.....",
            "W....W.W.",
            "WWWW..W..",
            "W..W.WW..",
            "W........"
        }; 
    }
}
