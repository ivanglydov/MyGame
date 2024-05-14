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
        public static Point LeftUpAngle = new Point(-50,-50);
        public static Point MinCriticalLeftUpAngle = new Point(-749, -749);
        public static Point MaxCriticalLeftUpAngle = new Point(0, 0);
        public int TilesCount = 5;
        public int TileLength;
        
        public Map()
        {
            TileLength = Form1.FormSize.Width / TilesCount;
        }

        public Tile GetTileByPosition(Point mapCoordinate, Point location)
        {
            return new Tile(MyMap[mapCoordinate.Y][mapCoordinate.X], location);
        }
        
        //W - стена
        //. - плитка
        //
        public static List<string> MyMap = new List<string>
        {
            "WWWWWWWWWWWWW",
            "WWWWWWWWWWWWW",
            "WW........WWW",
            "WW........WWW",
            "WW........WWW",
            "WW........WWW",
            "WW........WWW",
            "WW........WWW",
            "WW........WWW",
            "WW........WWW",
            "WWWWWWWWWWWWW",
            "WWWWWWWWWWWWW",
            "WWWWWWWWWWWWW"

        };
        
    }
}
