using newGame.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newGame
{
    public class Tile: IDrawable, ICanMove
    {
        private static Dictionary<char, Rectangle> DictionaryTiles = new Dictionary<char, Rectangle>
        {
            {'W', new Rectangle(new Point(224, 0), new Size(47, 47))},
            {'.', new Rectangle(new Point(64, 0), new Size(47, 47))}
        };

        public Rectangle TileRectangleLocation;
        public Rectangle TileRectangleBit;
        public static Size SizeImage = new Size(100, 100);
        public static Image TilesImage = Resources.tiles;
        public char TileType;

        public Tile(char type, Point location)
        {
            TileType = type;
            TileRectangleLocation = new Rectangle(location, SizeImage);
            TileRectangleBit = DictionaryTiles[type];
        }

        public Rectangle GetRectangleLocation()
        {
            return TileRectangleLocation;
        }

        public Rectangle GetRectangleBit()
        {
            return TileRectangleBit;
        }

        public Image GetImage()
        {
            return TilesImage;
        }

        public void Move()
        {
            
        }

        public Rectangle GetPlayerRectangleLeftUpAngle()
        {
            return new Rectangle();
        }
    }
}
