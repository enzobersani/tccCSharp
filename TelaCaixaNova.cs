﻿using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        int quantidadeBanco = 0;
        decimal quantidadeTela= 0;

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
                if(txtQuantidade.Text == "0" || txtQuantidade.Text == "" || txtQuantidade.Text == "00" ||
                    txtQuantidade.Text == "00,0" || txtQuantidade.Text == "00,00")
                {
                    MessageBox.Show("Não é possível informar uma quantidade igual a zero!");
                    return;
                }

                validarQuantidadeEstoque();
                if (quantidadeBanco < quantidadeTela)
                {
                    txtQuantidade.Text = "";
                    txtQuantidade.Focus();
                    return;
                }   

                if (txtCodProduto.Text != "")
                {
                    string strSql = "insert into itensvenda(CD_PRODUTO, CD_VENDA) " +
                    "values('" + txtCodProduto.Text + "', '" + txtCodVenda.Text + "')";
                    Conexao = new MySqlConnection(strCon);
                    MySqlCommand comando = new MySqlCommand(strSql, Conexao);

                    try
                    {
                        Conexao.Open();
                        comando.ExecuteNonQuery();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        Conexao.Close();
                    }
                }

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

                    int lastIndex = dataGridView1.Rows.Count - 1;

                    if (lastIndex >= 0)
                    {
                        object lastValue = dataGridView1.Rows[lastIndex].Cells[columnIndex].Value;

                        foreach (DataGridViewRow row2 in dataGridView1.Rows)
                        {
                            if (lastValue != null && decimal.TryParse(lastValue.ToString(), out decimal valor))
                            {
                                Total += valor * Quantidade;
                                break;
                            }
                        }
                        txtValorTotal.Text = Total.ToString("F");
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

        private void TelaCaixaNova_Load(object sender, EventArgs e)
        {
            txtCodProduto.Enabled = false;
            txtQuantidade.Enabled = false;
            txtCodDesconto.Enabled = false;
            txtPagamento.Enabled = false;
            btnConfirmarVenda.Enabled = false;
            btnCancelarVenda.Enabled = false;
            txtPorPessoa.Enabled = false;
        }

        private void txtCodDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
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

                    txtValorTotal.Text = Total.ToString("F");

                    txtCodDesconto.Text = "";
                }
            }     
        }

        private void txtPorPessoa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                Total = Total / Convert.ToDecimal(txtPorPessoa.Text);

                txtValorPorPessoa.Text = Total.ToString("F");

                txtPorPessoa.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtCodProduto.Enabled = true;
            txtQuantidade.Enabled = true;
            txtCodDesconto.Enabled = true;
            txtPorPessoa.Enabled = true;
            txtPagamento.Enabled = true;
            btnConfirmarVenda.Enabled = true;
            btnCancelarVenda.Enabled = true;

            btnNovaVenda.Enabled = false;
            string strSql = "insert into vendas(CD_FUNCIONARIO) " +
                "values('" + txtFuncionario.Text + "')";
            Conexao = new MySqlConnection(strCon);
            MySqlCommand comando = new MySqlCommand(strSql, Conexao);

            try
            {
                Conexao.Open();
                comando.ExecuteNonQuery();
                MessageBox.Show("Venda iniciada!");
                string strSelect = "SELECT MAX(CD_VENDA) FROM vendas";

                MySqlCommand comando2 = new MySqlCommand(strSelect, Conexao);
                MySqlDataReader reader = comando2.ExecuteReader();
                if (reader.Read())
                {
                    txtCodVenda.Text = reader.GetString(0);
                }
                txtCodProduto.Focus();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Funcionário não cadastrado!");
                btnNovaVenda.Enabled = true;
                TelaCaixaNova_Load(sender, e);
            }
            finally
            {
                Conexao.Close();
            }
        }

        private void txtPagamento_Enter(object sender, EventArgs e)
        {
            try
            {
                Conexao = new MySqlConnection(strCon);

                string sql = "SELECT CD_PAGAMENTO, NM_PAGAMENTO FROM pagamento ORDER BY CD_PAGAMENTO";

                Conexao.Open();

                MySqlCommand comando = new MySqlCommand(sql, Conexao);

                MySqlDataReader reader = comando.ExecuteReader();

                List<String> items = new List<String>();

                txtPagamento.Items.Clear();
                while (reader.Read())
                {
                    var reader2 = reader.GetString(1);
                    items.Add(reader.GetString(0) + " - " + reader2);
                }

                Object[] itemobj = items.Cast<Object>().ToArray();
                txtPagamento.Items.AddRange(itemobj);

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

        private void btnConfirmarVenda_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count != 0)
            {

                quantidadeEstoque();

                string strSql = "UPDATE vendas SET CD_PAGAMENTO='" + txtPagamento.Text + "', QT_VALORTOTAL='" + txtValorTotal.Text + "'" +
                     " WHERE CD_VENDA='" + txtCodVenda.Text + "'";
                Conexao = new MySqlConnection(strCon);
                MySqlCommand comando = new MySqlCommand(strSql, Conexao);

                try
                {
                    Conexao.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Venda realizada com sucesso!");
                    txtCodProduto.Text = "";
                    txtQuantidade.Text = "";
                    txtCodDesconto.Text = "";
                    txtPagamento.Text = "";
                    txtPorPessoa.Text = "";
                    txtCodVenda.Text = "";
                    txtValorTotal.Text = "";
                    txtValorPorPessoa.Text = "";
                    btnNovaVenda.Enabled = true;
                    dataGridView1.Rows.Clear();
                    TelaCaixaNova_Load(sender, e);
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Campos obrigatórios não preenchido!");
                }
                finally
                {
                    Conexao.Close();
                }

                Total = 0;
            }
        }

        private void btnCancelarVenda_Click(object sender, EventArgs e)
        {
            if (txtCodVenda.Text != "")
            {
                string strSql = "DELETE FROM vendas WHERE CD_VENDA = '" + txtCodVenda.Text + "'";
                Conexao = new MySqlConnection(strCon);
                MySqlCommand comando = new MySqlCommand(strSql, Conexao);

                try
                {
                    Conexao.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Venda " + txtCodVenda.Text + " cancelada!");
                    txtCodVenda.Text = "";
                    txtCodProduto.Text = "";
                    txtQuantidade.Text = "";
                    txtCodDesconto.Text = "";
                    txtPagamento.Text = "";
                    txtPorPessoa.Text = "";
                    txtValorTotal.Text = "";
                    txtValorPorPessoa.Text = "";
                    btnNovaVenda.Enabled = true;
                    dataGridView1.Rows.Clear();
                    TelaCaixaNova_Load(sender, e);
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    Conexao.Close();
                }
                Total = 0;
            }

            if (dataGridView1.Rows.Count != 0)
            {
                string strSql = "DELETE FROM itensvenda WHERE CD_VENDA = '" + txtCodVenda.Text + "'";
                Conexao = new MySqlConnection(strCon);
                MySqlCommand comando = new MySqlCommand(strSql, Conexao);

                try
                {
                    Conexao.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Venda " + txtCodVenda.Text + " cancelada!");
                    txtCodVenda.Text = "";
                    txtCodProduto.Text = "";
                    txtQuantidade.Text = "";
                    txtCodDesconto.Text = "";
                    txtPagamento.Text = "";
                    txtPorPessoa.Text = "";
                    txtValorTotal.Text = "";
                    txtValorPorPessoa.Text = "";
                    btnNovaVenda.Enabled = true;
                    dataGridView1.Rows.Clear();
                    TelaCaixaNova_Load(sender, e);
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    Conexao.Close();
                }
                Total = 0;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if(txtCodVenda.Text != "")
            {
                MessageBox.Show("É necessário cancelar ou realizar a venda para sair!");
                btnCancelarVenda.Focus();
                return;
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow linhaSelecionada = dataGridView1.SelectedRows[0];

                int idSelecionado = Convert.ToInt32(linhaSelecionada.Cells["codigo"].Value);

                int quantidadeLinha = Convert.ToInt32(linhaSelecionada.Cells["quantidade"].Value);

                decimal valorLinha = Convert.ToDecimal(linhaSelecionada.Cells["valorUnit"].Value);

                string queryDelete = "DELETE FROM itensvenda WHERE CD_PRODUTO = @codigo";
                using (MySqlCommand cmd = new MySqlCommand(queryDelete, Conexao))
                {
                    Conexao.Open();
                    cmd.Parameters.AddWithValue("@codigo", idSelecionado);
                    cmd.ExecuteNonQuery();
                }

                dataGridView1.Rows.Remove(linhaSelecionada);
                MessageBox.Show("Produto excluído!");
                dataGridView1.DataSource = null;
                Conexao.Close();

                Total = Total - (quantidadeLinha * valorLinha);
                txtValorTotal.Text = Total.ToString("F");
            }

        }

        private void txtFuncionario_DoubleClick(object sender, EventArgs e)
        {
            ListaFuncionario listaFuncionario = new ListaFuncionario();
            listaFuncionario.ShowDialog();
        }

        private void txtCodProduto_DoubleClick(object sender, EventArgs e)
        {
            ListaProduto listaProduto = new ListaProduto();
            listaProduto.ShowDialog();
        }

        internal void validarQuantidadeEstoque()
        {
            if (txtQuantidade.Text != "" || txtQuantidade.Text != "0")
            {
                try
                {
                    quantidadeTela = Convert.ToDecimal(txtQuantidade.Text);

                    Conexao = new MySqlConnection(strCon);

                    string sql = "SELECT qtEstoque " +
                                "FROM produto " +
                                "WHERE id=" + txtCodProduto.Text;

                    Conexao.Open();

                    MySqlCommand comando = new MySqlCommand(sql, Conexao);

                    MySqlDataReader reader = comando.ExecuteReader();

                    if (reader.Read())
                    {
                        quantidadeBanco = reader.GetInt32(0);
                    }

                    if (quantidadeBanco < quantidadeTela)
                    {
                        MessageBox.Show("Quantidade informada é maior que possui no estoque!");
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
            }
        }

        internal void quantidadeEstoque()
        {

            DataGridViewRowCollection rows = dataGridView1.Rows;
            DataGridViewRowCollection col = dataGridView1.Rows;
            List<string> produtos = new List<string>();
            List<string> quantidades = new List<string>();
            string codigo = string.Empty;
            string codigo2 = string.Empty;
            foreach (DataGridViewRow row in rows)
            {
                DataGridViewCell cell = row.Cells["codigo"];
                DataGridViewCell cell2 = row.Cells["quantidade"];
                codigo = cell.Value.ToString();
                codigo2 = cell2.Value.ToString();
                produtos.Add(codigo);
                quantidades.Add(codigo2);

                string strUpdate = "UPDATE produto SET qtEstoque = qtEstoque -'" + codigo2 + "' WHERE id= '" + codigo + "'";
                Conexao = new MySqlConnection(strCon);
                MySqlCommand comando = new MySqlCommand(strUpdate, Conexao);

                try
                {
                    Conexao.Open();
                    comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    Conexao.Close();
                }
            }
        }
    }
}
