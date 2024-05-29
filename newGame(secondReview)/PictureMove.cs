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
        public static bool IsMove(Keys key)
        {
            return key == Keys.W || key == Keys.A || key == Keys.S || key == Keys.D;
        }
    }
}
