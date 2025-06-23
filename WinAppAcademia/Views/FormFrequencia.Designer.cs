namespace WinAppAcademia.Views
{
    partial class FormFrequencia
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
            panelTop = new Panel();
            lblTituloForm = new Label();
            panelContent = new Panel();
            dgvFrequencias = new DataGridView();
            panelInput = new Panel();
            cbPresenca = new ComboBox();
            lblPresenca = new Label();
            dtpDataAula = new DateTimePicker();
            cbAula = new ComboBox();
            lblDataAula = new Label();
            lblAula = new Label();
            cbAluno = new ComboBox();
            lblAluno = new Label();
            panelButtons = new Panel();
            btnLimpar = new Button();
            btnDeletar = new Button();
            btnSalvar = new Button();
            panelTop.SuspendLayout();
            panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFrequencias).BeginInit();
            panelInput.SuspendLayout();
            panelButtons.SuspendLayout();
            SuspendLayout();
            //
            // panelTop
            //
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(184)))));
            this.panelTop.Controls.Add(this.lblTituloForm);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(900, 60);
            this.panelTop.TabIndex = 0;
            //
            // lblTituloForm
            //
            this.lblTituloForm.AutoSize = true;
            this.lblTituloForm.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTituloForm.ForeColor = System.Drawing.Color.White;
            this.lblTituloForm.Location = new System.Drawing.Point(20, 15);
            this.lblTituloForm.Name = "lblTituloForm";
            this.lblTituloForm.Size = new System.Drawing.Size(276, 32);
            this.lblTituloForm.TabIndex = 0;
            this.lblTituloForm.Text = "Registro de Frequência";
            //
            // panelContent
            //
            this.panelContent.Controls.Add(this.dgvFrequencias);
            this.panelContent.Controls.Add(this.panelInput);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 60);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(10);
            this.panelContent.Size = new System.Drawing.Size(900, 540);
            this.panelContent.TabIndex = 1;
            //
            // dgvFrequencias
            //
            this.dgvFrequencias.AllowUserToAddRows = false;
            this.dgvFrequencias.AllowUserToDeleteRows = false;
            this.dgvFrequencias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFrequencias.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvFrequencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFrequencias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFrequencias.Location = new System.Drawing.Point(10, 150);
            this.dgvFrequencias.MultiSelect = false;
            this.dgvFrequencias.Name = "dgvFrequencias";
            this.dgvFrequencias.ReadOnly = true;
            this.dgvFrequencias.RowHeadersVisible = false;
            this.dgvFrequencias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFrequencias.Size = new System.Drawing.Size(880, 380);
            this.dgvFrequencias.TabIndex = 1;
            this.dgvFrequencias.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFrequencias_CellClick);
            //
            // panelInput
            //
            this.panelInput.Controls.Add(this.cbPresenca);
            this.panelInput.Controls.Add(this.lblPresenca);
            this.panelInput.Controls.Add(this.dtpDataAula);
            this.panelInput.Controls.Add(this.cbAula);
            this.panelInput.Controls.Add(this.lblDataAula);
            this.panelInput.Controls.Add(this.lblAula);
            this.panelInput.Controls.Add(this.cbAluno);
            this.panelInput.Controls.Add(this.lblAluno);
            this.panelInput.Controls.Add(this.panelButtons);
            this.panelInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInput.Location = new System.Drawing.Point(10, 10);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(880, 140);
            this.panelInput.TabIndex = 0;
            //
            // cbPresenca
            //
            this.cbPresenca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPresenca.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cbPresenca.FormattingEnabled = true;
            this.cbPresenca.Items.AddRange(new object[] { "sim", "não" });
            this.cbPresenca.Location = new System.Drawing.Point(400, 50);
            this.cbPresenca.Name = "cbPresenca";
            this.cbPresenca.Size = new System.Drawing.Size(100, 25);
            this.cbPresenca.TabIndex = 3;
            //
            // lblPresenca
            //
            this.lblPresenca.AutoSize = true;
            this.lblPresenca.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblPresenca.Location = new System.Drawing.Point(400, 30);
            this.lblPresenca.Name = "lblPresenca";
            this.lblPresenca.Size = new System.Drawing.Size(63, 17);
            this.lblPresenca.TabIndex = 6;
            this.lblPresenca.Text = "Presença:";
            this.lblPresenca.ForeColor = System.Drawing.Color.DimGray; // Ajuste a cor do texto do Label se desejar
            //
            // dtpDataAula
            //
            this.dtpDataAula.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtpDataAula.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataAula.Location = new System.Drawing.Point(230, 50);
            this.dtpDataAula.Name = "dtpDataAula";
            this.dtpDataAula.Size = new System.Drawing.Size(150, 25);
            this.dtpDataAula.TabIndex = 2;
            //
            // cbAula
            //
            this.cbAula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAula.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cbAula.FormattingEnabled = true;
            this.cbAula.Location = new System.Drawing.Point(518, 50); // Mudei para 50 para alinhar com os outros campos
            this.cbAula.Name = "cbAula";
            this.cbAula.Size = new System.Drawing.Size(245, 25);
            this.cbAula.TabIndex = 1;
            //
            // lblDataAula
            //
            this.lblDataAula.AutoSize = true;
            this.lblDataAula.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblDataAula.Location = new System.Drawing.Point(230, 30);
            this.lblDataAula.Name = "lblDataAula";
            this.lblDataAula.Size = new System.Drawing.Size(67, 17);
            this.lblDataAula.TabIndex = 4;
            this.lblDataAula.Text = "Data Aula:";
            this.lblDataAula.ForeColor = System.Drawing.Color.DimGray; // Ajuste a cor do texto do Label se desejar
            //
            // lblAula
            //
            this.lblAula.AutoSize = true;
            this.lblAula.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblAula.Location = new System.Drawing.Point(518, 30);
            this.lblAula.Name = "lblAula";
            this.lblAula.Size = new System.Drawing.Size(36, 17);
            this.lblAula.TabIndex = 2;
            this.lblAula.Text = "Aula:";
            this.lblAula.ForeColor = System.Drawing.Color.DimGray; // Ajuste a cor do texto do Label se desejar
            //
            // cbAluno
            //
            this.cbAluno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAluno.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cbAluno.FormattingEnabled = true;
            this.cbAluno.Location = new System.Drawing.Point(20, 50);
            this.cbAluno.Name = "cbAluno";
            this.cbAluno.Size = new System.Drawing.Size(190, 25);
            this.cbAluno.TabIndex = 0;
            //
            // lblAluno
            //
            this.lblAluno.AutoSize = true;
            this.lblAluno.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblAluno.Location = new System.Drawing.Point(20, 30);
            this.lblAluno.Name = "lblAluno";
            this.lblAluno.Size = new System.Drawing.Size(44, 17);
            this.lblAluno.TabIndex = 0;
            this.lblAluno.Text = "Aluno:";
            this.lblAluno.ForeColor = System.Drawing.Color.DimGray; // Ajuste a cor do texto do Label se desejar
            //
            // panelButtons
            //
            this.panelButtons.Controls.Add(this.btnLimpar);
            this.panelButtons.Controls.Add(this.btnDeletar);
            this.panelButtons.Controls.Add(this.btnSalvar);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 80);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Padding = new System.Windows.Forms.Padding(10);
            this.panelButtons.Size = new System.Drawing.Size(880, 60);
            this.panelButtons.TabIndex = 9;
            //
            // btnLimpar
            //
            this.btnLimpar.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnLimpar.FlatAppearance.BorderSize = 0;
            this.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLimpar.ForeColor = System.Drawing.Color.White;
            this.btnLimpar.Location = new System.Drawing.Point(280, 15);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(100, 35);
            this.btnLimpar.TabIndex = 2;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = false;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            //
            // btnDeletar
            //
            this.btnDeletar.BackColor = System.Drawing.Color.Firebrick;
            this.btnDeletar.FlatAppearance.BorderSize = 0;
            this.btnDeletar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeletar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDeletar.ForeColor = System.Drawing.Color.White; // Mantido como branco para contraste com o vermelho
            this.btnDeletar.Location = new System.Drawing.Point(160, 15);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(100, 35);
            this.btnDeletar.TabIndex = 1;
            this.btnDeletar.Text = "Excluir";
            this.btnDeletar.UseVisualStyleBackColor = false;
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click);
            //
            // btnSalvar
            //
            this.btnSalvar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSalvar.FlatAppearance.BorderSize = 0;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSalvar.ForeColor = System.Drawing.Color.White;
            this.btnSalvar.Location = new System.Drawing.Point(40, 15);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(100, 35);
            this.btnSalvar.TabIndex = 0;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            //
            // FormFrequencia
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormFrequencia";
            this.Text = "FormFrequencia";
            this.Load += new System.EventHandler(this.FormFrequencia_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.dgvFrequencias).EndInit();
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        // Declare os controles aqui
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTituloForm;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.ComboBox cbPresenca;
        private System.Windows.Forms.Label lblPresenca;
        private System.Windows.Forms.DateTimePicker dtpDataAula;
        private System.Windows.Forms.Label lblDataAula;
        private System.Windows.Forms.ComboBox cbAula;
        private System.Windows.Forms.Label lblAula;
        private System.Windows.Forms.ComboBox cbAluno;
        private System.Windows.Forms.Label lblAluno;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.DataGridView dgvFrequencias;
    }
}