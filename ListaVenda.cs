using DGVPrinterHelper;
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
                        reader.IsDBNull(4) ? "" : reader.GetString(3),
                        reader.IsDBNull(3) ? "" : reader.GetString(4),
                        reader.IsDBNull(5) ? "" : reader.GetString(5),
                        reader.IsDBNull(6) ? "" : reader.GetString(6)
                    };

                    dataGridView1.Rows.Add(row[0], row[1], row[2], row[4], row[3], row[5], row[6]);

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

        private void exportarPdf_Click(object sender, EventArgs e)
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
            printer.SubTitle = "Relatório de Vendas\n";
            printer.SubTitleSpacing = 10;
            printer.Footer = "Telefone 3018-2508\nAv.Edson de Lima Souto \n " + DateTime.Now.ToShortDateString();




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
    }
}
