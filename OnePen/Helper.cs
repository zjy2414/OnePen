using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnePen
{
    public class Helper
    {
        public Boolean IfInBoard = false;

        public static Color PanColor = Color.Red;
        public static int PanSize = 2;
        public static Boolean IfEraser = false;
        public static int EraserSize = 12;


        public Bitmap GetScreen()
        {
            Bitmap myImage = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            Graphics g = Graphics.FromImage(myImage);

            g.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height));

            IntPtr dc1 = g.GetHdc();

            g.ReleaseHdc(dc1);

            return myImage;
        }
    }
}

