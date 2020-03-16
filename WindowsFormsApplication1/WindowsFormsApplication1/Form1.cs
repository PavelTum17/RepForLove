using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private static PointF point1 = new PointF(100, 800);
        private static PointF point2 = new PointF(200, 900);
        private static PointF point3 = new PointF(100, 1000);
        private static PointF point4 = new PointF(250, 900);
        private static PointF center0 = point4; //center
        private PointF center = new PointF(250, 900);
        private static PointF[] bumerang = { point1, point2, point3, point4 };
        private static PointF start = new PointF(100, 800);
        private static PointF stop = new PointF(900, 80);
        private static PointF speed = new PointF(6f, -3f);
        private float angle = 1f;
        private static float angleSpeed = 0.1f;
        private float forward = 1f;

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.forward = 1f;
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            this.forward = -1f;
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (this.forward > 0f || center != center0)
            {
                this.angle += angleSpeed;
                this.center.X += speed.X * this.forward;
                this.center.Y += speed.Y * this.forward;
                Invalidate();
            }
        }

        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
            Graphics paint = e.Graphics;
            SolidBrush S = new SolidBrush(Color.Brown);

            PointF[] points = new PointF[bumerang.Length];
            for (int i = 0; i < bumerang.Length; i++)
            {
                PointF p0 = bumerang[i];
                double ang = Math.Atan2(p0.Y - center0.Y, p0.X - center0.X) + this.angle;
                double len = Math.Sqrt(Math.Pow(p0.Y - center0.Y, 2) + Math.Pow(p0.X - center0.X, 2));
                float x = (float)(this.center.X + len * Math.Cos(ang));
                float y = (float)(this.center.Y + len * Math.Sin(ang));
                points[i] = new PointF(x, y);
            }

            paint.FillClosedCurve(S, points);
        }
    }
}
