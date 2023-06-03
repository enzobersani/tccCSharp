namespace TccRestaurante
{
    partial class TelaMovimentacaoEstoque
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtQtAtual = new System.Windows.Forms.TextBox();
            this.labelQtMudar = new System.Windows.Forms.Label();
            this.txtQtMudar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRemover = new System.Windows.Forms.RadioButton();
            this.btnAdicionar = new System.Windows.Forms.RadioButton();
            this.txtDescricaoProduto = new System.Windows.Forms.TextBox();
            this.txtCodigoProduto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnLimparTela = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtQtAtual);
            this.groupBox1.Controls.Add(this.labelQtMudar);
            this.groupBox1.Controls.Add(this.txtQtMudar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnRemover);
            this.groupBox1.Controls.Add(this.btnAdicionar);
            this.groupBox1.Controls.Add(this.txtDescricaoProduto);
            this.groupBox1.Controls.Add(this.txtCodigoProduto);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(7, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(781, 124);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Produto";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txtQtAtual
            // 
            this.txtQtAtual.Location = new System.Drawing.Point(236, 77);
            this.txtQtAtual.Name = "txtQtAtual";
            this.txtQtAtual.ReadOnly = true;
            this.txtQtAtual.Size = new System.Drawing.Size(109, 22);
            this.txtQtAtual.TabIndex = 8;
            this.txtQtAtual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelQtMudar
            // 
            this.labelQtMudar.AutoSize = true;
            this.labelQtMudar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQtMudar.Location = new System.Drawing.Point(368, 80);
            this.labelQtMudar.Name = "labelQtMudar";
            this.labelQtMudar.Size = new System.Drawing.Size(75, 16);
            this.labelQtMudar.TabIndex = 7;
            this.labelQtMudar.Text = "Qt. a mudar";
            // 
            // txtQtMudar
            // 
            this.txtQtMudar.Location = new System.Drawing.Point(465, 77);
            this.txtQtMudar.Name = "txtQtMudar";
            this.txtQtMudar.Size = new System.Drawing.Size(109, 22);
            this.txtQtMudar.TabIndex = 6;
            this.txtQtMudar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(174, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Qt. Atual";
            // 
            // btnRemover
            // 
            this.btnRemover.AutoSize = true;
            this.btnRemover.Location = new System.Drawing.Point(667, 29);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(88, 20);
            this.btnRemover.TabIndex = 4;
            this.btnRemover.TabStop = true;
            this.btnRemover.Text = "Remover";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Enter += new System.EventHandler(this.btnRemover_Enter);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.AutoSize = true;
            this.btnAdicionar.Location = new System.Drawing.Point(546, 29);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(91, 20);
            this.btnAdicionar.TabIndex = 3;
            this.btnAdicionar.TabStop = true;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Enter += new System.EventHandler(this.btnAdicionar_Enter);
            // 
            // txtDescricaoProduto
            // 
            this.txtDescricaoProduto.Location = new System.Drawing.Point(130, 27);
            this.txtDescricaoProduto.Name = "txtDescricaoProduto";
            this.txtDescricaoProduto.ReadOnly = true;
            this.txtDescricaoProduto.Size = new System.Drawing.Size(390, 22);
            this.txtDescricaoProduto.TabIndex = 2;
            // 
            // txtCodigoProduto
            // 
            this.txtCodigoProduto.Location = new System.Drawing.Point(63, 26);
            this.txtCodigoProduto.Name = "txtCodigoProduto";
            this.txtCodigoProduto.Size = new System.Drawing.Size(61, 22);
            this.txtCodigoProduto.TabIndex = 1;
            this.txtCodigoProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigoProduto.DoubleClick += new System.EventHandler(this.textBox1_DoubleClick);
            this.txtCodigoProduto.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(639, 142);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(149, 45);
            this.btnSalvar.TabIndex = 1;
            this.btnSalvar.Text = "Confirmar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnLimparTela
            // 
            this.btnLimparTela.Location = new System.Drawing.Point(12, 142);
            this.btnLimparTela.Name = "btnLimparTela";
            this.btnLimparTela.Size = new System.Drawing.Size(149, 45);
            this.btnLimparTela.TabIndex = 2;
            this.btnLimparTela.Text = "Limpar Tela";
            this.btnLimparTela.UseVisualStyleBackColor = true;
            this.btnLimparTela.Click += new System.EventHandler(this.btnLimparTela_Click);
            // 
            // TelaMovimentacaoEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 201);
            this.Controls.Add(this.btnLimparTela);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "TelaMovimentacaoEstoque";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Movimentação de Estoque";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton btnAdicionar;
        private System.Windows.Forms.TextBox txtDescricaoProduto;
        private System.Windows.Forms.TextBox txtCodigoProduto;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox txtQtAtual;
        private System.Windows.Forms.Label labelQtMudar;
        private System.Windows.Forms.TextBox txtQtMudar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton btnRemover;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnLimparTela;
    }
}