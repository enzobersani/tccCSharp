namespace TccRestaurante
{
    partial class ListaVenda
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.codigoVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.funcionario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formaPagamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtValorTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoMesa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigoVenda,
            this.funcionario,
            this.formaPagamento,
            this.qtValorTotal,
            this.codigoMesa,
            this.stVenda,
            this.dataVenda});
            this.dataGridView1.Location = new System.Drawing.Point(36, 32);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1093, 443);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1153, 492);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista";
            // 
            // codigoVenda
            // 
            this.codigoVenda.HeaderText = "Código";
            this.codigoVenda.Name = "codigoVenda";
            this.codigoVenda.ReadOnly = true;
            this.codigoVenda.Width = 150;
            // 
            // funcionario
            // 
            this.funcionario.HeaderText = "Funcionário";
            this.funcionario.Name = "funcionario";
            this.funcionario.ReadOnly = true;
            this.funcionario.Width = 150;
            // 
            // formaPagamento
            // 
            this.formaPagamento.HeaderText = "Forma Pag.";
            this.formaPagamento.Name = "formaPagamento";
            this.formaPagamento.ReadOnly = true;
            this.formaPagamento.Width = 150;
            // 
            // qtValorTotal
            // 
            this.qtValorTotal.HeaderText = "Vl. Total";
            this.qtValorTotal.Name = "qtValorTotal";
            this.qtValorTotal.ReadOnly = true;
            this.qtValorTotal.Width = 150;
            // 
            // codigoMesa
            // 
            this.codigoMesa.HeaderText = "Mesa";
            this.codigoMesa.Name = "codigoMesa";
            this.codigoMesa.ReadOnly = true;
            this.codigoMesa.Width = 150;
            // 
            // stVenda
            // 
            this.stVenda.HeaderText = "Situação";
            this.stVenda.Name = "stVenda";
            this.stVenda.ReadOnly = true;
            this.stVenda.Width = 150;
            // 
            // dataVenda
            // 
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.dataVenda.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataVenda.HeaderText = "Data";
            this.dataVenda.Name = "dataVenda";
            this.dataVenda.ReadOnly = true;
            this.dataVenda.Width = 150;
            // 
            // ListaVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 597);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "ListaVenda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Vendas";
            this.Load += new System.EventHandler(this.ListaVenda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoVenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn funcionario;
        private System.Windows.Forms.DataGridViewTextBoxColumn formaPagamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtValorTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoMesa;
        private System.Windows.Forms.DataGridViewTextBoxColumn stVenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataVenda;
    }
}