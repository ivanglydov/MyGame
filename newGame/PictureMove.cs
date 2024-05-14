using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace newGame
{
    public static class PictureMove
    {

        public static void Move(PictureBox item, DirectionNames direction, int speed)
        {
            var step = PointMetods.MultiplyPoint(Moving.Steps[direction], speed);
            item.Location = PointMetods.SummPoint(item.Location, step);
            


        }
        public static bool IsMove(Keys key)
        {
            return key == Keys.W || key == Keys.A || key == Keys.S || key == Keys.D;
        }
    }
}
