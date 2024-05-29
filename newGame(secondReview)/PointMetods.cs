using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newGame
{
    public static class PointMetods
    {
        public static Func<Point, Point, Point> SummPoint =
            (firstPoint, secondPoint) =>
            {
                var newPoint = new Point();
                newPoint.X = firstPoint.X + secondPoint.X;
                newPoint.Y = firstPoint.Y + secondPoint.Y;
                return newPoint;
            };

        public static Func<Point, Point, Point> SubtractionPoint =
            (firstPoint, secondPoint) =>
            {
                var newPoint = new Point();
                newPoint.X = firstPoint.X - secondPoint.X;
                newPoint.Y = firstPoint.Y - secondPoint.Y;
                return newPoint;
            };

        public static Func<Point, int, Point> MultiplyPoint =
            (firstPoint, constant) =>
            {
                var newPoint = new Point();
                newPoint.X = firstPoint.X * constant;
                newPoint.Y = firstPoint.Y * constant;
                return newPoint;
            };
    }
}
