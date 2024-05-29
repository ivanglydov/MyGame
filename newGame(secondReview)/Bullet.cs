using newGame.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newGame
{
    public class Bullet: IDrawable, ICanMove, IAmBullet
    {
        public Rectangle BulletRectangleLocation;
        public Rectangle BulletRectangleBit = new Rectangle(new Point(0, 0), new Size(20, 20));
        public Point BulletLocation { get; private set; }
        public Point BulletLocationLeftUpAngle;
        public Image BulletImage = Resources.bullet;
        public Size BulletSize = new Size(20, 20);
        public Point BulletVectorSpeed { get; private set; }
        public int BulletSpeed = 20;
        public Bullet(Point startPosition, Point vectorSpeed)
        {
            BulletLocationLeftUpAngle = new Point
                (
                    -Map.LeftUpAngle.X + (int)(Form1.FormSize.Width / 2 - 50 + startPosition.X),
                    -Map.LeftUpAngle.Y + (int)(Form1.FormSize.Height / 2 - 50+ startPosition.Y)
                ); ; 
            BulletVectorSpeed = PointMetods.MultiplyPoint(vectorSpeed, BulletSpeed);
            BulletLocation = new Point(BulletLocationLeftUpAngle.X + Map.LeftUpAngle.X, BulletLocationLeftUpAngle.Y + Map.LeftUpAngle.Y);
            BulletRectangleLocation = new Rectangle(BulletLocation, BulletSize);
        }

        public Rectangle GetPlayerRectangleLeftUpAngle()
        {
            return new Rectangle(BulletLocation, new Size(BulletSize.Width, BulletSize.Height));
        }

        public void Move()
        {
            var newPoint = PointMetods.SummPoint(BulletLocationLeftUpAngle, BulletVectorSpeed);
            BulletLocationLeftUpAngle = newPoint;
            BulletLocation = PointMetods.SummPoint(BulletLocationLeftUpAngle, Map.LeftUpAngle);
        }
       
        public Rectangle GetRectangleLocation()
        {
            return new Rectangle(BulletLocation, BulletSize);
        }

        public Point GetVectorSpeed()
        {
            return BulletVectorSpeed;
        }

        public Rectangle GetRectangleBit()
        {
            return BulletRectangleBit;
        }

        public Image GetImage()
        {
            return BulletImage;
        }

        public Size GetSize()
        {
            return BulletSize;
        }
    }
}
