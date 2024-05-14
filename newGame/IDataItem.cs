using System.Drawing;

namespace newGame
{
    public interface IDataItem
    {
        Rectangle GetRectangleLocation();

        Rectangle GetRectangleBit();
        
        Image GetImage();
        
        
        
    }
}