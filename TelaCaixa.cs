using MySql.Data.MySqlClient;
//using Org.BouncyCastle.Crypto.Tls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TccRestaurante { 


    public partial class Caixa : Form
    {


    public static decimal Resultado = 0;
        public static int clicks = 0;
        public Caixa()
        {
            InitializeComponent();
        }

        MySqlConnection sqlCon = null;
        private string strCon = "Server = localhost; Database=restaurantetcc;Uid=root;Pwd=";
        private string strSql = string.Empty;

        private MySqlConnection Conexao;
        private string data_source = "Server = localhost; Database=restaurantetcc;Uid=root;Pwd=";

        decimal valorDesc;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

      



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtCodigoFuncionario.Text == "" || txtProduto1.Text == "" ||
                txtValor1.Text == "" || txtQt1.Text == "" || txtQtTotal.Text == "")
            {
                MessageBox.Show("Existem campos obrigatórios sem conteúdo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                strSql = "insert into venda (CD_PRODUTO, CD_FUNCIONARIO, NR_VALOR, NR_VALORTOTAL, CD_DESCONTO) " +
                    "values ('" + txtProduto1.Text + "', '" + txtCodigoFuncionario.Text + "', '" + txtValor1.Text + "'," +
                    " '" + txtQtTotal.Text + "','" + txtCodDesc.Text + "')";
               
                sqlCon = new MySqlConnection(strCon);
                MySqlCommand comando = new MySqlCommand(strSql, sqlCon);

                try
                {
                    sqlCon.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Venda realizada com sucesso!");
                    button3_Click_1();
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

        private void button3_Click_1()
        {
            throw new NotImplementedException();
        }

        private void txtProduto1_Leave(object sender, EventArgs e)
        {
            if (txtProduto1.Text != "")
            { 
                try
                {
                    string codigo = txtProduto1.Text;

                    Conexao = new MySqlConnection(data_source);

                    string sql = "SELECT * " +
                                "FROM produto " +
                                "WHERE id=" + codigo;

                    Conexao.Open();

                    MySqlCommand comando = new MySqlCommand(sql, Conexao);

                    MySqlDataReader reader = comando.ExecuteReader();

                    if (reader.Read())
                    {
                        txtDesc1.Text = reader.GetString(1);
                        txtValor1.Text = reader.GetString(3);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Informe o código do Produto!");
                }
                finally
                {
                    Conexao.Close();
                }
            }
        }

        private void txtProduto3_Leave(object sender, EventArgs e)
        {
            if(txtProduto3.Text != "")
            {
                try
                {
                    string codigo = txtProduto3.Text;

                    Conexao = new MySqlConnection(data_source);

                    string sql = "SELECT * " +
                                "FROM produto " +
                                "WHERE id=" + codigo;

                    Conexao.Open();

                    MySqlCommand comando = new MySqlCommand(sql, Conexao);

                    MySqlDataReader reader = comando.ExecuteReader();

                    if (reader.Read())
                    {
                        txtDesc3.Text = reader.GetString(1);
                        txtValor3.Text = reader.GetString(3);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Informe o código do Produto!");
                }
                finally
                {
                    Conexao.Close();
                }
            }
        }

        private void txtProduto4_Leave(object sender, EventArgs e)
        {
            if(txtProduto4.Text != "")
            {
                try
                {
                    string codigo = txtProduto4.Text;

                    Conexao = new MySqlConnection(data_source);

                    string sql = "SELECT * " +
                                "FROM produto " +
                                "WHERE id=" + codigo;

                    Conexao.Open();

                    MySqlCommand comando = new MySqlCommand(sql, Conexao);

                    MySqlDataReader reader = comando.ExecuteReader();

                    if (reader.Read())
                    {
                        txtDesc4.Text = reader.GetString(1);
                        txtValor4.Text = reader.GetString(3);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Informe o código do Produto!");
                }
                finally
                {
                    Conexao.Close();
                }
            }
        }

        private void txtProduto5_Leave(object sender, EventArgs e)
        {
            if(txtProduto5.Text != "")
            {
                try
                {
                    string codigo = txtProduto5.Text;

                    Conexao = new MySqlConnection(data_source);

                    string sql = "SELECT * " +
                                "FROM produto " +
                                "WHERE id=" + codigo;

                    Conexao.Open();

                    MySqlCommand comando = new MySqlCommand(sql, Conexao);

                    MySqlDataReader reader = comando.ExecuteReader();

                    if (reader.Read())
                    {
                        txtDesc5.Text = reader.GetString(1);
                        txtValor5.Text = reader.GetString(3);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Informe o código do Produto!");
                }
                finally
                {
                    Conexao.Close();
                }
            }
        }

        private void txtProduto6_Leave(object sender, EventArgs e)
        {
            if(txtProduto6.Text != "")
            {
                try
                {
                    string codigo = txtProduto6.Text;

                    Conexao = new MySqlConnection(data_source);

                    string sql = "SELECT * " +
                                "FROM produto " +
                                "WHERE id=" + codigo;

                    Conexao.Open();

                    MySqlCommand comando = new MySqlCommand(sql, Conexao);

                    MySqlDataReader reader = comando.ExecuteReader();

                    if (reader.Read())
                    {
                        txtDesc6.Text = reader.GetString(1);
                        txtValor6.Text = reader.GetString(3);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Informe o código do Produto!");
                }
                finally
                {
                    Conexao.Close();
                }
            }
        }

        

        private void txtQtTotal_TextChanged(object sender, EventArgs e)

        {
     
            //txtQtTotal.Text = Resultado.ToString();
        }

        private void txtDesc1_TextChanged(object sender, EventArgs e)
        {
            if(txtDesc1.Text != null)
            {
                Remove.Visible = true;
            } 
        }

        private void txtDesc2_TextChanged(object sender, EventArgs e)
        {
            if (txtDesc2.Text != null)
            {
                RemoveTwo.Visible = true;
            }
        }

        private void txtDesc3_TextChanged(object sender, EventArgs e)
        {
            if (txtDesc3.Text != null)
            {
                RemoveThree.Visible = true;
            }
        }

        private void txtDesc4_TextChanged(object sender, EventArgs e)
        {
            if (txtDesc4.Text != null)
            {
                RemoveFour.Visible = true;
            }
        }

        private void txtDesc5_TextChanged(object sender, EventArgs e)
        {
            if (txtDesc5.Text != null)
            {
                RemoveFive.Visible = true;
            }
        }
        private void txtDesc6_TextChanged_1(object sender, EventArgs e)
        {
            if (txtDesc6.Text != null)
            {
                RemoveSix.Visible = true;
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
        private void Remove_click(object sender, EventArgs e)
        {
            txtProduto1.Clear();
            txtDesc1.Clear();
            txtValor1.Clear();
            txtQt1.Clear();
            Remove.Visible = false;
        }
        private void RemoveTwo_Click(object sender, EventArgs e)
        {
            txtProduto2.Clear();
            txtDesc2.Clear();
            txtValor2.Clear();
            txtQt2.Clear();
            RemoveTwo.Visible = false;
        }
        private void RemoveThree_Click(object sender, EventArgs e)
        {
            txtProduto3.Clear();
            txtDesc3.Clear();
            txtValor3.Clear();
            txtQt3.Clear();
            RemoveThree.Visible = false;
        }
        private void RemoveFour_Click(object sender, EventArgs e)
        {
            txtProduto4.Clear();
            txtDesc4.Clear();
            txtValor4.Clear();
            txtQt4.Clear();
            RemoveFour.Visible = false;
        }
        private void RemoveFive_Click(object sender, EventArgs e)
        {
            txtProduto5.Clear();
            txtDesc5.Clear();
            txtValor5.Clear();
            txtQt5.Clear();
            RemoveFive.Visible = false;
        }

        private void RemoveSix_Click(object sender, EventArgs e)
        {
            txtProduto6.Clear();
            txtDesc6.Clear();
            txtValor6.Clear();
            txtQt6.Clear();
            RemoveSix.Visible = false;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            txtCodigoFuncionario.Text = "";
            txtDescricaoFuncionario.Text = "";

            txtProduto1.Text = "";
            txtProduto2.Text = "";
            txtProduto2.Text = "";
            txtProduto3.Text = "";
            txtProduto4.Text = "";
            txtProduto5.Text = "";
            txtProduto6.Text = "";

            txtDesc1.Text = "";
            txtDesc2.Text = "";
            txtDesc3.Text = "";
            txtDesc4.Text = "";
            txtDesc5.Text = "";
            txtDesc6.Text = "";

            txtValor1.Text = "";
            txtValor2.Text = "";
            txtValor3.Text = "";
            txtValor4.Text = "";
            txtValor5.Text = "";
            txtValor6.Text = "";

            txtQt1.Text = "";
            txtQt2.Text = "";
            txtQt3.Text = "";
            txtQt4.Text = "";
            txtQt5.Text = "";
            txtQt6.Text = "";

            txtCodDesc.Text = "";

            txtCodigoFuncionario.Focus();
            txtQtTotal.Text = "";
            Remove.Visible = false;
            RemoveTwo.Visible = false;
            RemoveThree.Visible = false;
            RemoveFour.Visible = false;
            RemoveFive.Visible = false;
            RemoveSix.Visible = false;
            
        }

        private void txtCodDesc_TextChanged(object sender, EventArgs e)
        {
            if (txtCodDesc.Text != "")
            {
                try
                {
                    string codigoDesc = txtCodDesc.Text;

                    Conexao = new MySqlConnection(data_source);

                    string sql = "SELECT * " +
                                "FROM desconto " +
                                "WHERE CD_DESCONTO=" + codigoDesc;

                    Conexao.Open();

                    MySqlCommand comando = new MySqlCommand(sql, Conexao);

                    MySqlDataReader reader = comando.ExecuteReader();

                    if (reader.Read())
                    {
                        valorDesc = reader.GetDecimal(2);
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
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (clicks == 0)
            {
                clicks = 1;
                if (txtQt1.Text != null)
                {
                    decimal valor1, valor2, valor3, valor4, valor5, valor6;
                    int qt1, qt2, qt3, qt4, qt5, qt6;


                    try
                    {


                        if (txtQt1.Text != "")
                        {
                            valor1 = Convert.ToDecimal(txtValor1.Text);
                            qt1 = Convert.ToInt32(txtQt1.Text);
                            Resultado = (valor1 * qt1);
                        }


                        if (txtQt2.Text != "")
                        {
                            valor2 = Convert.ToDecimal(txtValor2.Text);
                            qt2 = Convert.ToInt32(txtQt2.Text);
                            Resultado += (valor2 * qt2);
                        }


                        if (txtQt3.Text != "")
                        {
                            valor3 = Convert.ToDecimal(txtValor3.Text);
                            qt3 = Convert.ToInt32(txtQt3.Text);
                            Resultado += (valor3 * qt3);
                        }

                        if (txtQt4.Text != "")
                        {
                            valor4 = Convert.ToDecimal(txtValor4.Text);
                            qt4 = Convert.ToInt32(txtQt4.Text);
                            Resultado += (valor4 * qt4);
                        }

                        if (txtQt5.Text != "")
                        {
                            valor5 = Convert.ToDecimal(txtValor5.Text);
                            qt5 = Convert.ToInt32(txtQt5.Text);
                            Resultado += (valor5 * qt5);
                        }

                        if (txtQt6.Text != "")
                        {
                            valor6 = Convert.ToDecimal(txtValor6.Text);
                            qt6 = Convert.ToInt32(txtQt6.Text);
                            Resultado += (valor6 * qt6);
                        }

                        if (txtCodDesc.Text != "")
                            Resultado = Resultado - valorDesc;

                        if (Resultado < 0)
                            Resultado = Convert.ToDecimal("0,00");


                    }
                    catch
                    {
                        MessageBox.Show("A quantidade deve ser um número inteiro!");
                    }




                    txtQtTotal.Text = Resultado.ToString();
                }

            }
            else
            {
                clicks = 0;
                Resultado = Convert.ToDecimal("0,00");
            }
        }
        
        private void txtCodigoFuncionario_Leave_1(object sender, EventArgs e)
        {
            if (txtCodigoFuncionario.Text != "")
            {
                try
                {
                    string codigo = txtCodigoFuncionario.Text;

                    Conexao = new MySqlConnection(data_source);

                    string sql = "SELECT * " +
                                "FROM funcionario " +
                                "WHERE id=" + codigo;

                    Conexao.Open();

                    MySqlCommand comando = new MySqlCommand(sql, Conexao);

                    MySqlDataReader reader = comando.ExecuteReader();

                    if (reader.Read())
                    {
                        txtDescricaoFuncionario.Text = reader.GetString(1);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Informe o código do Funcionario!");
                }
                finally
                {
                    Conexao.Close();
                }
            }          
        }

        private void txtProduto2_Leave(object sender, EventArgs e)
        {
            if (txtProduto2.Text != "")
            {
                try
                {
                    string codigo = txtProduto2.Text;

                    Conexao = new MySqlConnection(data_source);

                    string sql = "SELECT * " +
                                "FROM produto " +
                                "WHERE id=" + codigo;

                    Conexao.Open();

                    MySqlCommand comando = new MySqlCommand(sql, Conexao);

                    MySqlDataReader reader = comando.ExecuteReader();

                    if (reader.Read())
                    {
                        txtDesc2.Text = reader.GetString(1);
                        txtValor2.Text = reader.GetString(3);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Informe o código do Produto!");
                }
                finally
                {
                    Conexao.Close();
                }
            }
        }
    }
}
