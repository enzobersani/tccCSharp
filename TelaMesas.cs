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

            private void btCadastrar_Click(object sender, EventArgs e)
            {

                if (txtNumeroMesa.Text == string.Empty)
                    MessageBox.Show("Nenhum código de mesa foi informado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                string _numeroMesa = txtNumeroMesa.Text;

                if (txtNumeroMesa.Text != string.Empty)
                {
                    //Button button = new Button();
                    //button.Text = _numeroMesa;
                    //button.Name = _numeroMesa;
                    //button.BackColor = Color.FromArgb(0, 255, 0);
                    //button.Size = new Size(180, 90);

                    //// Adicionar o botão ao TableLayoutPanel na célula (0, 0)
                    //tableLayoutPanel1.Controls.Add(button, -1, -1);

                    txtNumeroMesa.Focus();

                    strSql = "insert into mesas (CD_MESA) " +
                       "values ('" + txtNumeroMesa.Text + "')";
                    sqlCon = new MySqlConnection(strCon);
                    MySqlCommand comando = new MySqlCommand(strSql, sqlCon);

                    try
                    {
                        Button button = new Button();
                        button.Text = _numeroMesa;
                        button.Name = _numeroMesa;
                        button.BackColor = Color.FromArgb(0, 255, 0);
                        button.Size = new Size(180, 90);

                        // Adicionar o botão ao TableLayoutPanel na célula (0, 0)
                        tbMesa.Controls.Add(button, -1, -1);

                        sqlCon.Open();
                        comando.ExecuteNonQuery();
                        MessageBox.Show("Mesa adicionada com sucesso!");
                        txtNumeroMesa.Text = string.Empty;
                        //this.Controls.Add(button); // adiciona o botão diretamente ao Form

                        //Control[] controles = this.Controls.Find(_numeroMesa, true);

                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("erro");
                    }
                    finally
                    {
                        sqlCon.Close();
                    }
                }
            }
        }
    }


