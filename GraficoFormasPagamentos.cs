using DGVPrinterHelper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;
//using iTextSharp.text;
//using iTextSharp.text.pdf;
using System.Drawing;
using System.Windows.Forms;

namespace TccRestaurante
{
    public partial class GraficoFormasPagamentos : Form
    {
        public GraficoFormasPagamentos()
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

        private void GraficoFormasPagamentos_Load(object sender, EventArgs e)
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
            comados.CommandText = "SELECT fp.CD_PAGAMENTO, fp.NM_PAGAMENTO, COUNT(*) AS quantidade " +
                       "FROM vendas v " +
                       "JOIN pagamento fp ON v.CD_PAGAMENTO = fp.CD_PAGAMENTO " +
                       "WHERE v.DT_VENDA >='" + dataInicial.ToString("yyyy-MM-dd") + "'AND v.DT_VENDA <='" + dataFinal.ToString("yyyy-MM-dd") + "'" +
                       "GROUP BY fp.CD_PAGAMENTO, fp.NM_PAGAMENTO";
            MySqlDataReader resultado = comados.ExecuteReader();

            while (resultado.Read())
            {
                String nome = resultado.GetString("NM_PAGAMENTO");
                int quatidade = resultado.GetInt32("quantidade");

                chart1.Series.Add(nome);
                chart1.Series[nome].Points.Add(quatidade);
            }

            txtDataInicial.Focus();
        }

        private void btnAplicarFiltro_Click(object sender, EventArgs e)
        {
            if(txtDataFinal.Text != "  /  /" && txtDataInicial.Text != " /  / ")
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
                    comados.CommandText = "SELECT fp.CD_PAGAMENTO, fp.NM_PAGAMENTO, COUNT(*) AS quantidade " +
                       "FROM vendas v " +
                       "JOIN pagamento fp ON v.CD_PAGAMENTO = fp.CD_PAGAMENTO " +
                       "WHERE v.DT_VENDA >='" + dataInicial.ToString("yyyy-MM-dd") + "'AND v.DT_VENDA <='" + dataFinal.ToString("yyyy-MM-dd") + "'" +
                       "GROUP BY fp.CD_PAGAMENTO, fp.NM_PAGAMENTO";


                    MySqlDataReader resultado = comados.ExecuteReader();

                    while (resultado.Read())
                    {
                        String nome = resultado.GetString("NM_PAGAMENTO");
                        int quatidade = resultado.GetInt32("quantidade");

                        chart1.Series.Add(nome);
                        chart1.Series[nome].Points.Add(quatidade);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data informada não é valida!");
                }
                
            }
            else
            {
                GraficoFormasPagamentos_Load( sender, e);
            }
        }


        private void ExportarParaPDF(string nomeArquivo, Control controle)
        {
            //using (var documento = new Document())
            //{
            //    try
            //    {
            //        PdfWriter.GetInstance(documento, new System.IO.FileStream(nomeArquivo, System.IO.FileMode.Create));
            //        documento.Open();

            //        // Criar uma imagem do controle (gráfico)
            //        using (var bitmap = new Bitmap(controle.Width, controle.Height))
            //        {
            //            controle.DrawToBitmap(bitmap, new System.Drawing.Rectangle(0, 0, controle.Width, controle.Height));

            //            // Converter a imagem em formato iTextSharp
            //            var imagem = iTextSharp.text.Image.GetInstance(bitmap, System.Drawing.Imaging.ImageFormat.Jpeg);
            //            float larguraMaxima = 400; // Defina o valor desejado para a largura
            //            float alturaMaxima = 400; // Defina o valor desejado para a altura
            //            imagem.ScaleToFit(larguraMaxima, alturaMaxima);
            //            imagem.Alignment = Element.ALIGN_CENTER;

            //            // Adicionar a imagem ao documento PDF
            //            documento.Add(imagem);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Erro ao exportar para PDF: " + ex.Message);
            //    }
            //    finally
            //    {
            //        documento.Close();
            //    }
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                SaveFileDialog salvarArquivo = new SaveFileDialog();
                salvarArquivo.Filter = "Arquivo PDF|*.pdf";
                if (salvarArquivo.ShowDialog() == DialogResult.OK)
                {
                    ExportarParaPDF(salvarArquivo.FileName, chart1); // Substitua "graficoControl" pelo nome do seu controle de gráfico
                    MessageBox.Show("Exportação concluída com sucesso!");
                }
            }
        }
    }
}
