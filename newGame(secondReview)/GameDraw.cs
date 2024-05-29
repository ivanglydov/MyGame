using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace newGame
{
    public class GameDraw
    {   
        public static Map MyMap = new Map();
        public void Drawing(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            foreach (var i in Form1.Items)
            {
                if (i is IDrawable)
                {
                    var item = i as IDrawable;
                    g.DrawImage(item.GetImage(), item.GetRectangleLocation(), item.GetRectangleBit(), GraphicsUnit.Pixel);
                }
            }
        }
        public void DrawMap(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;

            for (var i = (int)-Map.LeftUpAngle.Y / MyMap.TileLength - 1; i < MyMap.TilesCount + (int)-Map.LeftUpAngle.Y/ MyMap.TileLength + 1; i++)
            {
                for (var j = (int)-Map.LeftUpAngle.X / MyMap.TileLength - 1; j < MyMap.TilesCount + (int)-Map.LeftUpAngle.X / MyMap.TileLength + 1; j++)
                { 
                    var tile = MyMap.GetTileByPosition(new Point(j, i), new Point(Map.LeftUpAngle.X + j * MyMap.TileLength, Map.LeftUpAngle.Y + i * MyMap.TileLength));
                    g.DrawImage(Tile.TilesImage, tile.TileRectangleLocation, tile.TileRectangleBit, GraphicsUnit.Pixel);
                }
            }
        }
    }
}
