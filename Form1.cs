using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;

namespace flappiebird {
    public partial class Form1 : Form {
        bool botsing;
        int score;
        int afstandHorizontaal, afstandVerticaal;
        string gamestatus;
        int ybird;
        int pastijd;
        Bitmap achtergrond, imgbuisboven, imgbuisonder, imgbird;
        Random rnd;
        Graphics g;
        Rectangle rbird;
        Rectangle[] buisboven, buisonder;
        //zekjfgqoekrlgjsmeorgijeroîgj
        private void Tmrachtergrond_Tick(object sender, EventArgs e) {
            toonbuizen();
            pastijd++;
            changebg();
            Console.WriteLine("pasde tijd: "+pastijd);
            pnlgame.Invalidate();
        }

        private void changebg()
        {
            if (pastijd <= 50)
            {
                achtergrond = new Bitmap("media/bg.jpg");
                pnlgame.BackgroundImageLayout = ImageLayout.Stretch;
            }            
            else if (pastijd <= 100)
            {
                achtergrond = new Bitmap("media/bg2.jpg");
                pnlgame.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else if (pastijd <= 150)
            {
                achtergrond = new Bitmap("media/bg3.jpg");
                pnlgame.BackgroundImageLayout = ImageLayout.Stretch;
            }
            if (pastijd >= 200) pastijd = 0;
        }

        private void toonbuizen() {
            ybird += 5;
            if (buisboven[0].X <=0-imgbuisonder.Width-afstandHorizontaal) {
                score += 2;
                maakbuizen(pnlgame.Width - rnd.Next(50, 120));
            } else {
                for (int i = 0; i < buisboven.Length; i++) {
                    buisboven[i].X -= 20;
                    buisonder[i].X -= 20;
                }
            }
        }

        private void Tmrgame_Tick(object sender, EventArgs e) {
            for (int i = 0; i < buisonder.Length; i++) {
                botsing = buisonder[i].IntersectsWith(rbird) || buisboven[i].IntersectsWith(rbird) || (ybird + 40) > pnlgame.Height;
                if (botsing) break;
            }
            if (botsing) {
                tmrgame.Stop();
                tmrachtergrond.Stop();
                gamestatus = "Game Over";
            } else {
                ybird += rnd.Next(-2, 6);
                pnlgame.Invalidate();
            }
        }

        private void stijgen(object sender, EventArgs e) {
            ybird -= 35;
            pnlgame.Invalidate();
        }

        private void allesWeergeven(object sender, PaintEventArgs e) {
            g = e.Graphics;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(achtergrond, new Rectangle(0, 0, 6500, 5000), 0, 0, pnlgame.Width, pnlgame.Height, GraphicsUnit.Millimeter, null);
            for (int i = 0; i < buisonder.Length; i++) {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(imgbuisboven, buisboven[i], 0, 0, imgbuisboven.Width, imgbuisboven.Height, GraphicsUnit.Pixel, null);
                g.DrawRectangle(new Pen(Color.Red), buisboven[i]);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(imgbuisonder, buisonder[i], 0, 0, imgbuisonder.Width, imgbuisonder.Height, GraphicsUnit.Pixel, null);
                g.DrawRectangle(new Pen(Color.Red), buisonder[i]);
            }
            //vogel
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            rbird = new Rectangle(80, ybird, 60, 40);
            g.DrawImage(imgbird, rbird, -5, -3, 60, 60, GraphicsUnit.Millimeter, null);
            g.DrawRectangle(new Pen(Color.Red), rbird);
            Font fn = new Font("Callibri", 24, FontStyle.Bold);
            g.DrawString(gamestatus, fn, new SolidBrush(Color.Yellow), rbird.X + 70, rbird.Y);
            g.DrawString(score.ToString(), fn, new SolidBrush(Color.Yellow), 30, 50);
        }

        public Form1() {
            InitializeComponent();
            gameitemsconfig();
        }
        private void Button1_Click(object sender, EventArgs e) {
            pastijd = 0;
            gameitemsconfig();
            tmrachtergrond.Start();
            tmrgame.Start();
        }
        private void gameitemsconfig() {
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty|BindingFlags.Instance | BindingFlags.NonPublic, null, pnlgame, new object[] {true});
            botsing = false;
            rnd = new Random();
            score = 0;
            gamestatus = "";
            afstandHorizontaal = 330;
            afstandVerticaal = 110;
            changebg();
            imgbuisboven = new Bitmap("media/buisonder.png");
            imgbuisboven.MakeTransparent();
            imgbuisonder = new Bitmap("media/buisboven.png");
            imgbuisonder.MakeTransparent();
            buisboven = new Rectangle[2];
            buisonder = new Rectangle[2];
            maakbuizen(600);
            imgbird = new Bitmap("media/bird4.png");
            imgbird.MakeTransparent();
            ybird = pnlgame.Height / 2;
        }

        private void maakbuizen(int beginx) {
            int[] hoogtenieuwpaar = new int[] { 0, rnd.Next(20, 70) };
            for (int i = 0; i < buisboven.Length; i++) {
                int ybegin = -60 + hoogtenieuwpaar[i];
                //rectangle (pos x, pos y, breedte, hoogte)
                buisonder[i] = new Rectangle(beginx + (afstandHorizontaal * i), ybegin, imgbuisonder.Width, imgbuisonder.Height);
                buisboven[i] = new Rectangle(beginx + (afstandHorizontaal * i), ybegin+ afstandVerticaal + imgbuisonder.Height, imgbuisboven.Width, imgbuisboven.Height);
            }
            Console.WriteLine(buisonder[0].Y + ' ' + buisonder[1].Y);
        }
    }
}