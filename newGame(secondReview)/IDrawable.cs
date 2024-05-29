using System.Drawing;

namespace newGame
{
    public interface IDrawable
    {
        Rectangle GetRectangleLocation();
        Rectangle GetRectangleBit();    
        Image GetImage();
    }
}