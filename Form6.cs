using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Project_job
{
    public partial class Form6 : Form
    {
        System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"D:\w2\c#\Project_job\Project_job\Resources\ซาว5.wav");
        public Form6()
        {
            InitializeComponent();
        }
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=project_jo;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        private void Form6_Load(object sender, EventArgs e)
        {
            player.Play();
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM score ORDER BY sum DESC";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);
            conn.Close();
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void ออกToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2PictureBox1.Image = Image.FromFile(@"D:\w2\c#\Project_job\tool\score_positive.png");
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM score ORDER BY `positive` DESC";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);
            conn.Close();
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2PictureBox1.Image = Image.FromFile(@"D:\w2\c#\Project_job\tool\score_delete.png");
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM score ORDER BY `delete` DESC";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);
            conn.Close();
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            guna2PictureBox1.Image = Image.FromFile(@"D:\w2\c#\Project_job\tool\score_multiply.png");
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM score ORDER BY `multiply` DESC";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);
            conn.Close();
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            guna2PictureBox1.Image = Image.FromFile(@"D:\w2\c#\Project_job\tool\score_divide.png");
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM score ORDER BY `divide` DESC";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);
            conn.Close();
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }
        private void guna2Button5_Click(object sender, EventArgs e)
        {
            guna2PictureBox1.Image = Image.FromFile(@"D:\w2\c#\Project_job\tool\score_sum.png");
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM score ORDER BY sum DESC";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);
            conn.Close();
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }
        private void guna2Button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            player.Stop();
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }
        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            player.Stop();
            Form7 f7 = new Form7();
            f7.ShowDialog();
        }
    }
}
