﻿using MySql.Data.MySqlClient;
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
                    //button.BackColor = Color.FromArgb(0, 255, 0);
                    button.Size = new Size(180, 90);
                    string botao = button.Name;

                    try
                    {
                        sqlCon = new MySqlConnection(strCon);

                        string sql2 = "SELECT TP_SITUACAO FROM mesascadastro WHERE CD_MESA=" + i;

                        sqlCon.Open();

                        MySqlCommand comando2 = new MySqlCommand(sql2, sqlCon);

                        MySqlDataReader reader2 = comando2.ExecuteReader();
                        int situacaoMesa = 0;

                        if (reader2.Read())
                        {
                            situacaoMesa = reader2.GetInt32(0);
                        }

                        if (situacaoMesa == 1)
                        {
                            button.BackColor = Color.FromArgb(240, 230, 140);
                        }
                        else
                        {
                            button.BackColor = Color.FromArgb(0, 255, 0);
                            
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

                    button.Click += new EventHandler((a, b) =>
                    {
                        chamarVenda(sender, e, botao);
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

        private void chamarVenda(object sender, EventArgs e, string botao)
        {
            try
            {
                sqlCon = new MySqlConnection(strCon);

                string sql = "SELECT * FROM mesascadastro WHERE CD_MESA='" + botao + "'";

                sqlCon.Open();

                MySqlCommand comando = new MySqlCommand(sql, sqlCon);

                MySqlDataReader reader = comando.ExecuteReader();

                int condicaoMesa;

                if (reader.Read())
                {
                    condicaoMesa = reader.GetInt32(2);

                    //if (condicaoMesa == null || condicaoMesa == 0)
                    if (condicaoMesa == 1)
                    {
                        TelaCaixaNova telaCaixaNova = new TelaCaixaNova() { Owner = this };
                        telaCaixaNova.txtCodigoMesa.Text = botao;
                        telaCaixaNova.ShowDialog();
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
                tbMesa.SuspendLayout(); // Suspender a atualização do layout do TableLayoutPanel

                // Remover todos os controles filhos do TableLayoutPanel
                while (tbMesa.Controls.Count > 0)
                {
                    Control control = tbMesa.Controls[0];
                    tbMesa.Controls.Remove(control);
                    control.Dispose(); // Liberar os recursos do controle removido
                }

                tbMesa.ResumeLayout(); // Retomar a atualização do layout do TableLayoutPanel
                TelaMesas_Load(sender, e);
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

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            if (txtNumeroMesa.Text != "")
            {
                int botaoDigitado = Convert.ToInt32(txtNumeroMesa.Text);
                ExibirApenasBotaoSelecionado(botaoDigitado);
            }else if (txtNumeroMesa.Text == "")
            {
                tbMesa.SuspendLayout(); // Suspender a atualização do layout do TableLayoutPanel

                // Remover todos os controles filhos do TableLayoutPanel
                while (tbMesa.Controls.Count > 0)
                {
                    Control control = tbMesa.Controls[0];
                    tbMesa.Controls.Remove(control);
                    control.Dispose(); // Liberar os recursos do controle removido
                }

                tbMesa.ResumeLayout(); // Retomar a atualização do layout do TableLayoutPanel
                TelaMesas_Load(sender, e);
            }
        }

        private void ExibirApenasBotaoSelecionado(int botaoSelecionado)
        {
            tbMesa.SuspendLayout(); // Suspender a atualização do layout do TableLayoutPanel

            // Ocultar todos os botões, exceto o botão selecionado
            foreach (Control controle in tbMesa.Controls)
            {
                if (controle is Button botao)
                {
                    if (botao.Name == botaoSelecionado.ToString())
                    {
                        botao.Visible = true;
                        tbMesa.SetCellPosition(botao, new TableLayoutPanelCellPosition(0, 0));
                    }
                    else
                    {
                        botao.Visible = false;
                    }
                }
            }

            tbMesa.ResumeLayout(); // Retomar a atualização do layout do TableLayoutPanel
        }
    }
}


