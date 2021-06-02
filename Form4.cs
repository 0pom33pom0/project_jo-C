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
    public partial class Form4 : Form
    {
        private readonly Random random = new Random();
        System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"D:\w2\c#\Project_job\Project_job\Resources\ซาว3.wav");
        public Form4()
        {
            InitializeComponent();
        }
        int i, j, num_1, num_2, answer, chek=0, cx = 0, cy = 0, time=40,ch=0;
        int[] num = { 0, 0, 0, 0, 0, 0, 0, 0 };
        private void Form4_Load(object sender, EventArgs e)
        {
            Program.score = 0;
            player.Play();
            string a = $"{Program.tool}.png";
            guna2PictureBox2.Image = Image.FromFile(@"D:\w2\c#\Project_job\tool\" + a);

            if (Program.tool <= 2)
            {
                for ( i = 1; i <= 8; i++)
                {
                    Control control = Controls["number" + i];
                    num[i - 1] = random.Next(20);
                    control.Text = $"{num[i-1]}";
                }
            }
            else if (Program.tool == 3)
            {
                for (i = 1; i <= 8; i++)
                {
                    Control control = Controls["number" + i];
                    num[i - 1] = random.Next(12);
                    control.Text = $"{num[i - 1]}";
                }
            }
            else
            {
                j = 1;
                while (j <= 8)
                {
                    num[j - 1] = random.Next(1,90);
                    if (num[j - 1] % 10 == 0 )
                    {
                        Control control = Controls["number" + j];
                        control.Text = $"{num[j - 1]}";
                        j += 1;
                    }
                }
            }

            answer_f();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(dispatTick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1000);
            timer.Start();
            DispatcherTimer music = new DispatcherTimer();
            music.Tick += new EventHandler(music_p);
            music.Interval = new TimeSpan(0, 0, 2, 26, 0);
            music.Start();
        }
        private void answer_f()
        {
            j = 0;
            while (j < 1)
            {
                int n1 = random.Next(7);
                int n2 = random.Next(7);
                if (n1 != n2)
                {
                    switch (Program.tool)
                    {
                        case 1:
                            answer = num[n1] + num[n2];
                            j = 10;
                            break;
                        case 2:
                            if (num[n1] >= num[n2])
                            {
                                answer = num[n1] - num[n2];
                                j = 10;
                            }
                            break;
                        case 3:
                            answer = num[n1] * num[n2];
                            j = 10;
                            break;
                        case 4:
                            if(num[n1] >= num[n2])
                            {
                                if(num[n1] % num[n2] == 0)
                                {
                                    answer = num[n1] / num[n2];
                                    j = 10;
                                }
                            }
                            break;
                    }
                    if (j == 10)
                    {
                        answerButton.Text = $"{answer}";
                    }
                }
            }
        }
        private void chekanswer()
        {
            Program.score += 1;
            score_l.Text = $"{Program.score}";
            answerButton.FillColor = Color.LimeGreen;
            DispatcherTimer timer_2 = new DispatcherTimer();
            timer_2.Tick += new EventHandler(color_m);
            timer_2.Interval = new TimeSpan(0, 0, 0, 0, 600);
            timer_2.Start();
            
            time = time + 6;
            num[cx - 1] = random.Next(30);
            Control control = Controls["number" + cx];
            control.Text = $"{num[cx - 1]}";
            num[cy - 1] = random.Next(30);
            Control control_2 = Controls["number" + cy];
            control_2.Text = $"{num[cy - 1]}";

            answer_f();

            for (i = 1; i <= 8; i++)
            {
                control = Controls["number" + i];
                control.Enabled = true;
            }
            num1.FillColor = Color.MediumTurquoise;
            num2.FillColor = Color.MediumTurquoise;
            num1.Text = "ตัวเลขที่1";
            num2.Text = "ตัวเลขที่2";
            chek = 0;
            cx = 0;
            cy = 0;
            num_1=200;
            num_2=200;
        }
        private void num1_Click(object sender, EventArgs e)
        {
            chek = 1;
            num1.FillColor = Color.DarkSlateGray;
            num2.FillColor = Color.MediumTurquoise;
        }
        private void num2_Click_1(object sender, EventArgs e)
        {
            chek = 2;
            num2.FillColor = Color.DarkSlateGray;
            num1.FillColor = Color.MediumTurquoise;
        }
        private void music_p(object sender, EventArgs e)
        {
            player.Play();
        }
        private void color_m(object sender, EventArgs e)
        {
            answerButton.FillColor = Color.MediumTurquoise;
        }
        int x = 1;
        private void dispatTick(object sender, EventArgs e)
        {
            if (x < 3)
            {
                guna2PictureBox1.Image = Image.FromFile(@"D:\w2\c#\Project_job\Game characters\pg1.png");
                x += 1;
            }
            else
            {
                guna2PictureBox1.Image = Image.FromFile(@"D:\w2\c#\Project_job\Game characters\pg2.png");
                x = 1;
            }
            if (ch == 0)
            {
                time -= 1;
                if (time == -1)
                {
                    this.Hide();
                    player.Stop();
                    Form5 f5 = new Form5();
                    f5.ShowDialog();
                }
                if (time <= 10)
                {
                    label1.BackColor = Color.Red;
                }
                label1.Text = $"{time}";
            }
        }
        private void number1_Click(object sender, EventArgs e)
        {
            if (chek == 1)
            {
                for (i = 1; i <= 8; i++)
                {
                    if (i != cy)
                    {
                        Control control = Controls["number" + i];
                        control.Enabled = true;
                    }
                }
                number1.Enabled = false;
                num1.Text = $"{num[0]}";
                num_1 = num[0];
                cx = 1;
            }
            else if(chek==2)
            {
                for (i = 1; i <= 8; i++)
                {
                    if (i != cx)
                    {
                        Control control = Controls["number" + i];
                        control.Enabled = true;
                    }
                }
                number1.Enabled = false;
                num2.Text = $"{num[0]}";
                num_2 = num[0];
                cy = 1;
            }
            else
            {
                MessageBox.Show("กรุณาเลือกต่ำแหน่งที่คุณต้องการก่อน");
            }
        }
        private void number2_Click(object sender, EventArgs e)
        {
            if (chek == 1)
            {
                for (i = 1; i <= 8; i++)
                {
                    if (i != cy)
                    {
                        Control control = Controls["number" + i];
                        control.Enabled = true;
                    }
                }
                number2.Enabled = false;
                num1.Text = $"{num[1]}";
                num_1 = num[1];
                cx = 2;
            }
            else if (chek == 2)
            {
                for (i = 1; i <= 8; i++)
                {
                    if (i != cx)
                    {
                        Control control = Controls["number" + i];
                        control.Enabled = true;
                    }
                }
                number2.Enabled = false;
                num2.Text = $"{num[1]}";
                num_2 = num[1];
                cy = 2;
            }
            else
            {
                MessageBox.Show("กรุณาเลือกต่ำแหน่งที่คุณต้องการก่อน");
            }
        }
        private void number3_Click(object sender, EventArgs e)
        {
            if (chek == 1)
            {
                for (i = 1; i <= 8; i++)
                {
                    if (i != cy)
                    {
                        Control control = Controls["number" + i];
                        control.Enabled = true;
                    }
                }
                number3.Enabled = false;
                num1.Text = $"{num[2]}";
                num_1 = num[2];
                cx = 3;
            }
            else if (chek == 2)
            {
                for (i = 1; i <= 8; i++)
                {
                    if (i != cx)
                    {
                        Control control = Controls["number" + i];
                        control.Enabled = true;
                    }
                }
                number3.Enabled = false;
                num2.Text = $"{num[2]}";
                num_2 = num[2];
                cy = 3;
            }
            else
            {
                MessageBox.Show("กรุณาเลือกต่ำแหน่งที่คุณต้องการก่อน");
            }
        }
        private void number4_Click(object sender, EventArgs e)
        {
            if (chek == 1)
            {
                for (i = 1; i <= 8; i++)
                {
                    if (i != cy)
                    {
                        Control control = Controls["number" + i];
                        control.Enabled = true;
                    }
                }
                number4.Enabled = false;
                num1.Text = $"{num[3]}";
                num_1 = num[3];
                cx = 4;
            }
            else if (chek == 2)
            {
                for (i = 1; i <= 8; i++)
                {
                    if (i != cx)
                    {
                        Control control = Controls["number" + i];
                        control.Enabled = true;
                    }
                }
                number4.Enabled = false;
                num2.Text = $"{num[3]}";
                num_2 = num[3];
                cy = 4;
            }
            else
            {
                MessageBox.Show("กรุณาเลือกต่ำแหน่งที่คุณต้องการก่อน");
            }
        }
        private void number5_Click(object sender, EventArgs e)
        {
            if (chek == 1)
            {
                for (i = 1; i <= 8; i++)
                {
                    if (i != cy)
                    {
                        Control control = Controls["number" + i];
                        control.Enabled = true;
                    }
                }
                number5.Enabled = false;
                num1.Text = $"{num[4]}";
                num_1 = num[4];
                cx = 5;
            }
            else if (chek == 2)
            {
                for (i = 1; i <= 8; i++)
                {
                    if (i != cx)
                    {
                        Control control = Controls["number" + i];
                        control.Enabled = true;
                    }
                }
                number5.Enabled = false;
                num2.Text = $"{num[4]}";
                num_2 = num[4];
                cy = 5;
            }
            else
            {
                MessageBox.Show("กรุณาเลือกต่ำแหน่งที่คุณต้องการก่อน");
            }
        }
        private void number6_Click(object sender, EventArgs e)
        {
            if (chek == 1)
            {
                for (i = 1; i <= 8; i++)
                {
                    if (i != cy)
                    {
                        Control control = Controls["number" + i];
                        control.Enabled = true;
                    }
                }
                number6.Enabled = false;
                num1.Text = $"{num[5]}";
                num_1 = num[5];
                cx = 6;
            }
            else if (chek == 2)
            {
                for (i = 1; i <= 8; i++)
                {
                    if (i != cx)
                    {
                        Control control = Controls["number" + i];
                        control.Enabled = true;
                    }
                }
                number6.Enabled = false;
                num2.Text = $"{num[5]}";
                num_2 = num[5];
                cy = 6;
            }
            else
            {
                MessageBox.Show("กรุณาเลือกต่ำแหน่งที่คุณต้องการก่อน");
            }
        }
        private void number7_Click(object sender, EventArgs e)
        {
            if (chek == 1)
            {
                for (i = 1; i <= 8; i++)
                {
                    if (i != cy)
                    {
                        Control control = Controls["number" + i];
                        control.Enabled = true;
                    }
                }
                number7.Enabled = false;
                num1.Text = $"{num[6]}";
                num_1 = num[6];
                cx = 7;
            }
            else if (chek == 2)
            {
                for (i = 1; i <= 8; i++)
                {
                    if (i != cx)
                    {
                        Control control = Controls["number" + i];
                        control.Enabled = true;
                    }
                }
                number7.Enabled = false;
                num2.Text = $"{num[6]}";
                num_2 = num[6];
                cy = 7;
            }
            else
            {
                MessageBox.Show("กรุณาเลือกต่ำแหน่งที่คุณต้องการก่อน");
            }
        }
        private void number8_Click(object sender, EventArgs e)
        {
            if (chek == 1)
            {
                for (i = 1; i <= 8; i++)
                {
                    if (i != cy)
                    {
                        Control control = Controls["number" + i];
                        control.Enabled = true;
                    }
                }
                number8.Enabled = false;
                num1.Text = $"{num[7]}";
                num_1 = num[7];
                cx = 8;
            }
            else if (chek == 2)
            {
                for (i = 1; i <= 8; i++)
                {
                    if (i != cx)
                    {
                        Control control = Controls["number" + i];
                        control.Enabled = true;
                    }
                }
                number8.Enabled = false;
                num2.Text = $"{num[7]}";
                num_2 = num[7];
                cy = 8;
            }
            else
            {
                MessageBox.Show("กรุณาเลือกต่ำแหน่งที่คุณต้องการก่อน");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            switch (Program.tool)
            {
                case 1:
                    if (num_1 + num_2 == answer)
                    {
                        chekanswer();
                    }
                    else
                    {
                        answerButton.FillColor = Color.Crimson;
                        DispatcherTimer timer_1 = new DispatcherTimer();
                        timer_1.Tick += new EventHandler(color_m);
                        timer_1.Interval = new TimeSpan(0, 0, 0, 0, 900);
                        timer_1.Start();
                    }
                    break;
                case 2:
                    if(num_1 - num_2 == answer)
                    {
                        chekanswer();
                    }
                    else
                    {
                        answerButton.FillColor = Color.Crimson;
                        DispatcherTimer timer_1 = new DispatcherTimer();
                        timer_1.Tick += new EventHandler(color_m);
                        timer_1.Interval = new TimeSpan(0, 0, 0, 0, 900);
                        timer_1.Start();
                    }
                    break;
                case 3:
                    if (num_1 * num_2 == answer)
                    {
                        Program.score += 1;
                        score_l.Text = $"{Program.score}";
                        answerButton.FillColor = Color.LimeGreen;
                        DispatcherTimer timer_2 = new DispatcherTimer();
                        timer_2.Tick += new EventHandler(color_m);
                        timer_2.Interval = new TimeSpan(0, 0, 0, 0, 600);
                        timer_2.Start();

                        time = time + 6;
                        num[cx - 1] = random.Next(12);
                        Control control = Controls["number" + cx];
                        control.Text = $"{num[cx - 1]}";
                        num[cy - 1] = random.Next(12);
                        Control control_2 = Controls["number" + cy];
                        control_2.Text = $"{num[cy - 1]}";

                        answer_f();
                        for (i = 1; i <= 8; i++)
                        {
                            control = Controls["number" + i];
                            control.Enabled = true;
                        }
                        num1.FillColor = Color.MediumTurquoise;
                        num2.FillColor = Color.MediumTurquoise;
                        num1.Text = "ตัวเลขที่1";
                        num2.Text = "ตัวเลขที่2";
                        chek = 0;
                        cx = 0;
                        cy = 0;
                        num_1 = 200;
                        num_2 = 200;
                    }
                    else
                    {
                        answerButton.FillColor = Color.Crimson;
                        DispatcherTimer timer_1 = new DispatcherTimer();
                        timer_1.Tick += new EventHandler(color_m);
                        timer_1.Interval = new TimeSpan(0, 0, 0, 0, 900);
                        timer_1.Start();
                    }
                    break;
                case 4:
                    if (num_1 / num_2 == answer)
                    {
                        Program.score += 1;
                        score_l.Text = $"{Program.score}";
                        time = time + 5;
                        answerButton.FillColor = Color.LimeGreen;
                        DispatcherTimer timer_2 = new DispatcherTimer();
                        timer_2.Tick += new EventHandler(color_m);
                        timer_2.Interval = new TimeSpan(0, 0, 0, 0, 600);
                        timer_2.Start();

                        j = 0;
                        while (j < 1)
                        {
                            num[cx - 1] = random.Next(1, 90);
                            if (num[cx - 1] % 10 == 0)
                            {
                                Control control = Controls["number" + cx];
                                control.Text = $"{num[cx - 1]}";
                                j = 10;
                            }
                        }
                        while (j == 10)
                        {
                            num[cy - 1] = random.Next(1, 90);
                            if(num[cy - 1] % 10 == 0)
                            {
                                Control control_2 = Controls["number" + cy];
                                control_2.Text = $"{num[cy - 1]}";
                                j = 3;
                            }
                        }

                        answer_f();

                        for (i = 1; i <= 8; i++)
                        {
                            Control control = Controls["number" + i];
                            control.Enabled = true;
                        }
                        num1.FillColor = Color.MediumTurquoise;
                        num2.FillColor = Color.MediumTurquoise;
                        num1.Text = "ตัวเลขที่1";
                        num2.Text = "ตัวเลขที่2";
                        chek = 0;
                        cx = 0;
                        cy = 0;
                        num_1 = 5000;
                        num_2 = 1;
                    }
                    else
                    {
                        answerButton.FillColor = Color.Crimson;
                        DispatcherTimer timer_1 = new DispatcherTimer();
                        timer_1.Tick += new EventHandler(color_m);
                        timer_1.Interval = new TimeSpan(0, 0, 0, 0, 900);
                        timer_1.Start();
                    }
                    break;
            }
        }
        private void ออกToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ch = 1;
            string message = "คะแนนของคุณจะหายไป คุณต้องการออกเกมใช่หรือไม่";
            string title = "Close Window";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                ch = 0;
            }
        }
        private void ผจดทำToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("คนที่หล่อๆครับเป็นผู้จัดทำ");
        }
    }
}