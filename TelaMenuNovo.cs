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
    public partial class TelaMenuNovo : Form
    {
        public TelaMenuNovo()
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void TelaLoginNova_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtDataHora.Text = DateTime.Now.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            TelaCadastroProduto telaCadastroProduto = new TelaCadastroProduto();
            telaCadastroProduto.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ListaProduto listaProduto = new ListaProduto();
            listaProduto.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ListaFornecedor listaFornecedor = new ListaFornecedor();
            listaFornecedor.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ListaFuncionario listaFuncionario = new ListaFuncionario();
            listaFuncionario.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            TelaCaixaNova caixa = new TelaCaixaNova();
            caixa.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TelaCadastroUsuario telaCadastroUsuario = new TelaCadastroUsuario();
            telaCadastroUsuario.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TelaCadastroFornecedor telaCadastroFornecedor = new TelaCadastroFornecedor();
            telaCadastroFornecedor.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TelaCadastroFuncionario telaCadastroFuncionario = new TelaCadastroFuncionario();
            telaCadastroFuncionario.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            TelaMesas telaMesas = new TelaMesas();
            telaMesas.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            TelaCadastrodeDesconto telaCadastrodeDesconto = new TelaCadastrodeDesconto();
            telaCadastrodeDesconto.ShowDialog();
        }

        private void btnPagamento_Click(object sender, EventArgs e)
        {
            TelaCadastroPagamento pagamento = new TelaCadastroPagamento();
            pagamento.ShowDialog();
        }

        private void btnCadastroMesas_Click(object sender, EventArgs e)
        {
            TelaCadastroMesas mesas = new TelaCadastroMesas();
            mesas.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            TelaMovimentacaoEstoque movimentacaoEstoque = new TelaMovimentacaoEstoque();
            movimentacaoEstoque.ShowDialog();
        }

        private void formasPagamentoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            GraficoFormasPagamentos graficoFormasPagamentos = new GraficoFormasPagamentos();
            graficoFormasPagamentos.ShowDialog();
        }

        private void fornecedorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ListaFornecedor listaFornecedor = new ListaFornecedor();
            listaFornecedor.ShowDialog();
        }

        private void funcionarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListaFuncionario listaFuncionario = new ListaFuncionario();
            listaFuncionario.ShowDialog();
        }

        private void formasPagamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListaPagamentosUtilizados listaPagamentosUtilizados = new ListaPagamentosUtilizados();
            listaPagamentosUtilizados.ShowDialog();
        }

        private void produtoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ListaProduto listaProduto = new ListaProduto();
            listaProduto.ShowDialog();
        }

        private void produtoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaCadastroProduto telaCadastroProduto = new TelaCadastroProduto();
            telaCadastroProduto.ShowDialog();
        }

        private void fornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaCadastroFornecedor telaCadastroFornecedor = new TelaCadastroFornecedor();
            telaCadastroFornecedor.ShowDialog();
        }

        private void fabricanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaCadastroFuncionario telaCadastroFuncionario = new TelaCadastroFuncionario();
            telaCadastroFuncionario.ShowDialog();
        }

        private void descontoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaCadastrodeDesconto telaCadastrodeDesconto = new TelaCadastrodeDesconto();
            telaCadastrodeDesconto.ShowDialog();
        }

        private void formasPagametoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaCadastroPagamento telaCadastroPagamento = new TelaCadastroPagamento();
            telaCadastroPagamento.ShowDialog();
        }

        private void mesasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaCadastroMesas telaCadastroMesas = new TelaCadastroMesas();
            telaCadastroMesas.ShowDialog();
        }

        private void usuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaCadastroUsuario telaCadastroUsuario = new TelaCadastroUsuario();
            telaCadastroUsuario.ShowDialog();
        }

        private void descontoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ListaDesconto listaDesconto = new ListaDesconto();
            listaDesconto.ShowDialog();
        }

        private void vendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListaVenda listaVenda = new ListaVenda();
            listaVenda.ShowDialog();
        }

        private void mesasMaisUtilizadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GraficoMesasUtilizadas graficoMesasUtilizadas = new GraficoMesasUtilizadas();
            graficoMesasUtilizadas.ShowDialog();
        }

        private void caixaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaCaixaNova telaCaixaNova = new TelaCaixaNova();
            telaCaixaNova.ShowDialog();
        }

        private void mesasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TelaMesas telaMesas = new TelaMesas();
            telaMesas.ShowDialog();
        }

        private void movimentaçãoEstoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaMovimentacaoEstoque movimentacaoEstoque = new TelaMovimentacaoEstoque();
            movimentacaoEstoque.ShowDialog();
        }
    }
}
