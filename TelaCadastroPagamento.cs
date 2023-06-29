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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace TccRestaurante
{
    public partial class TelaCadastroPagamento : Form
    {
        public TelaCadastroPagamento()
        {
            InitializeComponent();
        }

        MySqlConnection sqlCon = null;
        private string strCon = "Server = localhost; Database=restaurantetcc;Uid=root;Pwd=";
        private string strSql = string.Empty;

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtCodigoPagamento.Text == "" || txtNomePagamento.Text == "")
            {
                MessageBox.Show("Existem campos obrigatórios sem conteúdo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                strSql = "insert into pagamento (CD_PAGAMENTO, NM_PAGAMENTO, DS_PAGAMENTO) " +
                    "values ('" + txtCodigoPagamento.Text + "','" + txtNomePagamento.Text + "','" + txtDescricaoPagamento.Text + "')";
                sqlCon = new MySqlConnection(strCon);
                MySqlCommand comando = new MySqlCommand(strSql, sqlCon);

                try
                {
                    sqlCon.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Cadastro realizado com sucesso!");
                    txtCodigoPagamento.Text = "";
                    txtNomePagamento.Text = "";
                    txtDescricaoPagamento.Text = "";
                    txtCodigoPagamento.Focus();
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

        private void button2_Click(object sender, EventArgs e)
        {
            ListaPagamentosUtilizados listaPagamentosUtilizados = new ListaPagamentosUtilizados();
            listaPagamentosUtilizados.ShowDialog();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            foreach (Control control in groupBox1.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Text = string.Empty;
                }
            }

            btnSalvar.Enabled = true;
            btnAtualizar.Enabled = false;
        }

        private void txtCodigoPagamento_Leave(object sender, EventArgs e)
        {
            if (txtCodigoPagamento.Text != "")
            {

                strSql = "SELECT * FROM pagamento WHERE CD_PAGAMENTO='" + txtCodigoPagamento.Text + "'";
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
                        txtNomePagamento.Text = reader.GetString(1);
                        txtDescricaoPagamento.Text = reader.GetString(2);
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
    }
}
