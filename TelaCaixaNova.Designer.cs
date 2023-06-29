namespace TccRestaurante
{
    partial class TelaCaixaNova
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCodigoMesa = new System.Windows.Forms.TextBox();
            this.txtPagamento = new System.Windows.Forms.ComboBox();
            this.txtFuncionario = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.btnNovaVenda = new System.Windows.Forms.Button();
            this.txtCodVenda = new System.Windows.Forms.TextBox();
            this.txtCodDesconto = new System.Windows.Forms.TextBox();
            this.txtCodProduto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConfirmarVenda = new System.Windows.Forms.Button();
            this.btnCancelarVenda = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.txtValorTotal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPorPessoa = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtValorPorPessoa = new System.Windows.Forms.TextBox();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.codigoProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantidadeProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtValorPago = new System.Windows.Forms.TextBox();
            this.txtValorTroco = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(401, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 20);
            this.label8.TabIndex = 17;
            this.label8.Text = "Mesa";
            // 
            // txtCodigoMesa
            // 
            this.txtCodigoMesa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtCodigoMesa.Enabled = false;
            this.txtCodigoMesa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoMesa.Location = new System.Drawing.Point(405, 28);
            this.txtCodigoMesa.Name = "txtCodigoMesa";
            this.txtCodigoMesa.Size = new System.Drawing.Size(109, 26);
            this.txtCodigoMesa.TabIndex = 16;
            this.txtCodigoMesa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPagamento
            // 
            this.txtPagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPagamento.FormattingEnabled = true;
            this.txtPagamento.Location = new System.Drawing.Point(405, 83);
            this.txtPagamento.Name = "txtPagamento";
            this.txtPagamento.Size = new System.Drawing.Size(145, 32);
            this.txtPagamento.TabIndex = 6;
            this.txtPagamento.SelectedIndexChanged += new System.EventHandler(this.txtPagamento_SelectedIndexChanged);
            this.txtPagamento.Enter += new System.EventHandler(this.txtPagamento_Enter);
            // 
            // txtFuncionario
            // 
            this.txtFuncionario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFuncionario.Location = new System.Drawing.Point(16, 28);
            this.txtFuncionario.Name = "txtFuncionario";
            this.txtFuncionario.Size = new System.Drawing.Size(131, 29);
            this.txtFuncionario.TabIndex = 1;
            this.txtFuncionario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFuncionario.DoubleClick += new System.EventHandler(this.txtFuncionario_DoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(13, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Funcionário";
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantidade.Location = new System.Drawing.Point(151, 83);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(121, 29);
            this.txtQuantidade.TabIndex = 4;
            this.txtQuantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQuantidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantidade_KeyPress);
            // 
            // btnNovaVenda
            // 
            this.btnNovaVenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnNovaVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovaVenda.Location = new System.Drawing.Point(151, 15);
            this.btnNovaVenda.Name = "btnNovaVenda";
            this.btnNovaVenda.Size = new System.Drawing.Size(121, 42);
            this.btnNovaVenda.TabIndex = 2;
            this.btnNovaVenda.Text = "Iniciar Venda";
            this.btnNovaVenda.UseVisualStyleBackColor = false;
            this.btnNovaVenda.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtCodVenda
            // 
            this.txtCodVenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtCodVenda.Enabled = false;
            this.txtCodVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodVenda.Location = new System.Drawing.Point(278, 28);
            this.txtCodVenda.Name = "txtCodVenda";
            this.txtCodVenda.Size = new System.Drawing.Size(121, 26);
            this.txtCodVenda.TabIndex = 15;
            this.txtCodVenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCodDesconto
            // 
            this.txtCodDesconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodDesconto.Location = new System.Drawing.Point(282, 83);
            this.txtCodDesconto.Name = "txtCodDesconto";
            this.txtCodDesconto.Size = new System.Drawing.Size(109, 29);
            this.txtCodDesconto.TabIndex = 5;
            this.txtCodDesconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodDesconto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodDesconto_KeyPress);
            // 
            // txtCodProduto
            // 
            this.txtCodProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodProduto.Location = new System.Drawing.Point(14, 83);
            this.txtCodProduto.Name = "txtCodProduto";
            this.txtCodProduto.Size = new System.Drawing.Size(131, 29);
            this.txtCodProduto.TabIndex = 3;
            this.txtCodProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodProduto.TextChanged += new System.EventHandler(this.txtCodProduto_TextChanged);
            this.txtCodProduto.DoubleClick += new System.EventHandler(this.txtCodProduto_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(13, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cód. Produto";
            // 
            // btnConfirmarVenda
            // 
            this.btnConfirmarVenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnConfirmarVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmarVenda.Location = new System.Drawing.Point(617, 769);
            this.btnConfirmarVenda.Name = "btnConfirmarVenda";
            this.btnConfirmarVenda.Size = new System.Drawing.Size(137, 38);
            this.btnConfirmarVenda.TabIndex = 7;
            this.btnConfirmarVenda.Text = "Confirmar";
            this.btnConfirmarVenda.UseVisualStyleBackColor = false;
            this.btnConfirmarVenda.Click += new System.EventHandler(this.btnConfirmarVenda_Click);
            // 
            // btnCancelarVenda
            // 
            this.btnCancelarVenda.BackColor = System.Drawing.Color.Red;
            this.btnCancelarVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarVenda.Location = new System.Drawing.Point(475, 768);
            this.btnCancelarVenda.Name = "btnCancelarVenda";
            this.btnCancelarVenda.Size = new System.Drawing.Size(136, 38);
            this.btnCancelarVenda.TabIndex = 8;
            this.btnCancelarVenda.Text = "Cancelar";
            this.btnCancelarVenda.UseVisualStyleBackColor = false;
            this.btnCancelarVenda.Click += new System.EventHandler(this.btnCancelarVenda_Click);
            // 
            // txtValorTotal
            // 
            this.txtValorTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtValorTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValorTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorTotal.Location = new System.Drawing.Point(617, 719);
            this.txtValorTotal.MaxLength = 1000;
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.ReadOnly = true;
            this.txtValorTotal.Size = new System.Drawing.Size(137, 44);
            this.txtValorTotal.TabIndex = 12;
            this.txtValorTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 691);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 25);
            this.label7.TabIndex = 13;
            this.label7.Text = "Por pessoa";
            // 
            // txtPorPessoa
            // 
            this.txtPorPessoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPorPessoa.Location = new System.Drawing.Point(16, 720);
            this.txtPorPessoa.MaxLength = 3;
            this.txtPorPessoa.Name = "txtPorPessoa";
            this.txtPorPessoa.Size = new System.Drawing.Size(83, 31);
            this.txtPorPessoa.TabIndex = 9;
            this.txtPorPessoa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorPessoa_KeyPress);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Maroon;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(714, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(664, 95);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 33);
            this.button2.TabIndex = 17;
            this.button2.Text = "Apagar produto";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtValorPorPessoa
            // 
            this.txtValorPorPessoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtValorPorPessoa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValorPorPessoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorPorPessoa.Location = new System.Drawing.Point(106, 720);
            this.txtValorPorPessoa.MaxLength = 1000;
            this.txtValorPorPessoa.Name = "txtValorPorPessoa";
            this.txtValorPorPessoa.ReadOnly = true;
            this.txtValorPorPessoa.Size = new System.Drawing.Size(135, 44);
            this.txtValorPorPessoa.TabIndex = 18;
            this.txtValorPorPessoa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // codigo
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.codigo.DefaultCellStyle = dataGridViewCellStyle1;
            this.codigo.HeaderText = "Código";
            this.codigo.Name = "codigo";
            // 
            // produto
            // 
            this.produto.HeaderText = "Produto";
            this.produto.Name = "produto";
            this.produto.Width = 700;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigoProduto,
            this.descProduto,
            this.quantidadeProduto,
            this.valorProduto});
            this.dataGridView1.Location = new System.Drawing.Point(14, 134);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.Size = new System.Drawing.Size(742, 554);
            this.dataGridView1.TabIndex = 19;
            // 
            // codigoProduto
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.codigoProduto.DefaultCellStyle = dataGridViewCellStyle3;
            this.codigoProduto.HeaderText = "Código";
            this.codigoProduto.Name = "codigoProduto";
            this.codigoProduto.ReadOnly = true;
            this.codigoProduto.Width = 68;
            // 
            // descProduto
            // 
            this.descProduto.HeaderText = "Produto";
            this.descProduto.Name = "descProduto";
            this.descProduto.ReadOnly = true;
            this.descProduto.Width = 350;
            // 
            // quantidadeProduto
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.quantidadeProduto.DefaultCellStyle = dataGridViewCellStyle4;
            this.quantidadeProduto.HeaderText = "Quantidade";
            this.quantidadeProduto.Name = "quantidadeProduto";
            this.quantidadeProduto.ReadOnly = true;
            this.quantidadeProduto.Width = 150;
            // 
            // valorProduto
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.valorProduto.DefaultCellStyle = dataGridViewCellStyle5;
            this.valorProduto.HeaderText = "Valor R$";
            this.valorProduto.Name = "valorProduto";
            this.valorProduto.ReadOnly = true;
            this.valorProduto.Width = 152;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Location = new System.Drawing.Point(331, 770);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(138, 33);
            this.btnSalvar.TabIndex = 20;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(471, 691);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 25);
            this.label9.TabIndex = 22;
            this.label9.Text = "Vl. Pago";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(330, 691);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 25);
            this.label10.TabIndex = 24;
            this.label10.Text = "Vl. Troco";
            // 
            // txtValorPago
            // 
            this.txtValorPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorPago.Location = new System.Drawing.Point(476, 718);
            this.txtValorPago.Name = "txtValorPago";
            this.txtValorPago.Size = new System.Drawing.Size(135, 44);
            this.txtValorPago.TabIndex = 29;
            this.txtValorPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValorPago.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorPago_KeyPress);
            // 
            // txtValorTroco
            // 
            this.txtValorTroco.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorTroco.Location = new System.Drawing.Point(335, 718);
            this.txtValorTroco.Name = "txtValorTroco";
            this.txtValorTroco.Size = new System.Drawing.Size(135, 44);
            this.txtValorTroco.TabIndex = 30;
            this.txtValorTroco.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(612, 691);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 25);
            this.label11.TabIndex = 31;
            this.label11.Text = "Total";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(278, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 20);
            this.label5.TabIndex = 32;
            this.label5.Text = "Nr. Venda";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(147, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 20);
            this.label4.TabIndex = 33;
            this.label4.Text = "Quantidade";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label12.Location = new System.Drawing.Point(278, 60);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 20);
            this.label12.TabIndex = 34;
            this.label12.Text = "Desconto";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label13.Location = new System.Drawing.Point(401, 60);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(149, 20);
            this.label13.TabIndex = 35;
            this.label13.Text = "Modo Pagamento";
            // 
            // TelaCaixaNova
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(766, 815);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtPagamento);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCodDesconto);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.txtCodigoMesa);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtValorTroco);
            this.Controls.Add(this.txtValorPago);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCodProduto);
            this.Controls.Add(this.txtCodVenda);
            this.Controls.Add(this.btnNovaVenda);
            this.Controls.Add(this.txtFuncionario);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtValorPorPessoa);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCancelarVenda);
            this.Controls.Add(this.btnConfirmarVenda);
            this.Controls.Add(this.txtPorPessoa);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtValorTotal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "TelaCaixaNova";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Caixa";
            this.Load += new System.EventHandler(this.TelaCaixaNova_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TelaCaixaNova_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.Button btnConfirmarVenda;
        private System.Windows.Forms.Button btnCancelarVenda;
        private System.Windows.Forms.TextBox txtCodDesconto;
        private System.Windows.Forms.TextBox txtCodProduto;
        private System.Windows.Forms.Label label1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.TextBox txtFuncionario;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox txtPagamento;
        private System.Windows.Forms.TextBox txtValorTotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPorPessoa;
        private System.Windows.Forms.Button btnNovaVenda;
        private System.Windows.Forms.TextBox txtCodVenda;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtValorPorPessoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn produto;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox txtCodigoMesa;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtValorPago;
        private System.Windows.Forms.TextBox txtValorTroco;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn descProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantidadeProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorProduto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
    }
}