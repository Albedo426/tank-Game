using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tankcalismasi
{
    class gun
    {

        public int x=0, y=0,v=0;
      
        public double dx = 0;
        public double dy = 0;
        


        public gun(int cx ,int cy,int cv) {
            x = cx;
            y = cy;
            v = cv;
        }
        public void drawRecrangel(PaintEventArgs e)
        {

            SolidBrush blueBrush = new SolidBrush(Color.Blue);
            Rectangle rect = new Rectangle(x+7, y+7, 4, 4);
            e.Graphics.FillEllipse(blueBrush, rect);
        }
        public void gunmov()
        {
            x += (int)dx;
            y += (int)dy;
        }
        public void gunmove(Recrangel r) {
           
            if (r.yon == "Right")
            {
                dx = +v;
                dy = 0;
            }
            else if (r.yon == "Left")
            {
                dx = -v;
                dy = 0;
            }
            else if (r.yon == "Up")
            {
                dx = 0;
                dy = -v;
            }
            else if (r.yon == "Down")
            {
                dx = 0;
                dy = v;
            }
        }

        
        //mouse icin
        //public void gunmove(Recrangel r) {

        //    xpos = r.x;
        //    ypos = r.y;
        //    x = (int)xpos;
        //    y = (int)ypos;
        //    if (r.x > p.X)
        //    {
        //        degx *= -1;
        //    }
        //    if (r.y > p.Y)
        //    {
        //        degy *= -1;
        //    }
        //    //if (r.x > p.X && r.y > p.Y)
        //    //{
        //    //   // MessageBox.Show("rx=>" + r.x + "__ry=>" + r.y + "__px=>" + p.X + "__py=>" + p.Y);
        //    //    degx = -1;
        //    //    degy = -1;
        //    //}

        //    //else if (r.x < p.X && r.y > p.Y)
        //    //{
        //    //    degx = Math.Abs(degx);
        //    //    degy = -1;
        //    //}
        //    //else if (r.x > p.X && r.y < p.Y)
        //    //{
        //    //    degx = -1;
        //    //    degy = Math.Abs(degy);
        //    //}

        //    dx =(double)p.X / 100;
        //    dy =(double)p.Y / 100;

        //}
    }
}
