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

namespace percobaan
{
    public partial class Form2 : Form
    {
        private MySqlCommand cmd;
        private DataSet ds;
        private MySqlDataAdapter da;
        private MySqlDataReader rd;

        connections koneksi = new connections();
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection koneksi = connections.getConnection();
            koneksi.Open();

            cmd = new MySqlCommand("Select * from login where username='" + txtUsername.Text + "' and password='" + txtPassword.Text + "'", koneksi);
            rd = cmd.ExecuteReader();
            rd.Read();
            if (rd.HasRows)
            {
                new Form1().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username or Password invalid!");
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
