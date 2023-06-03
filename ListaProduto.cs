using MySql.Data.MySqlClient;
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
using DGVPrinterHelper;
namespace TccRestaurante
{
    public partial class ListaProduto : Form
    {
        private MySqlConnection Conexao;
        private string data_source = "Server = localhost; Database=restaurantetcc;Uid=root;Pwd=";

        public ListaProduto()
        {
            InitializeComponent();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string q = "'%" + txtProduto.Text + "%'";

                Conexao = new MySqlConnection(data_source);

                string sql = "SELECT * " +
                            "FROM produto " +
                            "WHERE nomeProduto LIKE " + q;

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
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.GetString(4)
                    };

                    var linha_listview = new ListViewItem(row);

                    dataGridView1.Rows.Add(row[0], row[1], row[2], row[3], row[4]);
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
            var codigo = txtCodigoProduto.Text;

            if (txtCodigoProduto.Text != "")
            {
                try
                {

                    Conexao = new MySqlConnection(data_source);

                    string sql = "SELECT * " +
                                "FROM produto " +
                                "WHERE id =" + codigo;

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
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.GetString(4)
                    };

                        var linha_listview = new ListViewItem(row);

                        dataGridView1.Rows.Add(row[0], row[1], row[2], row[3], row[4]);
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

                Conexao = new MySqlConnection(data_source);

                string sql = "SELECT * FROM produto";

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
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.GetString(4)
                    };

                    var linha_listview = new ListViewItem(row);
                    dataGridView1.Rows.Add(row[0], row[1], row[2], row[3], row[4]);

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

        private void ListaProduto_Load(object sender, EventArgs e)
        {
            try
            {

                Conexao = new MySqlConnection(data_source);

                string sql = "SELECT * FROM produto";

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
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.GetString(4),
                   
                    };

                    //var linha_listview = new ListViewItem(row);


               
                    dataGridView1.Rows.Add(row[0], row[1], row[2], row[3], row[4]);

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

            printer.Title = "Restaurante Mister Lee\n\n";
            printer.SubTitle = "Relatório de Produtos\n";
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

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void lstProduto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
