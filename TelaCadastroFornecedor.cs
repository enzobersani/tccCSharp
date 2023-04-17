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

namespace TccRestaurante
{
    public partial class TelaCadastroFornecedor : Form
    {
        public TelaCadastroFornecedor()
        {
            InitializeComponent();
        }

        MySqlConnection sqlCon = null;
        private string strCon = "Server = localhost; Database=restaurantetcc;Uid=root;Pwd=";
        private string strSql = string.Empty;

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtIdFornecedor.Text == "" || txtNomeFornecedor.Text == "")
            {
                MessageBox.Show("Existem campos obrigatórios sem conteúdo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                strSql = "insert into fornecedor (idFornecedor, nomeFornecedor) values ('" + txtIdFornecedor.Text + "','" + txtNomeFornecedor.Text + "')";
                sqlCon = new MySqlConnection(strCon);
                MySqlCommand comando = new MySqlCommand(strSql, sqlCon);

                try
                {
                    sqlCon.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Cadastro realizado com sucesso!");
                    txtIdFornecedor.Text = "";
                    txtNomeFornecedor.Text = "";
                    txtIdFornecedor.Focus();
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
            button1.Enabled = true;
            txtIdFornecedor.Text = "";
            txtNomeFornecedor.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtIdFornecedor.Text == "")
            {
                MessageBox.Show("Existem campos obrigatórios sem conteúdo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                strSql = "DELETE FROM fornecedor WHERE idFornecedor = '" + txtIdFornecedor.Text + "'";
                sqlCon = new MySqlConnection(strCon);
                MySqlCommand comando = new MySqlCommand(strSql, sqlCon);

                try
                {
                    sqlCon.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Produto exluído com sucesso!");
                    button1.Enabled = true;
                    txtIdFornecedor.Text = "";
                    txtNomeFornecedor.Text = "";
                    txtIdFornecedor.Focus();
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtIdFornecedor.Text == "" || txtNomeFornecedor.Text == "")
            {
                MessageBox.Show("Existem campos obrigatórios sem conteúdo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                strSql = "UPDATE fornecedor SET nomeFornecedor='" + txtNomeFornecedor.Text + "' WHERE idFornecedor='" + txtIdFornecedor.Text + "'";
                sqlCon = new MySqlConnection(strCon);
                MySqlCommand comando = new MySqlCommand(strSql, sqlCon);

                try
                {
                    sqlCon.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Cadastro realizado com sucesso!");
                    txtIdFornecedor.Text = "";
                    txtNomeFornecedor.Text = "";
                    txtIdFornecedor.Focus();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Código de produto ja existente!");
                }
                finally
                {
                    sqlCon.Close();
                }
            }
        }

        private void txtIdFornecedor_Leave(object sender, EventArgs e)
        {
            if (txtIdFornecedor.Text != "")
            {

                strSql = "SELECT * FROM fornecedor WHERE idFornecedor='" + txtIdFornecedor.Text + "'";
                sqlCon = new MySqlConnection(strCon);

                try
                {
                    sqlCon.Open();

                    MySqlCommand comando = new MySqlCommand(strSql, sqlCon);

                    MySqlDataReader reader = comando.ExecuteReader();

                    if (reader.Read())
                    {
                        button1.Enabled = false;
                        txtIdFornecedor.Text = reader.GetString(0);
                        txtNomeFornecedor.Text = reader.GetString(1);
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
            ListaFornecedor listaFornecedor = new ListaFornecedor();
            listaFornecedor.ShowDialog();
        }
    }
 }

