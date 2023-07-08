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
    public partial class ListaDesconto : Form
    {
        public ListaDesconto()
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

        private MySqlConnection Conexao;
        private string data_source = "Server = localhost; Database=restaurantetcc;Uid=root;Pwd=";

        private void ListaDesconto_Load(object sender, EventArgs e)
        {
            try
            {

                Conexao = new MySqlConnection(data_source);

                string sql = "SELECT * FROM desconto";

                Conexao.Open();

                MySqlCommand comando = new MySqlCommand(sql, Conexao);

                MySqlDataReader reader = comando.ExecuteReader();


                dataGridView1.Rows.Clear();
                while (reader.Read())
                {
                    string[] row =
                    {
                        reader.GetString(0),
                        reader.GetString(1),
                        reader.GetString(2),

                    };

                    //var linha_listview = new ListViewItem(row);



                    dataGridView1.Rows.Add(row[0], row[1], row[2]);

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

        private void button2_Click(object sender, EventArgs e)
        {
            ListaDesconto_Load(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var codigo = txtCodigoProduto.Text;

            if (txtCodigoProduto.Text != "")
            {
                try
                {

                    Conexao = new MySqlConnection(data_source);

                    string sql = "SELECT * " +
                                "FROM desconto " +
                                "WHERE CD_DESCONTO =" + codigo;

                    Conexao.Open();

                    MySqlCommand comando = new MySqlCommand(sql, Conexao);

                    MySqlDataReader reader = comando.ExecuteReader();

                    dataGridView1.Rows.Clear();

                    while (reader.Read())
                    {
                        string[] row =
                        {
                        reader.GetString(0),
                        reader.GetString(1),
                        reader.GetString(2),
                    };

                        var linha_listview = new ListViewItem(row);

                        dataGridView1.Rows.Add(row[0], row[1], row[2]);
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string q = "'%" + txtProduto.Text + "%'";

                Conexao = new MySqlConnection(data_source);

                string sql = "SELECT * " +
                            "FROM desconto " +
                            "WHERE DS_DESCONTO LIKE " + q;

                Conexao.Open();

                MySqlCommand comando = new MySqlCommand(sql, Conexao);

                MySqlDataReader reader = comando.ExecuteReader();

                dataGridView1.Rows.Clear();

                while (reader.Read())
                {
                    string[] row =
                    {
                        reader.GetString(0),
                        reader.GetString(1),
                        reader.GetString(2),
                    };

                    var linha_listview = new ListViewItem(row);

                    dataGridView1.Rows.Add(row[0], row[1], row[2]);
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

}
