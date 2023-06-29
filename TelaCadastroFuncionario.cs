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
    public partial class TelaCadastroFuncionario : Form
    {
        public TelaCadastroFuncionario()
        {
            InitializeComponent();
        }

        MySqlConnection sqlCon = null;
        private string strCon = "Server = localhost; Database=restaurantetcc;Uid=root;Pwd=";
        private string strSql = string.Empty;

        private void label8_Click(object sender, EventArgs e)
        {

        }
        
        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            txtCodigoFuncionario.Text = "";
            txtNomeFuncionario.Text = "";
            mskCpf.Text = "";
            mskDataNascimento.Text = "";
            mskCelular.Text = "";
            txtLogradouro.Text = "";
            txtNumero.Text = "";
            txtBairro.Text = "";
            txtTipo.Text = "";
            txtEmail.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtCodigoFuncionario.Text == "" || txtNomeFuncionario.Text == "" || mskCpf.Text == "" || mskDataNascimento.Text == "" ||
                                                   txtLogradouro.Text == "" || txtNumero.Text == "" || txtBairro.Text == "")
            {
                MessageBox.Show("Existem campos obrigatórios sem conteúdo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                strSql = "insert into funcionario (id, nome, cpf, dtNascimento, celular, logradouro, numero, bairro, tipo, email) " +
                    "values ('" + txtCodigoFuncionario.Text + "', '" + txtNomeFuncionario.Text + "','" + mskCpf.Text + "', '" + mskDataNascimento.Text + "'," +
                    " '" + mskCelular.Text + "','" + txtLogradouro.Text +"', '"+ txtNumero.Text +"', '"+ txtBairro.Text +"', '"+ txtTipo.Text +"', '"+ txtEmail.Text +"')";
                sqlCon = new MySqlConnection(strCon);
                MySqlCommand comando = new MySqlCommand(strSql, sqlCon);

                try
                {
                    sqlCon.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Cadastro realizado com sucesso!");
                    txtCodigoFuncionario.Text = "";
                    txtNomeFuncionario.Text = "";
                    mskCpf.Text = "";
                    mskDataNascimento.Text = "";
                    mskCelular.Text = "";
                    txtLogradouro.Text = "";
                    txtNumero.Text = "";
                    txtBairro.Text = "";
                    txtTipo.Text = "";
                    txtEmail.Text = "";
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Código de funcionário ja existente");
                }
                finally
                {
                    sqlCon.Close();
                }


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ListaFuncionario listaFuncionario = new ListaFuncionario();
            listaFuncionario.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtCodigoFuncionario.Text == "")
            {
                MessageBox.Show("Existem campos obrigatórios sem conteúdo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                strSql = "DELETE FROM funcionario WHERE id = '" + txtCodigoFuncionario.Text + "'";
                sqlCon = new MySqlConnection(strCon);
                MySqlCommand comando = new MySqlCommand(strSql, sqlCon);

                try
                {
                    sqlCon.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Funcionário exluído com sucesso!");
                    button1.Enabled = true;
                    txtCodigoFuncionario.Text = "";
                    txtNomeFuncionario.Text = "";
                    mskCelular.Text = "";
                    mskCpf.Text = "";
                    mskDataNascimento.Text = "";
                    txtLogradouro.Text = "";
                    txtBairro.Text = "";
                    txtNumero.Text = "";
                    txtTipo.Text = "";
                    txtEmail.Text = "";

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

        private void txtCodigoFuncionario_Leave(object sender, EventArgs e)
        {
            if (txtCodigoFuncionario.Text != "")
            {
                strSql = "SELECT * FROM funcionario WHERE id='" + txtCodigoFuncionario.Text + "'";
                sqlCon = new MySqlConnection(strCon);

                try
                {
                    sqlCon.Open();

                    MySqlCommand comando = new MySqlCommand(strSql, sqlCon);

                    MySqlDataReader reader = comando.ExecuteReader();

                    if (reader.Read())
                    {
                        button1.Enabled = false;
                        txtCodigoFuncionario.Text = reader.GetString(0);
                        txtNomeFuncionario.Text = reader.GetString(1);
                        mskCpf.Text = reader.GetString(2);
                        mskDataNascimento.Text = reader.GetString(3);
                        mskCelular.Text = reader.GetString(4);
                        txtLogradouro.Text = reader.GetString(5);
                        txtNumero.Text = Convert.ToString(reader.GetInt32(6));
                        txtBairro.Text = reader.GetString(7);
                        txtTipo.Text = reader.GetString(8);
                        txtEmail.Text = reader.GetString(9);

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

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtCodigoFuncionario.Text == "" || txtNomeFuncionario.Text == "" || mskCpf.Text == "" || mskDataNascimento.Text == "" ||
                                                   txtLogradouro.Text == "" || txtNumero.Text == "" || txtBairro.Text == "")
            {
                MessageBox.Show("Existem campos obrigatórios sem conteúdo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                strSql = "UPDATE funcionario SET nome= '" + txtNomeFuncionario.Text + "', cpf= '" + mskCpf.Text + "', dtNascimento= '" + mskDataNascimento.Text + "', " +
                    "celular= '" + mskCelular.Text + "', logradouro= '" + txtLogradouro.Text + "', numero= '" + txtNumero.Text + "', bairro= '" + txtBairro.Text + "', tipo= '" + txtTipo.Text + "', email='" + txtEmail.Text + "' WHERE id = '"+txtCodigoFuncionario.Text+"'";

                sqlCon = new MySqlConnection(strCon);
                MySqlCommand comando = new MySqlCommand(strSql, sqlCon);

                try
                {
                    sqlCon.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Cadastro realizado com sucesso!");
                    txtCodigoFuncionario.Text = "";
                    txtNomeFuncionario.Text = "";
                    mskCpf.Text = "";
                    mskDataNascimento.Text = "";
                    mskCelular.Text = "";
                    txtLogradouro.Text = "";
                    txtNumero.Text = "";
                    txtBairro.Text = "";
                    txtTipo.Text = "";
                    txtEmail.Text = "";
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Código de funcionário ja existente");
                }
                finally
                {
                    sqlCon.Close();
                }
            }
        }
    }
}
