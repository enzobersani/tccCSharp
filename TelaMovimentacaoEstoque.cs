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
    public partial class TelaMovimentacaoEstoque : Form
    {
        public TelaMovimentacaoEstoque()
        {
            InitializeComponent();
        }

        MySqlConnection sqlCon = null;
        private string strCon = "Server = localhost; Database=restaurantetcc;Uid=root;Pwd=";
        private string strSql = string.Empty;

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            ListaProduto listaProduto = new ListaProduto();
            listaProduto.ShowDialog();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if(txtCodigoProduto.Text != "")
            {
                strSql = "SELECT * FROM produto WHERE id='" + txtCodigoProduto.Text + "'";
                sqlCon = new MySqlConnection(strCon);

                try
                {
                    sqlCon.Open();

                    MySqlCommand comando = new MySqlCommand(strSql, sqlCon);

                    MySqlDataReader reader = comando.ExecuteReader();

                    if (reader.Read())
                    {
                        //txtCodigoProduto.Text = reader.GetString(0);
                        txtDescricaoProduto.Text = reader.GetString(1);
                        txtQtAtual.Text = reader.GetString(4);
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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if(txtCodigoProduto.Text != "")
            {
                if (btnAdicionar.Checked)
                {
                    strSql = $"UPDATE produto SET  qtEstoque= qtEstoque + {txtQtMudar.Text} WHERE id = {txtCodigoProduto.Text}";
                    sqlCon = new MySqlConnection(strCon);
                    MySqlCommand comando = new MySqlCommand(strSql, sqlCon);

                    try
                    {
                        sqlCon.Open();
                        comando.ExecuteNonQuery();
                        MessageBox.Show("Alteração realizada com sucesso!");
                        txtCodigoProduto.Text = "";
                        txtDescricaoProduto.Text = "";
                        txtQtAtual.Text = "";
                        txtQtMudar.Text = "";
                        txtCodigoProduto.Focus();
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

                if (btnRemover.Checked)
                {
                    strSql = $"UPDATE produto SET  qtEstoque= qtEstoque - {txtQtMudar.Text} WHERE id = {txtCodigoProduto.Text}";
                    sqlCon = new MySqlConnection(strCon);
                    MySqlCommand comando = new MySqlCommand(strSql, sqlCon);

                    try
                    {
                        sqlCon.Open();
                        comando.ExecuteNonQuery();
                        MessageBox.Show("Alteração realizada com sucesso!");
                        txtCodigoProduto.Text = "";
                        txtDescricaoProduto.Text = "";
                        txtQtAtual.Text = "";
                        txtQtMudar.Text = "";
                        txtCodigoProduto.Focus();
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
        }

        private void btnLimparTela_Click(object sender, EventArgs e)
        {
            txtCodigoProduto.Text = "";
            txtDescricaoProduto.Text = "";
            txtQtAtual.Text = "";
            txtQtMudar.Text = "";
        }

        private void btnAdicionar_Enter(object sender, EventArgs e)
        {
            if (btnAdicionar.Checked)
            {
                labelQtMudar.Text = "Qt. a remover";
            }
            else
            {
                labelQtMudar.Text = "Qt. a adicionar";
            }
        }

        private void btnRemover_Enter(object sender, EventArgs e)
        {
            if (btnAdicionar.Checked)
            {
                labelQtMudar.Text = "Qt. a remover";
            }
            else
            {
                labelQtMudar.Text = "Qt. a adicinoar";
            }
        }
    }
}
