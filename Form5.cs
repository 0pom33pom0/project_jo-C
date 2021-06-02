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
using MySql.Data.MySqlClient;

namespace Project_job
{
    public partial class Form5 : Form
    {
        System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"D:\w2\c#\Project_job\Project_job\Resources\ซาว4.wav");
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=project_jo;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        public Form5()
        {
            InitializeComponent();
        }
        int sum = 0, no = 1;
        string[] tool_sql = { "`positive`", "`delete`", "`multiply`", "`divide`" };
        private void Form5_Load(object sender, EventArgs e)
        {
            string a = $"{Program.tool}.png";
            guna2PictureBox3.Image = Image.FromFile(@"D:\w2\c#\Project_job\tool\" + a);
            label1.Text = Program.u;
            player.Play();

            MySqlConnection conn = databaseConnection();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = $"SELECT * FROM score WHERE `name`=\"{Program.u}\"";
            MySqlDataReader row = cmd.ExecuteReader();
            if (row.HasRows)
            {
                while (row.Read())
                {
                    if (int.Parse(row.GetString(Program.tool)) < Program.score)
                    {
                        conn = databaseConnection();
                        string sql = "UPDATE score SET "+ tool_sql[Program.tool-1] +"='" + Program.score + "' WHERE `name`='" + Program.u + "'";
                        conn.Open();
                        cmd = new MySqlCommand(sql, conn);
                        cmd.ExecuteReader();
                        conn.Close();

                        conn = databaseConnection();
                        conn.Open();
                        cmd = conn.CreateCommand();
                        cmd.CommandText = $"SELECT * FROM score WHERE `name`=\"{Program.u}\"";
                        row = cmd.ExecuteReader();
                        if (row.HasRows)
                        {
                            while (row.Read())
                            {
                                for (int i = 1; i <= 4; i++)
                                {
                                    sum = sum + int.Parse(row.GetString(i));
                                }
                                conn = databaseConnection();
                                string sql1 = "UPDATE score SET  `sum`='" + sum + "' WHERE `name`='" + Program.u + "'";
                                conn.Open();
                                cmd = new MySqlCommand(sql1, conn);
                                cmd.ExecuteReader();
                                conn.Close();
                            }
                            conn.Close();
                        }
                        DispatcherTimer timer_m = new DispatcherTimer();
                        timer_m.Tick += new EventHandler(mm);
                        timer_m.Interval = new TimeSpan(0, 0, 0, 0, 300);
                        timer_m.Start();
                    }
                }
                conn.Close();
            }
            else
            {
                switch (Program.tool)
                {
                    case 1:
                        conn = databaseConnection();
                        string sql1 = "INSERT INTO `score`(`name`, `positive`, `delete`, `multiply`, `divide`, `sum`) VALUES('" + Program.u + "','" + Program.score + "','0','0','0','" + Program.score + "')";
                        conn.Open();
                        MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
                        cmd1.ExecuteReader();
                        conn.Close();
                        break;
                    case 2:
                        conn = databaseConnection();
                        string sql2 = "INSERT INTO `score`(`name`, `positive`, `delete`, `multiply`, `divide`, `sum`) VALUES('" + Program.u + "','0','" + Program.score + "','0','0','" + Program.score + "')";
                        conn.Open();
                        MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                        cmd2.ExecuteReader();
                        conn.Close();
                        break;
                    case 3:
                        conn = databaseConnection();
                        string sql3 = "INSERT INTO `score`(`name`, `positive`, `delete`, `multiply`, `divide`, `sum`) VALUES('" + Program.u + "','0','0','" + Program.score + "','0','" + Program.score + "')";
                        conn.Open();
                        MySqlCommand cmd3 = new MySqlCommand(sql3, conn);
                        cmd3.ExecuteReader();
                        conn.Close();
                        break;
                    case 4:
                        conn = databaseConnection();
                        string sql4 = "INSERT INTO `score`(`name`, `positive`, `delete`, `multiply`, `divide`, `sum`) VALUES('" + Program.u + "','0','0','0','" + Program.score + "','" + Program.score + "')";
                        conn.Open();
                        MySqlCommand cmd4 = new MySqlCommand(sql4, conn);
                        cmd4.ExecuteReader();
                        conn.Close();
                        break;
                }
                DispatcherTimer timer_m = new DispatcherTimer();
                timer_m.Tick += new EventHandler(mm);
                timer_m.Interval = new TimeSpan(0, 0, 0, 0, 300);
                timer_m.Start();
            }
            conn.Close();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(dispatTick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 60);
            timer.Start();

            conn = databaseConnection();
            cmd = new MySqlCommand("SELECT * FROM score", conn);
            conn.Open();
            MySqlDataReader adapter = cmd.ExecuteReader();
            while (adapter.Read())
            {
                int max=int.Parse(adapter.GetString(Program.tool));
                if (Program.score < max)
                {
                    no += 1;
                }
            }
            conn.Close();
            guna2Button4.Text = $"{no}";
        }
        int l = 1;
        private void mm(object sender, EventArgs e)
        {
            if (l == 1)
            {
                guna2PictureBox4.Image = Image.FromFile(@"D:\w2\c#\Project_job\tool\m1.png");
                l = 2;
            }
            else if (l == 2)
            {
                guna2PictureBox4.Image = Image.FromFile(@"D:\w2\c#\Project_job\tool\m2.png");
                l = 3;
            }
            else if (l == 3)
            {
                guna2PictureBox4.Image = Image.FromFile(@"D:\w2\c#\Project_job\tool\m3.png");
                l = 1;
            }
        }
        int x = 0, j = 1;
        string[] a = { "OV2.png", "OV3.png", "OV2.png", "OV1.png", "OV4.png", "OV5.png", "OV4.png", "OV1.png" };
        private void dispatTick(object sender, EventArgs e)
        {
            x += 1;
            guna2PictureBox1.Image = Image.FromFile(@"D:\w2\c#\Project_job\tool\" + a[x]);
            if (x == 7)
            {
                x = 0;
            }
            if (j <= Program.score)
            {
                label2.Text = $"{j}";
                j += 1;
            }
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {

        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            player.Stop();
            Form6 f6 = new Form6();
            f6.ShowDialog();
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }
        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }
    }
}
