using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TccRestaurante
{
    public partial class TelaCadastrodeDesconto : Form
    {
        public TelaCadastrodeDesconto()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        MySqlConnection sqlCon = null;
        private string strCon = "Server = localhost; Database=restaurantetcc;Uid=root;Pwd=";
        private string strSql = string.Empty;

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtCodigoDesc.Text == "" || txtDescricaoDesc.Text == "" || txtReais.Text == "")
            {
                MessageBox.Show("Existem campos obrigatórios sem conteúdo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                strSql = "insert into desconto (CD_DESCONTO, DS_DESCONTO, QT_REAIS) values ('" + txtCodigoDesc.Text + "','" + txtDescricaoDesc.Text + "','" + txtReais.Text + "')";
                sqlCon = new MySqlConnection(strCon);
                MySqlCommand comando = new MySqlCommand(strSql, sqlCon);

                try
                {
                    sqlCon.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Cadastro realizado com sucesso!");
                    txtCodigoDesc.Text = "";
                    txtDescricaoDesc.Text = "";
                    txtReais.Text = "";
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

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtCodigoDesc.Text == "")
            {
                MessageBox.Show("Existem campos obrigatórios sem conteúdo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                strSql = "DELETE FROM desconto WHERE CD_DESCONTO = '" + txtCodigoDesc.Text + "'";
                sqlCon = new MySqlConnection(strCon);
                MySqlCommand comando = new MySqlCommand(strSql, sqlCon);

                try
                {
                    sqlCon.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Desconto excluído com sucesso!");
                    btnSalvar.Enabled = true;
                    txtCodigoDesc.Text = "";
                    txtDescricaoDesc.Text = "";
                    txtReais.Text = "";
                    txtCodigoDesc.Focus();
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

        private void txtCodigoDesc_Leave(object sender, EventArgs e)
        {
            if (txtCodigoDesc.Text != "")
            {

                strSql = "SELECT * FROM desconto WHERE CD_DESCONTO='" + txtCodigoDesc.Text + "'";
                sqlCon = new MySqlConnection(strCon);

                try
                {
                    sqlCon.Open();

                    MySqlCommand comando = new MySqlCommand(strSql, sqlCon);

                    MySqlDataReader reader = comando.ExecuteReader();

                    if (reader.Read())
                    {
                        btnAtualizar.Enabled = true;
                        btnSalvar.Enabled = false;
                        txtCodigoDesc.Text = reader.GetString(0);
                        txtDescricaoDesc.Text = reader.GetString(1);
                        txtReais.Text = reader.GetString(2);                   
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
                
                if(txtCodigoDesc.Text == "")
                    btnAtualizar.Enabled = false;
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtCodigoDesc.Text = string.Empty;
            txtDescricaoDesc.Text = string.Empty;
            txtReais.Text = string.Empty;
            btnAtualizar.Enabled = false;
            btnSalvar.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtCodigoDesc.Text == "" || txtDescricaoDesc.Text == "" || txtReais.Text == "")
            {
                MessageBox.Show("Existem campos obrigatórios sem conteúdo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                strSql = "UPDATE desconto SET DS_DESCONTO='" + txtDescricaoDesc.Text + "', QT_REAIS='" + txtReais.Text + 
                    "' WHERE CD_DESCONTO='" + txtCodigoDesc.Text + "'";
                sqlCon = new MySqlConnection(strCon);
                MySqlCommand comando = new MySqlCommand(strSql, sqlCon);

                try
                {
                    sqlCon.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Cadastro realizado com sucesso!");
                    txtCodigoDesc.Text = "";
                    txtDescricaoDesc.Text = "";
                    txtReais.Text = "";
                    txtCodigoDesc.Focus();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Código de desconto ja existente!");
                }
                finally
                {
                    sqlCon.Close();
                }
            }
            btnAtualizar.Enabled = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ListaDesconto listaDesconto = new ListaDesconto();
            listaDesconto.ShowDialog();
        }
    }
}
