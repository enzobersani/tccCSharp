using DGVPrinterHelper;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TccRestaurante
{
    public partial class ListaPagamentosUtilizados : Form
    {
        public ListaPagamentosUtilizados()
        {
            InitializeComponent();
        }

        private MySqlConnection Conexao;
        private string data_source = "Server = localhost; Database=restaurantetcc;Uid=root;Pwd=";

        private void ListaPagamentosUtilizados_Load(object sender, EventArgs e)
        {


            using (MySqlConnection connection = new MySqlConnection(data_source))
            {
                connection.Open();

                string query = "SELECT fp.CD_PAGAMENTO, fp.NM_PAGAMENTO, COUNT(*) AS quantidade FROM vendas v JOIN pagamento fp ON v.CD_PAGAMENTO = fp.CD_PAGAMENTO GROUP BY fp.NM_PAGAMENTO, fp.NM_PAGAMENTO";
                MySqlCommand command = new MySqlCommand(query, connection);

                MySqlDataReader reader = command.ExecuteReader();

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
             
                reader.Close();
                connection.Close();
            }
        }

        private void btnRelatório_Click(object sender, EventArgs e)
        {

            String pasta_aplicacao = Application.StartupPath + @"\";

            DGVPrinter printer = new DGVPrinter();

            DGVPrinter.ImbeddedImage img1 = new DGVPrinter.ImbeddedImage();
            Image img = Image.FromFile(pasta_aplicacao + @"images\logo.jpg");
            Bitmap bitmap1 = new Bitmap(img);
            //  This code is to crop the image sizee
            Bitmap newImage = ResizeBitmap(bitmap1, 100, 100);
            img1.theImage = newImage; img1.ImageX = 100; img1.ImageY = 20;
            img1.ImageAlignment = DGVPrinter.Alignment.Center;
            img1.ImageLocation = DGVPrinter.Location.Absolute;
            printer.ImbeddedImageList.Add(img1);

            printer.Title = "Restaurante Mister Lee\n\n";
            printer.SubTitle = "Relatório de Funcionários\n";
            printer.SubTitleSpacing = 10;
            printer.Footer = "Telefone 3018-2508\nAv.Edson de Lima Souto \n\n " + DateTime.Now.ToShortDateString();





            printer.PrintPreviewDataGridView(dataGridView1);

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

        private void btnGrafico_Click(object sender, EventArgs e)
        {
            GraficoFormasPagamentos graficoFormasPagamentos = new GraficoFormasPagamentos();
            graficoFormasPagamentos.ShowDialog();
        }
    }
}

