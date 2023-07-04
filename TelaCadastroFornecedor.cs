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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

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

                strSql = "insert into fornecedor (idFornecedor, nomeFornecedor, NM_RAZAO, NM_ENDERECO, NR_NUMERO, DS_COMPLEMENTO" +
                    ", NM_CIDADE, NM_UF, CD_CNPJ, DS_EMAIL) values ('" + txtIdFornecedor.Text + "','" + txtNomeFornecedor.Text + "'," +
                    "'" + txtRazaoSocial.Text + "', '" + txtEndereco.Text + "', '" + txtNumero.Text + "'," +
                    "'" + txtComplemento.Text + "', '" + txtCidade.Text + "', '" + txtUf.Text + "', '" + txtCNPJ.Text + "'," +
                    "'" + txtEmail.Text + "')";
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
                    foreach (Control control in groupBox1.Controls)
                    {
                        if (control is TextBox)
                        {
                            TextBox textBox = (TextBox)control;
                            textBox.Text = string.Empty;
                        }
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
            button1.Enabled = true;
            foreach (Control control in groupBox1.Controls)
            {
                if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;
                    textBox.Text = string.Empty;
                }
            }
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

        private void txtIdFornecedor_DoubleClick(object sender, EventArgs e)
        {
            ListaFornecedor listaFornecedor = new ListaFornecedor();
            listaFornecedor.ShowDialog();
        }
    }
 }

