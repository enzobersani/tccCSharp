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
    public partial class TelaMesas : Form
    {
        MySqlConnection sqlCon = null;
        private string strCon = "Server = localhost; Database=restaurantetcc;Uid=root;Pwd=";
        private string strSql = string.Empty;
        public TelaMesas()
        {
            InitializeComponent();
        }

        private void TelaMesas_Load(object sender, EventArgs e)
        {
            try
            {
                sqlCon = new MySqlConnection(strCon);

                string sql = "SELECT * FROM mesas";

                sqlCon.Open();

                MySqlCommand comando = new MySqlCommand(sql, sqlCon);

                MySqlDataReader reader = comando.ExecuteReader();
                int mesa = 0;

                if (reader.Read())
                {
                    mesa = reader.GetInt32(0);
                }

                for (int i = 1; i <= mesa; i++)
                {
                    Button button = new Button();
                    button.Text = i.ToString();
                    button.Name = i.ToString();
                    button.BackColor = Color.FromArgb(0, 255, 0);
                    button.Size = new Size(180, 90);
                    string botao = button.Name;

                    button.Click += new EventHandler((a, b) =>
                    {
                        chamarVenda(botao);
                    });

                    tbMesa.Controls.Add(button, -1, -1);
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

        private void chamarVenda(string botao)
        {
            try
            {
                sqlCon = new MySqlConnection(strCon);

                string sql = "SELECT * FROM mesascadastro WHERE CD_MESA='" + botao + "'";

                sqlCon.Open();

                MySqlCommand comando = new MySqlCommand(sql, sqlCon);

                MySqlDataReader reader = comando.ExecuteReader();

                string condicaoMesa;

                if (reader.Read())
                {
                    condicaoMesa = reader.GetString(2);

                    if (condicaoMesa == null || condicaoMesa == "A")
                    {
                        string mensagem = $"Deseja iniciar uma nova venda na mesa {botao}";
                        string caption = "Teste de retorno";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result;

                        result = MessageBox.Show(mensagem, caption, buttons);
                        if (result == DialogResult.Yes)
                        {
                            inserirMesas(botao);
                            TelaCaixaNova telaCaixaNova = new TelaCaixaNova() { Owner = this };
                            telaCaixaNova.txtCodigoMesa.Text = botao;
                            telaCaixaNova.ShowDialog();
                        }
                    }
                }
                else
                {
                    string mensagem = $"Deseja iniciar uma nova venda na mesa {botao}";
                    string caption = "Teste de retorno";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;

                    result = MessageBox.Show(mensagem, caption, buttons);
                    if (result == DialogResult.Yes)
                    {
                        inserirMesas(botao);
                        TelaCaixaNova telaCaixaNova = new TelaCaixaNova() { Owner = this };
                        telaCaixaNova.txtCodigoMesa.Text = botao;
                        telaCaixaNova.ShowDialog();
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

        private void inserirMesas(string botao)
        {
            try
            {
                DateTime dataAtual = DateTime.Now;
                string dataFormatada = dataAtual.ToString("yyyy-MM-dd");
                string strSql = "insert into mesascadastro(CD_MESA, DT_MESA, TP_SITUACAO) " +
                    "values('" + botao + "', '" + dataFormatada + "', '" + 1 + "')";
                sqlCon = new MySqlConnection(strCon);
                MySqlCommand comando = new MySqlCommand(strSql, sqlCon);
                sqlCon.Open();
                comando.ExecuteNonQuery();
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


