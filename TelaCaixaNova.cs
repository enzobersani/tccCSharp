﻿using DGVPrinterHelper;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TccRestaurante.Properties;
using System.Collections.Specialized;

namespace TccRestaurante
{
    public partial class TelaCaixaNova : Form
    {

        private DataGridView dataGridView;
        private DataTable dataTable;
        public TelaCaixaNova()
        {
            InitializeComponent();
        }
        decimal Total = 0;
        decimal Quantidade = 0;
        decimal ValorDesc = 0;
        bool botaoClick;
        bool dadosSalvos;
        bool autorizarFechamento = false;

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
                    string strSql = "insert into itensvenda(CD_PRODUTO, CD_VENDA, QT_PRODUTO) " +
                    "values('" + txtCodProduto.Text + "', '" + txtCodVenda.Text + "', '" + txtQuantidade.Text + "')";
                    Conexao = new MySqlConnection(strCon);
                    MySqlCommand comando = new MySqlCommand(strSql, Conexao);

                    try
                    {
                        Conexao.Open();
                        comando.ExecuteNonQuery();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Produto não cadastrado!");
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
                        reader.GetString(3),
                        reader.GetString(4)
                    };


                        if (row[0] != null)
                        {
                            dataGridView1.Rows.Add(row[0], row[1], Quantidade, row[3]);
                        }

                    }

                    int columnIndex = dataGridView1.Columns["valorProduto"].Index;

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
            txtValorPago.Enabled = false;
            txtValorTroco.Enabled = false;
            if (Owner is TelaMesas) 
                CarregarDados();



























            //if (txtCodVenda.Text != "")
            //{
            //    txtCodProduto.Enabled = true;
            //    txtQuantidade.Enabled = true;
            //    txtCodDesconto.Enabled = true;
            //    txtPorPessoa.Enabled = true;
            //    txtPagamento.Enabled = true;
            //    btnConfirmarVenda.Enabled = true;
            //    btnCancelarVenda.Enabled = true;
            //    txtFuncionario.Enabled = false;

            //    btnNovaVenda.Enabled = false;
            //    if (Owner is TelaMesas)
            //    {
            //        if (txtCodigoMesa.Text != "")
            //        {
            //            string sql = $"SELECT iv.CD_PRODUTO FROM vendas v JOIN itensvenda iv ON v.CD_VENDA = iv.CD_VENDA WHERE v.CD_MESA = {txtCodigoMesa.Text}";
            //            Conexao = new MySqlConnection(strCon);
            //            MySqlCommand comando = new MySqlCommand(sql, Conexao);


            //            try
            //            {
            //                Conexao.Open();
            //                MySqlDataReader reader = comando.ExecuteReader();



            //                while (reader.Read())
            //                {
            //                    string[] row =
            //                    {
            //                reader.GetString(0),
            //                };

            //                    dataGridView1.Rows.Clear();
            //                    dataGridView1.Rows.Add(row[0]);
            //                }

            //            }

            //            catch (Exception ex)
            //            {
            //                MessageBox.Show(ex.Message);
            //            }
            //            finally
            //            {
            //                Conexao.Close();
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    txtCodProduto.Enabled = false;
            //    txtQuantidade.Enabled = false;
            //    txtCodDesconto.Enabled = false;
            //    txtPagamento.Enabled = false;
            //    btnConfirmarVenda.Enabled = false;
            //    btnCancelarVenda.Enabled = false;
            //    txtPorPessoa.Enabled = false;
            //}
            
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
            txtValorPago.Enabled = true;

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
                //MessageBox.Show(ex.Message);
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
                Properties.Settings.Default.DataGrid.Clear();
                Properties.Settings.Default.Save();
                quantidadeEstoque();

                if (txtCodigoMesa.Text != "")
                {
                    string strSql = "UPDATE vendas SET DT_VENDA='" + DateTime.Now.ToString("yyyy-MM-dd") + "', CD_PAGAMENTO='" + txtPagamento.Text + "', " +
                        "QT_VALORTOTAL='" + txtValorTotal.Text + "', CD_MESA='" + txtCodigoMesa.Text + "'" +
                         " WHERE CD_VENDA='" + txtCodVenda.Text + "'";
                    Conexao = new MySqlConnection(strCon);
                    MySqlCommand comando = new MySqlCommand(strSql, Conexao);

                    try
                    {
                        Conexao.Open();
                        comando.ExecuteNonQuery();
                        string mensagem = "Venda realizada com sucesso, deseja gerar relatório? \nDeseja gerar o relatório da venda?";
                        string caption = "Teste de retorno";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result;

                        result = MessageBox.Show(mensagem, caption, buttons);
                        if (result == DialogResult.Yes)
                        {
                            String pasta_aplicacao = Application.StartupPath + @"\";

                            DGVPrinter printer = new DGVPrinter();



                            printer.printDocument.DefaultPageSettings.Landscape = true;

                            DGVPrinter.ImbeddedImage img1 = new DGVPrinter.ImbeddedImage();
                            Image img = Image.FromFile(pasta_aplicacao + @"images\logo.jpg");
                            Bitmap bitmap1 = new Bitmap(img);
                            //printer.printDocument.DefaultPageSettings.Margins.Top = 150;

                            Bitmap newImage = ResizeBitmap(bitmap1, 100, 100);
                            img1.theImage = newImage; img1.ImageX = 100; img1.ImageY = 20;
                            img1.ImageAlignment = DGVPrinter.Alignment.Center;
                            img1.ImageLocation = DGVPrinter.Location.Absolute;
                            printer.ImbeddedImageList.Add(img1);

                            printer.Title = "Restaurante Mister Lee\n";
                            printer.SubTitle = "Relatório venda " + txtCodVenda.Text + " \n Valor Total: " +
                                txtValorTotal.Text + "R$\n\n";
                            printer.TitleSpacing = 70;
                            printer.SubTitleBackground = new SolidBrush(Color.Sienna);
                            printer.Footer = "Telefone 3018-2508\nAv.Edson de Lima Souto \n\n " + DateTime.Now.ToShortDateString();

                            printer.PrintPreviewDataGridView(dataGridView1);
                        }


                        txtCodProduto.Text = "";
                        txtQuantidade.Text = "";
                        txtCodDesconto.Text = "";
                        txtPagamento.Text = "";
                        txtPorPessoa.Text = "";
                        txtCodVenda.Text = "";
                        txtValorTotal.Text = "";
                        txtValorPorPessoa.Text = "";
                        txtValorPago.Text = "";
                        txtValorTroco.Text = "";
                        btnNovaVenda.Enabled = true;
                        dataGridView1.Rows.Clear();
                        TelaCaixaNova_Load(sender, e);
                    }

                    catch (Exception ex)
                    {
                        // MessageBox.Show("Campos obrigatórios não preenchido!");
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        Conexao.Close();
                    }
                }
                else
                {
                    string strSql = "UPDATE vendas SET DT_VENDA='" + DateTime.Now.ToString("yyyy-MM-dd") + "', CD_PAGAMENTO='" + txtPagamento.Text + "', " +
                   "QT_VALORTOTAL='" + txtValorTotal.Text +
                   "' WHERE CD_VENDA='" + txtCodVenda.Text + "'";
                    Conexao = new MySqlConnection(strCon);
                    MySqlCommand comando = new MySqlCommand(strSql, Conexao);

                    try
                    {
                        Conexao.Open();
                        comando.ExecuteNonQuery();
                        string mensagem = "Venda realizada com sucesso, deseja gerar relatório? \nDeseja gerar o relatório da venda?";
                        string caption = "Teste de retorno";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result;

                        result = MessageBox.Show(mensagem, caption, buttons);
                        if (result == DialogResult.Yes)
                        {
                            String pasta_aplicacao = Application.StartupPath + @"\";

                            DGVPrinter printer = new DGVPrinter();



                            printer.printDocument.DefaultPageSettings.Landscape = true;

                            DGVPrinter.ImbeddedImage img1 = new DGVPrinter.ImbeddedImage();
                            Image img = Image.FromFile(pasta_aplicacao + @"images\logo.jpg");
                            Bitmap bitmap1 = new Bitmap(img);
                            //printer.printDocument.DefaultPageSettings.Margins.Top = 150;

                            Bitmap newImage = ResizeBitmap(bitmap1, 100, 100);
                            img1.theImage = newImage; img1.ImageX = 100; img1.ImageY = 20;
                            img1.ImageAlignment = DGVPrinter.Alignment.Center;
                            img1.ImageLocation = DGVPrinter.Location.Absolute;
                            printer.ImbeddedImageList.Add(img1);

                            printer.Title = "Restaurante Mister Lee\n";
                            printer.SubTitle = "Relatório venda " + txtCodVenda.Text + " \n Valor Total: " +
                                txtValorTotal.Text + "R$\n\n";
                            printer.TitleSpacing = 70;
                            printer.SubTitleBackground = new SolidBrush(Color.Sienna);
                            printer.Footer = "Telefone 3018-2508\nAv.Edson de Lima Souto \n\n " + DateTime.Now.ToShortDateString();

                            printer.PrintPreviewDataGridView(dataGridView1);
                        }


                        txtCodProduto.Text = "";
                        txtQuantidade.Text = "";
                        txtCodDesconto.Text = "";
                        txtPagamento.Text = "";
                        txtPorPessoa.Text = "";
                        txtCodVenda.Text = "";
                        txtValorTotal.Text = "";
                        txtValorPorPessoa.Text = "";
                        txtValorPago.Text = "";
                        txtValorTroco.Text = "";
                        btnNovaVenda.Enabled = true;
                        dataGridView1.Rows.Clear();
                        TelaCaixaNova_Load(sender, e);
                    }

                    catch (Exception ex)
                    {
                        // MessageBox.Show("Campos obrigatórios não preenchido!");
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        Conexao.Close();
                    }
                }

                alterarSituacaoMesa0();

                Total = 0;
            }
        }

        public Bitmap ResizeBitmap(Bitmap bmp, int width, int height)
        {
            Bitmap result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.DrawImage(bmp, 0, 0, width, height);
            }

            return result;
        }

        private void btnCancelarVenda_Click(object sender, EventArgs e)
        {
            if (txtCodVenda.Text != "")
            {
                Properties.Settings.Default.DataGrid.Clear();
                Properties.Settings.Default.Save();
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
            if(txtCodVenda.Text != "" && botaoClick != true)
            {
                MessageBox.Show("É necessário cancelar ou realizar a venda para sair!");
                btnCancelarVenda.Focus();
                return;
            //}else if(autorizarFechamento == true){
            //    this.Close();
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow linhaSelecionada = dataGridView1.SelectedRows[0];

                int idSelecionado = Convert.ToInt32(linhaSelecionada.Cells["codigoProduto"].Value);

                int quantidadeLinha = Convert.ToInt32(linhaSelecionada.Cells["quantidadeProduto"].Value);

                decimal valorLinha = Convert.ToDecimal(linhaSelecionada.Cells["valorProduto"].Value);

                string queryDelete = "DELETE FROM itensvenda WHERE CD_PRODUTO = @codigoProduto";
                using (MySqlCommand cmd = new MySqlCommand(queryDelete, Conexao))
                {
                    Conexao.Open();
                    cmd.Parameters.AddWithValue("@codigoProduto", idSelecionado);
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
                DataGridViewCell cell = row.Cells["codigoProduto"];
                DataGridViewCell cell2 = row.Cells["quantidadeProduto"];
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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                Properties.Settings.Default.DataGrid.Clear();
                Properties.Settings.Default.Save();
                //quantidadeEstoque();

                string strSql = "UPDATE vendas SET DT_VENDA='" + DateTime.Now.ToString("yyyy-MM-dd") + "', " +
                    "QT_VALORTOTAL='" + txtValorTotal.Text + "', CD_MESA='" + txtCodigoMesa.Text + "'" +
                     " WHERE CD_VENDA='" + txtCodVenda.Text + "'";
                Conexao = new MySqlConnection(strCon);
                MySqlCommand comando = new MySqlCommand(strSql, Conexao);

                try
                {
                    Conexao.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Venda salva com sucesso!");
                    alterarSituacaoMesa1();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Campos obrigatórios não preenchido!");
                }
                finally
                {
                    Conexao.Close();
                }

                this.Close();
                autorizarFechamento = true;
            }
        }

        private void CarregarDados()
        {
            try
            {
                //quantidadeTela = Convert.ToDecimal(txtQuantidade.Text);

                Conexao = new MySqlConnection(strCon);

                string sql = "SELECT * " +
                            "FROM vendas " +
                            "WHERE CD_MESA=" + txtCodigoMesa.Text;

                Conexao.Open();

                MySqlCommand comando = new MySqlCommand(sql, Conexao);

                MySqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    txtFuncionario.Text = reader.GetString(1);
                    txtCodVenda.Text = reader.GetInt32(0).ToString();
                    txtValorTotal.Text = reader.GetString(4);

                    txtFuncionario.Enabled = false;
                    btnNovaVenda.Enabled = false;
                    txtCodProduto.Enabled = true;
                    txtQuantidade.Enabled = true;
                    txtCodDesconto.Enabled = true;
                    txtPagamento.Enabled = true;
                    btnSalvar.Enabled = true;
                    btnCancelarVenda.Enabled = true;
                    btnConfirmarVenda.Enabled = true;
                    txtPorPessoa.Enabled = true;
                    txtValorTroco.Enabled = true;
                    txtValorPago.Enabled = true;

                    carregarListaProduto();
                }
                else
                {
                    //string strSql = "insert into vendas(CD_FUNCIONARIO) " +
                    //"values('" + txtFuncionario.Text + "')";
                    //Conexao = new MySqlConnection(strCon);
                    //MySqlCommand comando2 = new MySqlCommand(strSql, Conexao);

                    //try
                    //{
                    //    Conexao.Open();
                    //    comando.ExecuteNonQuery();
                    //    MessageBox.Show("Venda iniciada!");
                    //    string strSelect = "SELECT MAX(CD_VENDA) FROM vendas";

                    //    MySqlCommand comando2 = new MySqlCommand(strSelect, Conexao);
                    //    MySqlDataReader reader = comando2.ExecuteReader();
                    //    if (reader.Read())
                    //    {
                    //        txtCodVenda.Text = reader.GetString(0);
                    //    }
                    //    txtCodProduto.Focus();
                    //}

                    //catch (Exception ex)
                    //{
                    //    MessageBox.Show("Funcionário não cadastrado!");
                    //    //MessageBox.Show(ex.Message);
                    //    btnNovaVenda.Enabled = true;
                    //    TelaCaixaNova_Load(sender, e);
                    //}
                    //finally
                    //{
                    //    Conexao.Close();
                    //}
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

        private void carregarListaProduto()
        {
            string codigoProduto;

            try
            {

                Conexao = new MySqlConnection(strCon);

                string sql = "SELECT * FROM itensvenda WHERE CD_VENDA=" + txtCodVenda.Text;

                Conexao.Open();

                MySqlCommand comando = new MySqlCommand(sql, Conexao);

                MySqlDataReader reader = comando.ExecuteReader();

                dataGridView1.Rows.Clear();

                while (reader.Read())
                {
                    string[] row =
                    {
                        reader.GetString(1),
                        reader.GetString(2),
                    };

                    try
                    {

                        Conexao = new MySqlConnection(strCon);

                        string sql2 = "SELECT nomeProduto, valorUnit FROM produto WHERE id=" + row[0];

                        Conexao.Open();

                        MySqlCommand comando2 = new MySqlCommand(sql2, Conexao);

                        MySqlDataReader reader2 = comando2.ExecuteReader();

                        dataGridView1.Rows.Clear();
                        string row1, row2;

                        if (reader2.Read())
                        {

                            row1 = reader2.GetString(0);
                            row2 = reader2.GetString(1);

                            var linha_listview = new ListViewItem(row2);
                            dataGridView1.Rows.Add(row[0], row1, row[1], row2);

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

                   // var linha_listview = new ListViewItem(row);
                   // dataGridView1.Rows.Add(row[0], , row[1], "");
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

            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{
            //    // Verifica se a linha não é uma linha de cabeçalho
            //    if (!row.IsNewRow)
            //    {
            //        // Obtém o valor do ID da coluna específica (supondo que seja a primeira coluna)
            //        int id = Convert.ToInt32(row.Cells[0].Value);

            //        // Faça o que desejar com o ID...

            //        try
            //        {

            //            Conexao = new MySqlConnection(strCon);

            //            string sql = "SELECT nomeProduto, valorUnit FROM produto WHERE id=" + id;

            //            Conexao.Open();

            //            MySqlCommand comando = new MySqlCommand(sql, Conexao);

            //            MySqlDataReader reader = comando.ExecuteReader();

            //            dataGridView1.Rows.Clear();

            //            while (reader.Read())
            //            {
            //                string[] row2 =
            //                {
            //                    reader.GetString(1),
            //                    reader.GetString(2),
            //                };

            //                var linha_listview = new ListViewItem(row2);
            //                dataGridView1.Rows.Add("", row2[0], "", row2[1]);

            //            }

            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.Message);
            //        }
            //        finally
            //        {
            //            Conexao.Close();
            //        }
            //    }
            //}
        }


        private void FecharCaixa()
        {
            txtCodProduto.Enabled = false;
            txtQuantidade.Enabled = false;
            txtCodDesconto.Enabled = false;
            txtPorPessoa.Enabled = false;
            txtPagamento.Enabled = false;
            btnConfirmarVenda.Enabled = true;
            btnCancelarVenda.Enabled = true;
            btnNovaVenda.Enabled = false;

            txtValorPago.Focus();
        }

        private void TelaCaixaNova_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 121)
            {
                FecharCaixa();
            }

            if (e.KeyChar == 122)
            {
                btnConfirmarVenda_Click(sender, e);
            }

            if (e.KeyChar == 123)
            {
                btnCancelarVenda_Click(sender, e);
            }
        }

        private void txtValorPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            decimal valorTroco;
            if (e.KeyChar == 13)
            {

                valorTroco = Convert.ToDecimal(txtValorPago.Text) - Total;

                txtValorTroco.Text = valorTroco.ToString();
            }
        }

        private void alterarSituacaoMesa0()
        {
            string strUpdate = "UPDATE mesascadastro SET TP_SITUACAO='" + 0 + "' WHERE CD_MESA= '" + txtCodigoMesa.Text + "'";
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

        private void alterarSituacaoMesa1()
        {
            string strUpdate = "UPDATE mesascadastro SET TP_SITUACAO='" + 1 + "' WHERE CD_MESA= '" + txtCodigoMesa.Text + "'";
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
