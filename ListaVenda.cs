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
    public partial class ListaVenda : Form
    {
        public ListaVenda()
        {
            InitializeComponent();
        }

        private MySqlConnection Conexao;
        private string data_source = "Server = localhost; Database=restaurantetcc;Uid=root;Pwd=";

        private void ListaVenda_Load(object sender, EventArgs e)
        {
            try
            {

                Conexao = new MySqlConnection(data_source);

                string sql = "SELECT * FROM vendas";

                Conexao.Open();

                MySqlCommand comando = new MySqlCommand(sql, Conexao);

                MySqlDataReader reader = comando.ExecuteReader();


                dataGridView1.Rows.Clear();
                while (reader.Read())
                {
                    string[] row =
                    {
                        reader.IsDBNull(0) ? "" : reader.GetString(0),
                        reader.IsDBNull(1) ? "" : reader.GetString(1),
                        reader.IsDBNull(2) ? "" : reader.GetString(2),
                        reader.IsDBNull(3) ? "" : reader.GetString(3),
                        reader.IsDBNull(4) ? "" : reader.GetString(4),
                        reader.IsDBNull(5) ? "" : reader.GetString(5),
                        reader.IsDBNull(6) ? "" : reader.GetString(6)
                    };

                    dataGridView1.Rows.Add(row[0], row[1], row[2], row[3], row[4], row[5], row[6]);

                    if (row[5] == "REALIZADA")
                    {
                        dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[5].Style.BackColor = Color.Green;
                    }
                    else if (row[5] == "PENDENTE")
                    {
                        dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[5].Style.BackColor = Color.Yellow;
                    }

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
