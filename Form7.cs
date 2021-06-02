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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=project_jo;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        private void guna2Button7_Click(object sender, EventArgs e)
        {

        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            int no = 1;
            MySqlConnection conn = databaseConnection();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = $"SELECT * FROM score WHERE `name`=\"{textBox1.Text}\"";
            MySqlDataReader row = cmd.ExecuteReader();
            if (row.HasRows)
            {
                while (row.Read())
                {
                    guna2Button7.Text = $"{row.GetString(1)}";
                    guna2Button8.Text = $"{row.GetString(2)}";
                    guna2Button9.Text = $"{row.GetString(3)}";
                    guna2Button10.Text = $"{row.GetString(4)}";
                    guna2Button11.Text = $"{row.GetString(5)}";
                    conn = databaseConnection();
                    cmd = new MySqlCommand("SELECT * FROM score", conn);
                    conn.Open();
                    MySqlDataReader adapter = cmd.ExecuteReader();
                    while (adapter.Read())
                    {
                        if (int.Parse(row.GetString(5)) < int.Parse(adapter.GetString(5)))
                        {
                            no += 1;
                        }
                    }
                    conn.Close();
                }
            }
            else
            {
                MessageBox.Show("ไม่พบชื่อที่คุณค้นหา");
            }
            guna2Button12.Text = $"{no}";
        }
        private void guna2Button14_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }
        private void guna2Button13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
