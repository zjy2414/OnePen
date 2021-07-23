using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnePan2
{
    public partial class QuitWindow : Form
    {
        public QuitWindow()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);//结束当前进程
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
