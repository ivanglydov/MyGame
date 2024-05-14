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

        public GameDraw Drawing = new GameDraw();
        public List<IDataItem> Items = new List<IDataItem>();

        public Form1()
        {
            //FormBorderStyle = FormBorderStyle.None;
            Size = FormSize;
            StartPosition = FormStartPosition.CenterScreen;
            
            MyPlayer = new Player(Resources.gamer, new Size(50, 50), new Point(Width, Height));
            
            Items.Add(MyPlayer);
            GameDraw.Items.Enqueue(MyPlayer);
            
            Paint += Drawing.DrawMap;
            Paint += Drawing.Drawing;

            KeyDown += MyPlayer.PlayerMove;
            KeyUp += MyPlayer.PlayerUnMove;
            
            GameTimer.Tick += TimerTick;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }
        public void TimerTick(object sender, EventArgs e)
        {
            MetodMove();
            Invalidate();  
        }
        
        public void MetodMove()
        {
            foreach(var item in Items)
            {
                if (item is ICanMove)  
                    (item as ICanMove).Move();     
            }
        }

    }
}
