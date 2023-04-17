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
using DGVPrinterHelper;

namespace TccRestaurante
{
    public partial class ListaFornecedor : Form
    {
        public ListaFornecedor()
        {
            InitializeComponent();
        }

        MySqlConnection Conexao = null;
        private string strCon = "Server = localhost; Database=restaurantetcc;Uid=root;Pwd=";

        private void button1_Click(object sender, EventArgs e)
        {
            var codigo = txtCodigoFornecedor.Text;

            if (txtCodigoFornecedor.Text != "")
            {
                string sql = "SELECT * FROM fornecedor WHERE idFornecedor =" + codigo;
                Conexao = new MySqlConnection(strCon);
                MySqlCommand comando = new MySqlCommand(sql, Conexao);


                try
                {
                    Conexao.Open();
                    MySqlDataReader reader = comando.ExecuteReader();



                    while (reader.Read())
                    {
                        string[] row =
                        {
                            reader.GetString(0),
                            reader.GetString(1)
                        };


                        dataGridView1.Rows.Clear();
                        dataGridView1.Rows.Add(row[0], row[1]);

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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string q = "'%" + txtNomeFornecedor.Text + "%'";

                Conexao = new MySqlConnection(strCon);

                string sql = "SELECT * FROM fornecedor WHERE nomeFornecedor LIKE " + q;

                Conexao.Open();

                MySqlCommand comando = new MySqlCommand(sql, Conexao);

                MySqlDataReader reader = comando.ExecuteReader();



                while (reader.Read())
                {
                    string[] row =
                    {
                        reader.GetString(0),
                        reader.GetString(1),
                    };

                    var linha_listview = new ListViewItem(row);
                    dataGridView1.Rows.Clear();
                    dataGridView1.Rows.Add(row[0], row[1]);

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

        private void ListaFornecedor_Load(object sender, EventArgs e)
        {
            try
            {

                Conexao = new MySqlConnection(strCon);

                string sql = "SELECT * FROM fornecedor";

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

                    };

                    var linha_listview = new ListViewItem(row);



                    dataGridView1.Rows.Add(row[0], row[1]);

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

        private void button3_Click(object sender, EventArgs e)
        {
            {
                try
                {

                    Conexao = new MySqlConnection(strCon);

                    string sql = "SELECT * FROM fornecedor";

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
                    
                    };


                        dataGridView1.Rows.Add(row[0], row[1]);

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
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
            printer.CellAlignment = StringAlignment.Center;
            printer.Title = "Restaurante Mister Lee\n\n";
            printer.SubTitle = "Relatório de Fornecedores\n";
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
    }
}
