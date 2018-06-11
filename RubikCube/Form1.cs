using RubikCube.Classes;
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

namespace RubikCube
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            MyRubikCube rubik = new MyRubikCube();
            rubik.InitRubikCube();
            foreach(MyCube cub in rubik.listCube)
            {
                Console.WriteLine(cub.origin.ToString());
            }
        }

        public void DrawRectange(System.Drawing.Graphics graphic,SolidBrush brush, Point startPoint, int x, int y, double angleX, double angleY)
        {
            // 创建一个点的数组
            PointF pt1 = startPoint;
            PointF pt2 = new PointF((float)(startPoint.X + x * Math.Cos(angleX)), (float)(startPoint.Y+x*Math.Sin(angleX)));
            PointF pt4 = new PointF((float)(startPoint.X - y * Math.Sin(angleY)), (float)(startPoint.Y + y * Math.Cos(angleY)));
            PointF pt3 = new PointF((float)(pt4.X + x * Math.Cos(angleX)), (float)(pt4.Y + x * Math.Sin(angleX)));

            PointF[] ptsArrar = { pt1, pt2, pt3, pt4};
            // 绘制填充曲线
            //graphic.FillClosedCurve(blueBrush, ptsArrar, flMode, tension);
            GraphicsPath path = new GraphicsPath();
            path.AddLines(ptsArrar);
            graphic.FillPath(brush, path);
        }

        public void DrawCube(MyCube cub)
        {

        }

        public void DrawRubikCube(MyRubikCube rubik,List<Color> frontColors)
        {
            foreach(MyCube cub in rubik.listCube)
            {
                
            }
        }

        private Graphics _graphics = null;
        public Graphics globalGraphics
        {
            get
            {
                if(_graphics==null)
                {
                    _graphics = this.CreateGraphics();
                    _graphics.SmoothingMode = SmoothingMode.AntiAlias;
                }
                return _graphics;
            }
        }

        public void DrawTest()
        {
            System.Drawing.Graphics g = this.CreateGraphics();
            Rectangle rect = new Rectangle(10, 10, 35, 35);//定义矩形,参数为起点横纵坐标以及其长和宽
            g.DrawRectangle(Pens.Red, rect);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            System.Drawing.Color Mycolor = System.Drawing.Color.FromArgb(128, Color.Yellow);//说明：1-（128/255）=1-0.5=0.5 透明度为0.5，即50%
            System.Drawing.SolidBrush sb1 = new System.Drawing.SolidBrush(Mycolor);
            g.FillRectangle(Brushes.Tomato, 0, 50, 250, 50); //给窗体填上颜色以增强比较效果
            g.FillEllipse(sb1, 20, 20, 100, 100); //半透明效果
            g.FillEllipse(Brushes.Yellow, 120, 20, 100, 100); //实色效果
            sb1.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DrawTest();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.Blue);
            DrawRectange(globalGraphics,blueBrush, new Point(100, 100), 100, 100, 0, 0);
            blueBrush.Dispose();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            TrackBar bar = sender as TrackBar;
            globalGraphics.Clear(Color.White);
            SolidBrush blueBrush = new SolidBrush(Color.Blue);
            DrawRectange(globalGraphics, blueBrush, new Point(100, 100), 100, 100, 0, Math.PI * 2 * bar.Value / 100.0);
            blueBrush.Dispose();
        }
    }
}
