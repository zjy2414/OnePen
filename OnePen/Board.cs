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

namespace OnePen
{
    public partial class Board : Form
    {
        private Point pStart, pEnd;
        private bool isAllowDraw = false;
        private bool isOpenPen = false;
        Helper hp = new Helper();
        Graphics g;

        public Board()
        {
        }

        public Board(Bitmap myImage)
        {
            InitializeComponent();
            this.BackgroundImage = myImage;
            this.FormBorderStyle = FormBorderStyle.None;     //设置窗体为无边框样式
            this.WindowState = FormWindowState.Maximized;    //最大化窗体

            isOpenPen = true;
            g = this.CreateGraphics();
            g.SmoothingMode = SmoothingMode.HighQuality;//去掉锯齿
            TransparencyKey = Color.FloralWhite;
            BackColor = Color.FloralWhite;
        }


        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (isOpenPen)
            {
                isAllowDraw = true;
                pStart = pEnd = e.Location;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (isOpenPen)
            {
                isAllowDraw = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Helper.IfEraser = true;
        }

        private void Board_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isOpenPen && isAllowDraw)
            {
                if(Helper.IfEraser == false)
                {
                    pEnd = e.Location;

                    System.Drawing.Pen pen = new System.Drawing.Pen(Helper.PanColor, Helper.PanSize);
                    g.DrawLine(pen, pStart, pEnd);
                    pStart = pEnd;
                }
                else
                {
                    g.SmoothingMode = SmoothingMode.HighSpeed;
                    pEnd = e.Location;
                    System.Drawing.Pen pen = new System.Drawing.Pen(Color.FloralWhite, Helper.EraserSize);
                    g.DrawLine(pen, pStart, pEnd);
                    pStart = pEnd;
                    g.SmoothingMode = SmoothingMode.HighQuality;
                }
            }

            }
        }
    }

