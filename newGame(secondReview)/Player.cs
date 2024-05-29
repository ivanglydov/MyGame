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
    public class Player: IDrawable, ICanMove, IAmPlayer
    {
        public Rectangle PlayerRectangleLocation;
        public Rectangle PlayerRectangleBit = new Rectangle(new Point(0, 0), new Size(700, 700));
        public Point PlayerLocation { get; private set; }
        public Image PlayerImage { get; private set; }
        public Size PlayerSize { get; private set; }
        public static Dictionary<Keys, bool> PlayerDataMove = new Dictionary<Keys, bool>
            {
                {Keys.W, false },
                {Keys.S, false },
                {Keys.A, false },
                {Keys.D, false }
            };
        public static Point PlayerVectorSpeed { get; private set; }
        public int PlayerSpeed = 5;
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
        }

        public Rectangle GetPlayerRectangleLeftUpAngle()
        {           
            var location = PointMetods.SubtractionPoint(Map.LeftUpAngle, new Point(PlayerLocation.X + (PlayerSize.Width * 9 / 10), PlayerLocation.Y + (PlayerSize.Height* 9 / 10)));          
            return new Rectangle(location, new Size((PlayerSize.Width * 6 / 10), (PlayerSize.Height * 6 / 10)));
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
            PlayerVectorSpeed = CheckCollisions.CheckStep(this, PlayerVectorSpeed);

            var newPoint = PointMetods.SummPoint(Map.LeftUpAngle, PlayerVectorSpeed);
            Map.LeftUpAngle = newPoint;

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

        public void Shoot(object sender, EventArgs e)
        {
            var bullet1 = new Bullet(new Point(0, 25), new Point(1, 0));
            var bullet2 = new Bullet(new Point(10, 25), new Point(-1, 0));
            Form1.Items.Add(bullet1);
            Form1.Items.Add(bullet2);
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
    }  
}
