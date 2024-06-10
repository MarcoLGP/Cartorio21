namespace Cartório21
{
    partial class Form_Principal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridTitulos = new System.Windows.Forms.DataGridView();
            this.Protocolo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomeCredor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomeDevedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EspecieTitulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataApresentacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCriarTitulo = new System.Windows.Forms.Button();
            this.btnAlterarTitulo = new System.Windows.Forms.Button();
            this.btnExcluirTitulo = new System.Windows.Forms.Button();
            this.btnDetalheTitulo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnImportaXML = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridTitulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridTitulos
            // 
            this.gridTitulos.AllowUserToAddRows = false;
            this.gridTitulos.AllowUserToDeleteRows = false;
            this.gridTitulos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridTitulos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridTitulos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridTitulos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Protocolo,
            this.NomeCredor,
            this.NomeDevedor,
            this.EspecieTitulo,
            this.DataApresentacao});
            this.gridTitulos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridTitulos.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.gridTitulos.Location = new System.Drawing.Point(1, -1);
            this.gridTitulos.Name = "gridTitulos";
            this.gridTitulos.ReadOnly = true;
            this.gridTitulos.RowHeadersVisible = false;
            this.gridTitulos.Size = new System.Drawing.Size(887, 580);
            this.gridTitulos.TabIndex = 5;
            // 
            // Protocolo
            // 
            this.Protocolo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Protocolo.DataPropertyName = "Protocolo";
            this.Protocolo.FillWeight = 35.74225F;
            this.Protocolo.HeaderText = "Protocolo";
            this.Protocolo.Name = "Protocolo";
            this.Protocolo.ReadOnly = true;
            this.Protocolo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // NomeCredor
            // 
            this.NomeCredor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NomeCredor.DataPropertyName = "NomeCredor";
            this.NomeCredor.FillWeight = 109.1447F;
            this.NomeCredor.HeaderText = "Credor";
            this.NomeCredor.Name = "NomeCredor";
            this.NomeCredor.ReadOnly = true;
            // 
            // NomeDevedor
            // 
            this.NomeDevedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NomeDevedor.DataPropertyName = "NomeDevedor";
            this.NomeDevedor.FillWeight = 109.1447F;
            this.NomeDevedor.HeaderText = "Devedor";
            this.NomeDevedor.Name = "NomeDevedor";
            this.NomeDevedor.ReadOnly = true;
            // 
            // EspecieTitulo
            // 
            this.EspecieTitulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EspecieTitulo.DataPropertyName = "EspecieTitulo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.EspecieTitulo.DefaultCellStyle = dataGridViewCellStyle1;
            this.EspecieTitulo.FillWeight = 40F;
            this.EspecieTitulo.HeaderText = "Espécie titulo";
            this.EspecieTitulo.Name = "EspecieTitulo";
            this.EspecieTitulo.ReadOnly = true;
            // 
            // DataApresentacao
            // 
            this.DataApresentacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DataApresentacao.DataPropertyName = "DataApresentacao";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DataApresentacao.DefaultCellStyle = dataGridViewCellStyle2;
            this.DataApresentacao.FillWeight = 40F;
            this.DataApresentacao.HeaderText = "Data apresentação";
            this.DataApresentacao.Name = "DataApresentacao";
            this.DataApresentacao.ReadOnly = true;
            // 
            // btnCriarTitulo
            // 
            this.btnCriarTitulo.Location = new System.Drawing.Point(908, 247);
            this.btnCriarTitulo.Name = "btnCriarTitulo";
            this.btnCriarTitulo.Size = new System.Drawing.Size(125, 35);
            this.btnCriarTitulo.TabIndex = 6;
            this.btnCriarTitulo.Text = "Criar título";
            this.btnCriarTitulo.UseVisualStyleBackColor = true;
            this.btnCriarTitulo.Click += new System.EventHandler(this.btnCriarTitulo_Click);
            // 
            // btnAlterarTitulo
            // 
            this.btnAlterarTitulo.Enabled = false;
            this.btnAlterarTitulo.Location = new System.Drawing.Point(909, 329);
            this.btnAlterarTitulo.Name = "btnAlterarTitulo";
            this.btnAlterarTitulo.Size = new System.Drawing.Size(125, 35);
            this.btnAlterarTitulo.TabIndex = 7;
            this.btnAlterarTitulo.Text = "Alterar título";
            this.btnAlterarTitulo.UseVisualStyleBackColor = true;
            this.btnAlterarTitulo.Click += new System.EventHandler(this.btnAlterarTitulo_Click);
            // 
            // btnExcluirTitulo
            // 
            this.btnExcluirTitulo.Enabled = false;
            this.btnExcluirTitulo.Location = new System.Drawing.Point(909, 370);
            this.btnExcluirTitulo.Name = "btnExcluirTitulo";
            this.btnExcluirTitulo.Size = new System.Drawing.Size(125, 35);
            this.btnExcluirTitulo.TabIndex = 8;
            this.btnExcluirTitulo.Text = "Excluir título";
            this.btnExcluirTitulo.UseVisualStyleBackColor = true;
            this.btnExcluirTitulo.Click += new System.EventHandler(this.btnExcluirTitulo_Click);
            // 
            // btnDetalheTitulo
            // 
            this.btnDetalheTitulo.Enabled = false;
            this.btnDetalheTitulo.Location = new System.Drawing.Point(908, 288);
            this.btnDetalheTitulo.Name = "btnDetalheTitulo";
            this.btnDetalheTitulo.Size = new System.Drawing.Size(125, 35);
            this.btnDetalheTitulo.TabIndex = 9;
            this.btnDetalheTitulo.Text = "Detalhes título";
            this.btnDetalheTitulo.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(922, 431);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Versão: 1.0.0";
            // 
            // btnImportaXML
            // 
            this.btnImportaXML.Location = new System.Drawing.Point(908, 177);
            this.btnImportaXML.Name = "btnImportaXML";
            this.btnImportaXML.Size = new System.Drawing.Size(125, 35);
            this.btnImportaXML.TabIndex = 11;
            this.btnImportaXML.Text = "Importar XML";
            this.btnImportaXML.UseVisualStyleBackColor = true;
            this.btnImportaXML.Click += new System.EventHandler(this.btnImportaXML_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Cartório21.Properties.Resources.cartório21_logo1;
            this.pictureBox1.Location = new System.Drawing.Point(894, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(155, 130);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Form_Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1052, 583);
            this.Controls.Add(this.btnImportaXML);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnDetalheTitulo);
            this.Controls.Add(this.btnExcluirTitulo);
            this.Controls.Add(this.btnAlterarTitulo);
            this.Controls.Add(this.btnCriarTitulo);
            this.Controls.Add(this.gridTitulos);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.Name = "Form_Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Títulos Cartório";
            this.Load += new System.EventHandler(this.Form_Principal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridTitulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView gridTitulos;
        private System.Windows.Forms.Button btnCriarTitulo;
        private System.Windows.Forms.Button btnAlterarTitulo;
        private System.Windows.Forms.Button btnExcluirTitulo;
        private System.Windows.Forms.Button btnDetalheTitulo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnImportaXML;
        private System.Windows.Forms.DataGridViewTextBoxColumn Protocolo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeCredor;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeDevedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn EspecieTitulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataApresentacao;
    }
}

