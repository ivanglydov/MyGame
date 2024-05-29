using newGame.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace newGame
{
    public partial class Form1 : Form
    {
        public static Player MyPlayer;
        public static Size FormSize = new Size(500, 500);
        public Timer GameTimer = new Timer
        {
            Enabled = true,
            Interval = 1000 / 60
        };
        public Timer TimerShoot = new Timer
        {
            Enabled = true,
            Interval = 1000
        };
        public Timer TimerSpawn = new Timer
        {
            Enabled = true,
            Interval = 3000
        };
        public GameDraw Drawing = new GameDraw();
        public static List<IDrawable> Items = new List<IDrawable>();
        public List<MobEasy> Mobs;

        public Form1()
        {
            FormBorderStyle = FormBorderStyle.None;
            Size = FormSize;
            StartPosition = FormStartPosition.CenterScreen;           
            MyPlayer = new Player(Resources.gamer, new Size(50, 50), new Point(Width, Height));
            Mobs = new List<MobEasy>();          
            Items.Add(MyPlayer);     
            Paint += Drawing.DrawMap;
            Paint += Drawing.Drawing;
            KeyDown += MyPlayer.PlayerMove;
            KeyUp += MyPlayer.PlayerUnMove;
            TimerShoot.Tick += MyPlayer.Shoot;
            GameTimer.Tick += TimerTick;
            TimerSpawn.Tick += TimerSpawnMobs;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }
        public void TimerTick(object sender, EventArgs e)
        {
            MetodMove();
            Invalidate();
        }

        
        public void TimerSpawnMobs(object sender, EventArgs e)
        {           
            var r = new Random();
            for(var i = 0; i < 2; i++)
            {
                var x = r.Next(-400 + 1400 * (i % 2), -10 + 1400 * (i % 2));
                var y = r.Next(-400, 1000);

                Mobs.Add(new MobEasy(new Point(x, y)));
                Items.Add(Mobs[Mobs.Count - 1]);
            }
            for (var i = 0; i < 2; i++)
            {
                var y = r.Next(-400 + 1400 * (i % 2), -10 + 1400 * (i % 2));
                var x = r.Next(-400, 1000);

                Mobs.Add(new MobEasy(new Point(x, y)));
                Items.Add(Mobs[Mobs.Count - 1]);
            }
            if(TimerSpawn.Interval > 300)
                TimerSpawn.Interval -= 100;
        }
        
        public void MetodMove()
        {
            foreach(var item in Items)
            {
                if (item is ICanMove)  
                    (item as ICanMove).Move();     
            }
            var listRemove = new List<IDrawable>();
            foreach(var item in Items)
            {
                if (item is IAmMob)
                {
                    if(CheckCollisions.CheckCollision(MyPlayer, item))
                        this.Close();

                    foreach (var bullet in Items)
                    {
                        if (bullet is IAmBullet)
                        {
                            if(Math.Abs(bullet.GetRectangleLocation().Location.X) > 1500 ||
                                Math.Abs(bullet.GetRectangleLocation().Location.Y) > 1500)
                                listRemove.Add(bullet);
                            if (CheckCollisions.CheckCollision(bullet, item))
                            {
                                listRemove.Add(bullet);
                                listRemove.Add(item);
                            }
                        }   
                    }
                }
            }
            foreach (var t in listRemove)
                Items.Remove(t);
        }

    }
}
