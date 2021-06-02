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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        int x = 1;
        private void ผจดทำToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("คนที่หล่อๆครับเป็นผู้จัดทำ");
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            guna2Button1.Hide();
            guna2Button2.Hide();
        }
        private void ออกToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (x < 4)
            {
                for (int i = 1; i <= 4; i++)
                {
                    if (x == i)
                    {
                        string png = $"{x + 1}.png";
                        BackgroundImage = Image.FromFile(@"D:\w2\c#\Project_job\how_to_play\" + png);
                    }

                }
                x += 1;
            }
            else
            {
                if (Program.tool <= 0)
                {
                    guna2Button1.Show();
                    guna2Button2.Show();
                    guna2Button3.Hide();
                }
                else
                {
                    this.Hide();
                    Form4 f4 = new Form4();
                    f4.ShowDialog();
                }
            }
        }
    }
}
