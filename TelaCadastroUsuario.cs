using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TccRestaurante
{
    public partial class TelaCadastroUsuario : Form
    {
        public TelaCadastroUsuario()
        {
            InitializeComponent();
        }

        MySqlConnection sqlCon = null;
        private string strCon = "Server = localhost; Database=restaurantetcc;Uid=root;Pwd=";
        private string strSql = string.Empty;

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtCodigoUsuario.Text == "" || txtUsuario.Text == "" || txtSenha.Text == "")
            {
                MessageBox.Show("Existem campos obrigatórios sem conteúdo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtConfirmarSenha.Text == txtSenha.Text)
            {

                strSql = "insert into usuario (id, nome, senha) values ('"+txtCodigoUsuario.Text +"','"+ txtUsuario.Text +"' , '"+ txtSenha.Text +"')";
                sqlCon = new MySqlConnection(strCon);
                MySqlCommand comando = new MySqlCommand(strSql, sqlCon);

                try
                {
                    sqlCon.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Cadastro realizado com sucesso!");
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Código de usuário ja existente!");
                }
                finally
                {
                    sqlCon.Close();
                }


            }
            else
            {
                MessageBox.Show("Senhas diferentes!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSenha.Text = ""; txtConfirmarSenha.Text = "";
                txtSenha.Focus();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtSenha.PasswordChar = '\0';
                txtConfirmarSenha.PasswordChar = '\0';
            }
            else
            {
                txtSenha.PasswordChar = '*';
                txtConfirmarSenha.PasswordChar = '*';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ListaFuncionario listaFuncionario = new ListaFuncionario(); ;
            //listaFuncionario.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtCodigoUsuario.Text == "")
            {
                MessageBox.Show("Existem campos obrigatórios sem conteúdo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                strSql = "DELETE FROM usuario WHERE id = '" + txtCodigoUsuario.Text + "'";
                sqlCon = new MySqlConnection(strCon);
                MySqlCommand comando = new MySqlCommand(strSql, sqlCon);

                try
                {
                    sqlCon.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Usuário exluído com sucesso!");
                    txtCodigoUsuario.Text = "";
                    txtConfirmarSenha.Text = "";
                    txtSenha.Text = "";
                    txtUsuario.Text = "";
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlCon.Close();
                }
            }
        }

        private void txtCodigoUsuario_Leave(object sender, EventArgs e)
        {
            if (txtCodigoUsuario.Text != "")
            {
                strSql = "SELECT * FROM usuario WHERE id='" + txtCodigoUsuario.Text + "'";
                sqlCon = new MySqlConnection(strCon);

                try
                {
                    sqlCon.Open();

                    MySqlCommand comando = new MySqlCommand(strSql, sqlCon);

                    MySqlDataReader reader = comando.ExecuteReader();

                    if (reader.Read())
                    {
                        txtCodigoUsuario.Text = reader.GetString(0);
                        txtUsuario.Text = reader.GetString(1);
                        txtSenha.Text = reader.GetString(2);
                    }

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlCon.Close();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtCodigoUsuario.Text = "";
            txtUsuario.Text = "";
            txtSenha.Text = "";
            txtConfirmarSenha.Text = "";
        }
    }
}
