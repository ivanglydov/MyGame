using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static newGame.Program;

namespace newGame
{

    

    public class Player: IDataItem, ICanMove
    {
        public Rectangle PlayerRectangleLocation;
        public Rectangle PlayerRectangleBit;
        public Point PlayerLocation { get; private set; }
        public Image PlayerImage { get; private set; }
        public Size PlayerSize { get; private set; }
        public DirectionNames PlayerDirection { get; private set; }
        public static Dictionary<Keys, bool> PlayerDataMove;
        public static Point PlayerVectorSpeed { get; private set; }
        public int PlayerSpeed = 10;
        public PictureBox PlayerPictureBox;
        public Player(Image playerImage, Size playerSize, Point startPosition)
        {
            
            PlayerImage = playerImage;
            PlayerSize = playerSize;
            PlayerLocation = new Point
            (
                startPosition.X / 2 - playerSize.Width,
                startPosition.Y / 2 - playerSize.Height
            );
            PlayerRectangleLocation = new Rectangle(PlayerLocation, PlayerSize);
            PlayerRectangleBit = new Rectangle(new Point(0, 0), new Size(700,700));
            PlayerDataMove = new Dictionary<Keys, bool>
            {
                {Keys.W, false },
                {Keys.S, false },
                {Keys.A, false },
                {Keys.D, false }
            };
            
            PlayerPictureBox = new PictureBox
            {
                Image = PlayerImage,
                //BackColor = Color.Transparent,
                Size = playerSize,
                Location = new Point
                (
                    
                ),
                SizeMode = PictureBoxSizeMode.StretchImage
            };

        }
        public Rectangle GetRectangleLocation()
        {
            return PlayerRectangleLocation;
        }
        public Point GetVectorSpeed()
        {
            return new Point(0, 0);
        }

        public Rectangle GetRectangleBit()
        {
            return PlayerRectangleBit;
        }

        public Image GetImage()
        {
            return PlayerImage;
        }

        public Size GetSize()
        {
            return PlayerSize;
        }

        public Point CheckCoordinate(Point newPoint)
        {
            var point = new Point(newPoint.X, newPoint.Y);
            if (point.X > Map.MaxCriticalLeftUpAngle.X)
                point.X = Map.MaxCriticalLeftUpAngle.X;
            else if(point.X < Map.MinCriticalLeftUpAngle.X)
                point.X = Map.MinCriticalLeftUpAngle.X;

            if (point.Y > Map.MaxCriticalLeftUpAngle.Y)
                point.Y = Map.MaxCriticalLeftUpAngle.Y;
            else if (point.Y < Map.MinCriticalLeftUpAngle.Y)
                point.Y = Map.MinCriticalLeftUpAngle.Y;
            return point;
        }

        public void Move()
        {
            PlayerVectorSpeed = new Point(0, 0);
            foreach(var key in PlayerDataMove.Keys)
            {
                if (PlayerDataMove[key])
                    PlayerVectorSpeed = PointMetods.SummPoint(PlayerVectorSpeed, Moving.Steps[Moving.Directions[key]]);
            }
            PlayerVectorSpeed = PointMetods.MultiplyPoint(PlayerVectorSpeed , PlayerSpeed);
            var newPoint = PointMetods.SummPoint(Map.LeftUpAngle, PlayerVectorSpeed);
            var t = CheckCoordinate(newPoint);
            Map.LeftUpAngle = t;
            GameDraw.Items.Enqueue(this);
        }
        public void PlayerMove(object sender, KeyEventArgs e)
        {
            if (PictureMove.IsMove(e.KeyData))
                PlayerDataMove[e.KeyData] = true;
                
        }
        public void PlayerUnMove(object sender, KeyEventArgs e)
        {
            if (PictureMove.IsMove(e.KeyData))
                PlayerDataMove[e.KeyData] = false;
        }
    }
    
}
