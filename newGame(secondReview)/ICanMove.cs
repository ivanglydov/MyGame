using System.Drawing;

namespace newGame
{
    public interface ICanMove
    {
        void Move();
        Rectangle GetPlayerRectangleLeftUpAngle();
    }
}