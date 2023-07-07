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
    public partial class TelaCadastroMesas : Form
    {
        public TelaCadastroMesas()
        {
            InitializeComponent();
        }


        MySqlConnection sqlCon = null;
        private string strCon = "Server = localhost; Database=restaurantetcc;Uid=root;Pwd=";
        private string strSql = string.Empty;

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtQuantidadeMesas.Text == string.Empty)
                MessageBox.Show("Nenhuma quantidade de mesas foram informada!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            txtQuantidadeMesas.Focus();

            strSql = "insert into mesas (QT_MESA) " +
                "values ('" + txtQuantidadeMesas.Text + "')";
            sqlCon = new MySqlConnection(strCon);
            MySqlCommand comando = new MySqlCommand(strSql, sqlCon);

            try
            {
                sqlCon.Open();
                comando.ExecuteNonQuery();
                MessageBox.Show("Mesas adicionadas com sucesso!");
                txtQuantidadeMesas.Text = string.Empty;
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

        private void TelaCadastroMesas_Load(object sender, EventArgs e)
        {
            strSql = "SELECT * FROM mesas";
            sqlCon = new MySqlConnection(strCon);

            try
            {
                sqlCon.Open();

                MySqlCommand comando = new MySqlCommand(strSql, sqlCon);

                MySqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    btnSalvar.Enabled = false;
                    txtQuantidadeMesas.Text = reader.GetInt32(0).ToString();
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

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            strSql = "UPDATE mesas SET QT_MESA= '" + txtQuantidadeMesas.Text + "'";
            sqlCon = new MySqlConnection(strCon);
            MySqlCommand comando = new MySqlCommand(strSql, sqlCon);

            try
            {
                sqlCon.Open();
                comando.ExecuteNonQuery();
                MessageBox.Show("Cadastro realizado com sucesso!");
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
