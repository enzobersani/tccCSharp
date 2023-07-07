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
using System.Windows.Forms.DataVisualization.Charting;

namespace TccRestaurante
{
    public partial class GraficoMesasUtilizadas : Form
    {
        public GraficoMesasUtilizadas()
        {
            InitializeComponent();
        }

        private void GraficoMesasUtilizadas_Load(object sender, EventArgs e)
        {
            txtDataInicial.Text = DateTime.Now.AddMonths(-1).ToString("dd/MM/yyyy");
            txtDataFinal.Text = DateTime.Now.ToString("dd/MM/yyyy");
            DateTime dataInicial = DateTime.Now.AddMonths(-1);
            DateTime dataFinal = DateTime.Now;
            chart1.Series.Clear();
            chart1.Titles.Clear();
            chart1.Legends.Clear();

            chart1.Palette = ChartColorPalette.Excel;

            chart1.Legends.Add("Legenda - Formas de pagamentos");
            chart1.Legends[0].LegendStyle = LegendStyle.Table;
            chart1.Legends[0].Docking = Docking.Bottom;
            chart1.Legends[0].Alignment = StringAlignment.Center;
            chart1.Legends[0].BorderColor = Color.Black;
            chart1.Legends[0].Title = "Legenda - Formas de Pagamentos";

            String stringC = "Server = localhost; Database=restaurantetcc;Uid=root;Pwd=";
            MySqlConnection con = new MySqlConnection(stringC);
            MySqlCommand comados = con.CreateCommand();
            con.Open();
            //comados.CommandText = "SELECT fp.CD_PAGAMENTO, fp.NM_PAGAMENTO, COUNT(*) AS quantidade FROM vendas v JOIN pagamento fp ON v.CD_PAGAMENTO = fp.CD_PAGAMENTO GROUP BY fp.NM_PAGAMENTO, fp.NM_PAGAMENTO";
            comados.CommandText = "SELECT fp.CD_MESA, COUNT(*) AS quantidade " +
                       "FROM vendas v " +
                       "JOIN mesascadastro fp ON v.CD_MESA = fp.CD_MESA " +
                       "WHERE v.DT_VENDA >='" + dataInicial.ToString("yyyy-MM-dd") + "'AND v.DT_VENDA <='" + dataFinal.ToString("yyyy-MM-dd") + "'" +
                       "GROUP BY fp.CD_MESA";
            MySqlDataReader resultado = comados.ExecuteReader();

            while (resultado.Read())
            {
                //String nome2 = resultado.GetString("");
                int quatidade = resultado.GetInt32("quantidade");

                chart1.Series.Add(quatidade.ToString());
                //chart1.Series[nome2].Points.Add(quatidade);
            }

            txtDataInicial.Focus();
        }

        private void btnAplicarFiltro_Click(object sender, EventArgs e)
        {
            if (txtDataFinal.Text != "  /  /" && txtDataInicial.Text != " /  / ")
            {
                try
                {
                    DateTime dataInicial = Convert.ToDateTime(txtDataInicial.Text);
                    DateTime dataFinal = Convert.ToDateTime(txtDataFinal.Text);
                    chart1.Series.Clear();
                    chart1.Titles.Clear();
                    chart1.Legends.Clear();

                    chart1.Palette = ChartColorPalette.Excel;

                    chart1.Legends.Add("Legenda - Formas de pagamentos");
                    chart1.Legends[0].LegendStyle = LegendStyle.Table;
                    chart1.Legends[0].Docking = Docking.Bottom;
                    chart1.Legends[0].Alignment = StringAlignment.Center;
                    chart1.Legends[0].BorderColor = Color.Black;
                    chart1.Legends[0].Title = "Legenda - Formas de Pagamentos";

                    String stringC = "Server = localhost; Database=restaurantetcc;Uid=root;Pwd=";
                    MySqlConnection con = new MySqlConnection(stringC);
                    MySqlCommand comados = con.CreateCommand();
                    con.Open();
                    comados.CommandText = "SELECT fp.CD_MESA, COUNT(*) AS quantidade " +
                       "FROM vendas v " +
                       "JOIN mesascadastro fp ON v.CD_MESA = fp.CD_MESA " +
                       "WHERE v.DT_VENDA >='" + dataInicial.ToString("yyyy-MM-dd") + "'AND v.DT_VENDA <='" + dataFinal.ToString("yyyy-MM-dd") + "'" +
                       "GROUP BY fp.CD_MESA";


                    MySqlDataReader resultado = comados.ExecuteReader();

                    while (resultado.Read())
                    {
                        String nome2 = resultado.GetString("");
                        int quatidade = resultado.GetInt32("quantidade");

                        chart1.Series.Add(nome2);
                        chart1.Series[nome2].Points.Add(quatidade);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data informada não é valida!");
                }

            }
            else
            {
                GraficoMesasUtilizadas_Load(sender, e);
            }
        }
    }
}
