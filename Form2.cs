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
    public partial class Form2 : Form
    {
        System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"D:\w2\c#\Project_job\Project_job\Resources\ซาว2.wav");
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            player.Play();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(dispatTick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 40);
            timer.Start();
            DispatcherTimer gg = new DispatcherTimer();
            gg.Tick += new EventHandler(name);
            gg.Interval = new TimeSpan(0, 0, 0, 0, 650);
            gg.Start();
        }
        int k=1;
        private void name(object sender, EventArgs e)
        {
            if (k == 1)
            {
                guna2PictureBox1.Image = Image.FromFile(@"D:\w2\c#\Project_job\ชื่อ2.png");
                k = 2;
            }
            else
            {
                guna2PictureBox1.Image = Image.FromFile(@"D:\w2\c#\Project_job\ชื่อ.png");
                k = 1;
            }
        }
        int x = 1;
        int characters = 2;
        private void dispatTick(object sender, EventArgs e)
        {
            for(int j = 2; j <= 9; j++)
            {
                if (j == characters)
                {
                    string b = $"{characters + 1}.png";
                    guna2PictureBox2.Image = Image.FromFile(@"D:\w2\c#\Project_job\Game characters\"+b);
                }
            }
            for (int i = 1; i <= 208; i++)
            {
                if (i == x)
                {
                    string a = $"{x + 1}.png";
                    BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\ls\" + a);
                }
            }
            if (x == 209)
            {
                x = 1;
            }
            if (characters == 10)
            {
                characters = 2;
            }
            x += 1;
            characters += 1;
        }
        private void ออกToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text != "" && guna2TextBox1.Text != " ")
            {
                Program.u = guna2TextBox1.Text;
                this.Hide();
                player.Stop();
                Program.tool = 1;
                Form3 f3 = new Form3();
                f3.ShowDialog();
            }
            else
            {
                MessageBox.Show("กรุณากรอกชื่อก่อนเริ่มเกม");
            }
        }
        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text != "" && guna2TextBox1.Text != " ")
            {
                Program.u = guna2TextBox1.Text;
                this.Hide();
                player.Stop();
                Program.tool = 2;
                Form3 f3 = new Form3();
                f3.ShowDialog();
            }
            else
            {
                MessageBox.Show("กรุณากรอกชื่อก่อนเริ่มเกม");
            }
        }
        private void guna2ImageButton3_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text != "" && guna2TextBox1.Text != " ")
            {
                Program.u = guna2TextBox1.Text;
                this.Hide();
                player.Stop();
                Program.tool = 3;
                Form3 f3 = new Form3();
                f3.ShowDialog();
            }
            else
            {
                MessageBox.Show("กรุณากรอกชื่อก่อนเริ่มเกม");
            }
        }
        private void guna2ImageButton4_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text != "" && guna2TextBox1.Text != " ")
            {
                Program.u = guna2TextBox1.Text;
                this.Hide();
                player.Stop();
                Program.tool = 4;
                Form3 f3 = new Form3();
                f3.ShowDialog();
            }
            else
            {
                MessageBox.Show("กรุณากรอกชื่อก่อนเริ่มเกม");
            }
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
        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }
        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}