using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newGame
{
    public static class CheckCollisions
    {
        public static bool CheckCollision(IDrawable mainItem, IDrawable secondItem)
        {
            var mainItemRectangle = mainItem.GetRectangleLocation();
            var secondItemRectangle = secondItem.GetRectangleLocation();
            return mainItemRectangle.IntersectsWith(secondItemRectangle);              
        }

        public static Point CheckStep(ICanMove mainItem, Point vectorSpeed) 
        {
            var newStep = new Point(vectorSpeed.X, vectorSpeed.Y);
            var mainRectangle = mainItem.GetPlayerRectangleLeftUpAngle();
            var rectangleX = new Rectangle(new Point(mainRectangle.Location.X + vectorSpeed.X, mainRectangle.Location.Y), mainRectangle.Size);
            var rectangleY = new Rectangle(new Point(mainRectangle.Location.X, mainRectangle.Location.Y + vectorSpeed.Y), mainRectangle.Size);          
            var walls = GameDraw.MyMap.GetTilesByRectangle(rectangleX);
            if (walls.Count > 0)
                newStep.X = 0;               
            walls = GameDraw.MyMap.GetTilesByRectangle(rectangleY);
            if (walls.Count > 0)
                newStep.Y = 0;        
            return newStep;
        }
    }
}
