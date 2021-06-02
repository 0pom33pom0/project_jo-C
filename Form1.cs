using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace Project_job
{
    public partial class Form1 : Form
    {
        System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"D:\w2\c#\Project_job\Project_job\Resources\ซาว.wav");
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Program.tool = 0;
            player.Play();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(dispatTick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            timer.Start();
            DispatcherTimer gg = new DispatcherTimer();
            gg.Tick += new EventHandler(ggh);
            gg.Interval = new TimeSpan(0, 0, 0, 0, 350);
            gg.Start();
        }
        int k = 0;
        private void ggh(object sender, EventArgs e)
        {
            if (k == 0)
            {
                guna2PictureBox1.Image = Image.FromFile(@"D:\w2\c#\Project_job\hh2.png");
                k = 1;
            }
            else
            {
                guna2PictureBox1.Image = Image.FromFile(@"D:\w2\c#\Project_job\hh1.png");
                k = 0;
            }
        }
        int x = 0;
        string[] a = { "pk1.png", "pk2.png", "pk3.png", "pk4.png", "pk5.png", "pk6.png", "pk7.png", "pk8.png", "pk9.png", "pk10.png", "pk11.png", "pk12.png", "pk13.png", "pk14.png", "pk15.png", "pk16.png", "pk17.png", "pk16.png", "pk15.png", "pk14.png", "pk13.png", "pk12.png", "pk11.png", "pk10.png", "pk9.png", "pk8.png", "pk7.png", "pk6.png", "pk5.png", "pk4.png", "pk3.png", "pk2.png" };
        private void dispatTick(object sender, EventArgs e)
        {
            for (int i = 0; i <= 30; i++)
            {
                if (i == x)
                {
                    BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\p and pk\" + a[x+1]);
                }
            }
            if (x == 30)
            {
                x = -1;
            }
            x += 1;
        }
        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            player.Stop();
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }
        private void ออกToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void ผจดทำToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("คนที่หล่อๆครับเป็นผู้จัดทำ");
        }
        private void กตกาToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            player.Stop();
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            player.Stop();
            Form6 f6 = new Form6();
            f6.ShowDialog();
        }
    }
}
