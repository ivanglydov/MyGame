using newGame.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace newGame
{
    public class MobEasy: IDrawable, ICanMove, IAmMob
    {
        public Rectangle MobEasyRectangleLocation;
        public Rectangle MobEasyRectangleBit = new Rectangle(new Point(5, 5), new Size(40, 40));
        public Point MobEasyLocation { get; private set; }
        public Point MobEasyLocationLeftUpAngle;
        public Image MobEasyImage = Resources.mob;
        public Size MobEasySize = new Size(50, 50);
        public static Point MobEasyVectorSpeed { get; private set; }
        public int MobEasySpeed = 1;
        public MobEasy(Point startPosition)
        {
            MobEasyLocationLeftUpAngle = startPosition;
            MobEasyLocation = new Point(startPosition.X + Map.LeftUpAngle.X, startPosition.Y + Map.LeftUpAngle.Y);
            MobEasyRectangleLocation = new Rectangle(MobEasyLocation, MobEasySize);
        }

        public Rectangle GetPlayerRectangleLeftUpAngle()
        {
            return new Rectangle(MobEasyLocation, new Size((MobEasySize.Width * 6 / 10), (MobEasySize.Height * 6 / 10)));
        }

        public void Move()
        {
            MobEasyVectorSpeed = new Point(0, 0);
            MobEasyMove();
            MobEasyVectorSpeed = PointMetods.MultiplyPoint(MobEasyVectorSpeed, MobEasySpeed);
            //MobEasyVectorSpeed = CheckCollisions.CheckStep(this, MobEasyVectorSpeed);
            var newPoint = PointMetods.SummPoint(MobEasyLocationLeftUpAngle, MobEasyVectorSpeed);
            MobEasyLocationLeftUpAngle = newPoint;
            MobEasyLocation = PointMetods.SummPoint(MobEasyLocationLeftUpAngle, Map.LeftUpAngle);
        }
        public void MobEasyMove()
        {
            var centerCoordinate = new Point
                (
                    -Map.LeftUpAngle.X + (int)(Form1.FormSize.Width / 2 - 50),
                    -Map.LeftUpAngle.Y + (int)(Form1.FormSize.Height / 2 - 50)
                );
            var myLocation = PointMetods.SubtractionPoint(MobEasyLocation, Map.LeftUpAngle);
            var nVector = PointMetods.SubtractionPoint(centerCoordinate, myLocation);
            nVector = new Point(nVector.X / ((nVector.X != 0)?Math.Abs(nVector.X): 1), nVector.Y / ((nVector.Y != 0) ? Math.Abs(nVector.Y) : 1));
            MobEasyVectorSpeed = nVector;
        }

        public Rectangle GetRectangleLocation()
        {
            return new Rectangle(MobEasyLocation, MobEasySize);
        }

        public Point GetVectorSpeed()
        {
            return MobEasyVectorSpeed;
        }

        public Rectangle GetRectangleBit()
        {
            return MobEasyRectangleBit;
        }

        public Image GetImage()
        {
            return MobEasyImage;
        }

        public Size GetSize()
        {
            return MobEasySize;
        }
    }
}
