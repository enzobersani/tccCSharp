using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
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
    public partial class TelaCaixaNova : Form
    {
        public TelaCaixaNova()
        {
            InitializeComponent();
        }

        decimal Total = 0;
        decimal Quantidade = 0;
        decimal ValorDesc = 0;

        MySqlConnection Conexao = null;
        private string strCon = "Server = localhost; Database=restaurantetcc;Uid=root;Pwd=";

        private void txtPagamento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtCodProduto_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
            {
                Quantidade = Convert.ToDecimal(txtQuantidade.Text);
                try
                {
                    Conexao = new MySqlConnection(strCon);

                    string sql = "SELECT * FROM produto WHERE id = " + txtCodProduto.Text;

                    Conexao.Open();

                    MySqlCommand comando = new MySqlCommand(sql, Conexao);

                    MySqlDataReader reader = comando.ExecuteReader();



                    while (reader.Read())
                    {
                        string[] row =
                        {
                        reader.GetString(0),
                        reader.GetString(1),
                        Quantidade.ToString(),
                        reader.GetString(3)
                    };


                        if (row[0] != null)
                        {
                            dataGridView1.Rows.Add(row[0], row[1], Quantidade, row[3]);
                        }

                    }

                    int columnIndex = dataGridView1.Columns["valorUnit"].Index;

                    // Obtenha o índice da última linha do DataGridView
                    int lastIndex = dataGridView1.Rows.Count - 1;

                    // Verifique se o índice da última linha é válido
                    if (lastIndex >= 0)
                    {
                        // Obtenha o valor da célula da coluna desejada na última linha
                        object lastValue = dataGridView1.Rows[lastIndex].Cells[columnIndex].Value;

                        foreach (DataGridViewRow row2 in dataGridView1.Rows)
                        {
                            // Verifique se a célula não é nula e se o valor é um número válido
                            //if (row2.Cells["valorUnit"].Value != null && decimal.TryParse(row2.Cells["valorUnit"].Value.ToString(), out decimal valor))
                            if (lastValue != null && decimal.TryParse(lastValue.ToString(), out decimal valor))
                            {
                                //decimal quantidadeUnit = decimal.Parse(row2.Cells["quantidade"].Value.ToString());

                                Total += valor * Quantidade;
                                break;
                            }
                        }

                        // Exiba o valor total em algum lugar (por exemplo, em uma label)
                        txtValorTotal.Text = Total.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    Conexao.Close();
                }

                txtCodProduto.Text = "";
                txtQuantidade.Text = "";
                txtCodProduto.Focus();
            }
        }

        private void txtCodDesconto_Leave(object sender, EventArgs e)
        {
            if (txtCodDesconto.Text != "")
            {
                try
                {
                    string codigoDesc = txtCodDesconto.Text;

                    Conexao = new MySqlConnection(strCon);

                    string sql = "SELECT * " +
                                "FROM desconto " +
                                "WHERE CD_DESCONTO=" + codigoDesc;

                    Conexao.Open();

                    MySqlCommand comando = new MySqlCommand(sql, Conexao);

                    MySqlDataReader reader = comando.ExecuteReader();

                    if (reader.Read())
                    {
                        ValorDesc = reader.GetDecimal(2);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Desconto não encontrado!");
                }
                finally
                {
                    Conexao.Close();
                }

                Total = Total - ValorDesc;

                txtValorTotal.Text = Total.ToString();

                txtCodDesconto.Text = "";
            }
        }

        private void TelaCaixaNova_Load(object sender, EventArgs e)
        {
            try
            {

                Conexao = new MySqlConnection(strCon);

                string sql = "SELECT CD_PAGAMENTO, NM_PAGAMENTO FROM pagamento ORDER BY CD_PAGAMENTO";

                Conexao.Open();

                MySqlCommand comando = new MySqlCommand(sql, Conexao);

                MySqlDataReader reader = comando.ExecuteReader();

                txtPagamento.Items.Clear();
                while (reader.Read())
                {
                    txtPagamento.Items.Add(reader.GetString(1));
                    txtPagamento.DisplayMember = "NM_PAGAMENTO";
                    txtPagamento.ValueMember = "CD_PAGAMENTO";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Formas de pagamentos não encontradas!");
            }
            finally
            {
                Conexao.Close();
            }

        }
    }
}
