using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1;
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
    public partial class ListaFuncionario : Form
    {
        public ListaFuncionario()
        {
            InitializeComponent();
  
            carregar_dados();
        }

        MySqlConnection Conexao = null;
        private string strCon = "Server = localhost; Database=restaurantetcc;Uid=root;Pwd=";

        private void txtCodigoUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void carregar_dados()
        {
            try
            {
                Conexao = new MySqlConnection(strCon);
                Conexao.Open();

                MySqlCommand comando = new MySqlCommand();

                comando.Connection = Conexao;
                comando.CommandText = "SELECT * FROM funcionario ORDER BY id DESC";
                comando.Prepare();

                MySqlDataReader reader = comando.ExecuteReader();

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
 

        private void button1_Click(object sender, EventArgs e)
        {

            var codigo = txtCodigoFuncionario.Text;

            if (txtCodigoFuncionario.Text != "")
            {
                string sql = "SELECT * FROM funcionario WHERE id =" + codigo;
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
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetString(4)  
                        };


                        dataGridView1.Rows.Clear();
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
                string q = "'%" + txtNomeFuncionario.Text + "%'";

                Conexao = new MySqlConnection(strCon);

                string sql = "SELECT * FROM funcionario WHERE nome LIKE " + q;

                Conexao.Open();

                MySqlCommand comando = new MySqlCommand(sql, Conexao);

                MySqlDataReader reader = comando.ExecuteReader();

         

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
                    dataGridView1.Rows.Clear();
                    dataGridView1.Rows.Add(row[0], row[1], row[2], row[3], row[4]);

                }

            }
            catch(Exception ex)
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
            try
            {

                Conexao = new MySqlConnection(strCon);

                string sql = "SELECT * FROM funcionario";

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
                        reader.GetString(4),
                        reader.GetString(9)
                    };


                    if (row[0] != null)
                    {
                        dataGridView1.Rows.Add(row[0], row[1], row[2], row[3], row[4]);
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

        private void ListaFuncionario_Load(object sender, EventArgs e)
        {
            try
            {
                Conexao = new MySqlConnection(strCon);

                string sql = "SELECT * FROM funcionario";

                Conexao.Open();

                MySqlCommand comando = new MySqlCommand(sql, Conexao);

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    string[] row =
                    {
                        reader.GetString(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(4),
                        reader.GetString(9)        
                    };


                    if (row[0] != null)
                    {
                        dataGridView1.Rows.Add(row[0], row[1], row[2], row[3], row[4]);
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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult confirmar = MessageBox.Show("Deseja realmente excluir o registro?", "", MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Warning);

                if (confirmar == DialogResult.Yes)
                {
                    MessageBox.Show("Funcionário excluido com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    carregar_dados();
                }


            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocorreu um erro!");
            }
            finally
            {
                Conexao.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
      
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
       
        }

        private void txtNomeFuncionario_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        { 

        }

        private void PrintPDF(object sender, EventArgs e)
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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
