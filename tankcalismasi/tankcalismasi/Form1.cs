using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace tankcalismasi
{
    public partial class Form1 : Form
    {
        Recrangel[] re = new Recrangel[10];
        gun guner;
        public Form1()
        {
            this.SetStyle(
               System.Windows.Forms.ControlStyles.UserPaint |
               System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
               System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
               true);
            InitializeComponent();
            re[0] = new Recrangel(500, 500);
            Random r = new Random();
            for (int i=1;i< enemynumber; i++) {
                re[i] = new Recrangel(r.Next(0, 500), r.Next(0, 500));
            }
            timer1.Dispose();
            timer1.Start();
            //Recrangel
            Paint += Form1_Paint;
            KeyDown += Form1_KeyDown;
        }
        int enemynumber =3;

        private void guncrative(object sender, PaintEventArgs e)
        {
            re[0].bullet[0].drawRecrangel(e);
            if (Math.Abs(re[0].bullet[0].x) == 800 || Math.Abs(re[0].bullet[0].y) == 800)
            {
                  timer.Dispose();
                Cansqueeze = true;
            }
        }
        bool Cansqueeze = true;
        private void gunmoving(object sender, EventArgs e)
        {
            re[0].bullet[0].gunmov();
            for (int i =1;i<enemynumber;i++) {
                if ((re[0].bullet[0].x - 10) < re[i].x && re[i].x < (re[0].bullet[0].x + 10) && (re[0].bullet[0].y - 10) < re[i].y && re[i].y < (re[0].bullet[0].y + 10))
                {
                    re[i].islive = false;
                }
            }
            Refresh();
            Application.DoEvents();

        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue==(int)Keys.Space) {
                if (Cansqueeze) {
                    re[0].bullet[0] = null;
                    guner = new gun(re[0].x, re[0].y, 10);
                    Paint += guncrative;
                    re[0].setbullet(guner);
                    re[0].bullet[0].gunmove(re[0]);
                    timer.Dispose();
                    timer.Start();
                    Cansqueeze = false;
                }
            }
            re[0].movekeylistener(e);
            Refresh();
            Application.DoEvents();

        }
      
        public void enemygun() {
          
            re[gunkey].bullet[0] = null;
            guner = new gun(re[gunkey].x, re[gunkey].y, 10);
            Paint += enemygundraw; 
            re[gunkey].setbullet(guner);
            re[gunkey].bullet[0].gunmove(re[gunkey]);
            timer2.Dispose();
            timer2.Start();
            
        }
        int firestart = 1;
        private void enemygundraw(object sender, PaintEventArgs e)
        {
          
            if (Math.Abs(re[gunkey].bullet[0].x) > 800 || Math.Abs(re[gunkey].bullet[0].y) > 800 || Math.Abs(re[gunkey].bullet[0].x) <0 || Math.Abs(re[gunkey].bullet[0].y) < 0 )
            {
                timer2.Stop();
                Cansqueeze = true;
                firestart = 1;
            }
            re[gunkey].bullet[0].drawRecrangel(e);

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            re[0].drawRecrangel(e);
            for (int i = 1; i < enemynumber; i++) {
                if (re[i].islive) {
                    re[i].drawRecrangel(e);
                }
            }
        }
        int gunkey = 0;
        private void enemymove(object sender, EventArgs e)
        {
            for (int i = 1; i < enemynumber; i++)
            {
                re[i].randmove();
                if ((re[i].x - 10) < re[0].x && re[0].x < (re[i].x + 10)|| (re[i].y - 10) < re[0].y && re[0].y < (re[i].y + 10) && re[i].islive)
                {
                    if (firestart==1 && re[i].islive) {
                        gunkey = i;
                        enemygun();
                        firestart = 0;
                    }
                }
            }
            Refresh();
            Application.DoEvents();

        }

        private void enemygunmove(object sender, EventArgs e)
        {
            re[gunkey].bullet[0].gunmov();
            if( (re[gunkey].bullet[0].x - 10) < re[0].x && re[0].x < (re[gunkey].bullet[0].x + 10) && (re[gunkey].bullet[0].y - 10) < re[0].y && re[0].y < (re[gunkey].bullet[0].y + 10) && re[gunkey].islive)
            {
                Application.Exit();
            }
            Refresh();
            Application.DoEvents();
         
        }
    }
}
