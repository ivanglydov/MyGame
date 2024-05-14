using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace newGame
{
    public enum DirectionNames
    {
        Left,
        LeftUp,
        Up,
        RightUp,
        Right,
        RightDown,
        Down,
        LeftDown
    }
    public static class Moving
    {
        public static Dictionary<DirectionNames, Point> Steps =
            new Dictionary<DirectionNames, Point>
            {
                {DirectionNames.Left, new Point(-1, 0)},
                {DirectionNames.LeftUp, new Point(-1, -1)},
                {DirectionNames.Up, new Point(0, -1)},
                {DirectionNames.RightUp, new Point(1, -1)},
                {DirectionNames.Right, new Point(1, 0)},
                {DirectionNames.RightDown, new Point(1, 1)},
                {DirectionNames.Down, new Point(0, 1)},
                {DirectionNames.LeftDown, new Point(-1, 1)}
            };
        public static Dictionary<Keys, DirectionNames> Directions =
            new Dictionary<Keys, DirectionNames>
            {
                {Keys.W, DirectionNames.Down },
                {Keys.A, DirectionNames.Right },
                {Keys.S, DirectionNames.Up },
                {Keys.D, DirectionNames.Left }
            };

        
    }
}
