using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnePen
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]//拖动无窗体的控件
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;


        Board board;
        Helper hp = new Helper();
        private void Start_MouseDown(object sender, MouseEventArgs e)
        {
            //拖动窗体
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Helper.IfEraser = false;
            if (hp.IfInBoard == false)
            {
                this.Visible = false;
                System.Threading.Thread.Sleep(110);

                board = new Board(hp.GetScreen());
                this.Visible = true;
                //弹出画板
                board.Show();
                hp.IfInBoard = true;
            }

            //FormBorderStyle = FormBorderStyle.None;     //设置窗体为无边框样式
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.TransparencyKey = Color.GreenYellow;
            this.BackColor = Color.GreenYellow;
            FormBorderStyle = FormBorderStyle.None;
        }

        private void button2_Click(object sender, EventArgs e)
        {
           if(hp.IfInBoard == true)
            {
                board.Close();
                hp.IfInBoard = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            QuitWindow qw = new QuitWindow();
            qw.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Helper.IfEraser = true;
        }

        private void pan_plus_Click(object sender, EventArgs e)
        {
            Helper.PanSize += 1;
        }

        private void pan_minus_Click(object sender, EventArgs e)
        {
            Helper.PanSize -= 1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Helper.EraserSize += 1;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Helper.EraserSize -= 1;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Helper.PanColor = Color.Black;
            Helper.IfEraser = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Helper.PanColor = Color.Red;
            Helper.IfEraser = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Helper.PanColor = Color.Blue;
            Helper.IfEraser = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Helper.PanColor = Color.Yellow;
            Helper.IfEraser = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Helper.IfEraser = false;
            if (hp.IfInBoard == false)
            {
                this.Visible = false;
                System.Threading.Thread.Sleep(110);

                board = new Board(hp.GetScreen());
                this.Visible = true;
                //弹出画板
                board.Show();
                hp.IfInBoard = true;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (hp.IfInBoard == true)
            {
                board.Close();
                hp.IfInBoard = false;
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            AboutWindow aw = new AboutWindow();

            aw.ShowDialog();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            QuitWindow qw = new QuitWindow();
            qw.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Helper.PanColor = Color.Green;
            Helper.IfEraser = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Helper.PanColor = Color.BlueViolet;
            Helper.IfEraser = false;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            System.Threading.Thread.Sleep(110);
            hp.GetScreen().Save(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)+ @"\" + DateTime.Now.ToLongDateString().ToString() + DateTime.Now.Hour.ToString()+ DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + @".jpg");
            this.Visible = true;
        }
    }
   
}
