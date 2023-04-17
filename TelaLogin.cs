using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TccRestaurante
{
    public partial class TelaLogin : Form
    {
        public TelaLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = "Server = localhost; Database=restaurantetcc;Uid=root;Pwd=";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            con.Open();
            string login = "select*from usuario where nome='" + txtUser.Text + "'and senha='" + txtPassword.Text + "'";
            cmd = new MySqlCommand(login, con);
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                new TelaLoginNova().Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Usuário ou senha invalido!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUser.Text = "";
                txtPassword.Text = "";
                txtUser.Focus();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

        private void customInstaller1_AfterInstall(object sender, System.Configuration.Install.InstallEventArgs e)
        {

        }

        private void groupBox2_Enter_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
