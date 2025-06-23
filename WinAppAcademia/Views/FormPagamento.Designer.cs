namespace WinAppAcademia.Views
{
    partial class FormPagamento
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
            dgvPagamentos = new DataGridView();
            panelInput = new Panel();
            cbStatusPagamento = new ComboBox();
            lblStatusPagamento = new Label();
            txtValor = new TextBox();
            lblValor = new Label();
            dtpDataPagamento = new DateTimePicker();
            lblDataPagamento = new Label();
            cbAluno = new ComboBox();
            lblAluno = new Label();
            panelButtons = new Panel();
            btnLimpar = new Button();
            btnDeletar = new Button();
            btnSalvar = new Button();
            panelTop.SuspendLayout();
            panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPagamentos).BeginInit();
            panelInput.SuspendLayout();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(0, 102, 184);
            panelTop.Controls.Add(lblTituloForm);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(900, 60);
            panelTop.TabIndex = 0;
            // 
            // lblTituloForm
            // 
            lblTituloForm.AutoSize = true;
            lblTituloForm.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTituloForm.ForeColor = Color.White;
            lblTituloForm.Location = new Point(20, 15);
            lblTituloForm.Name = "lblTituloForm";
            lblTituloForm.Size = new Size(291, 32);
            lblTituloForm.TabIndex = 0;
            lblTituloForm.Text = "Registro de Pagamentos";
            // 
            // panelContent
            // 
            panelContent.Controls.Add(dgvPagamentos);
            panelContent.Controls.Add(panelInput);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 60);
            panelContent.Name = "panelContent";
            panelContent.Padding = new Padding(10);
            panelContent.Size = new Size(900, 540);
            panelContent.TabIndex = 1;
            // 
            // dgvPagamentos
            // 
            dgvPagamentos.AllowUserToAddRows = false;
            dgvPagamentos.AllowUserToDeleteRows = false;
            dgvPagamentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPagamentos.BackgroundColor = Color.WhiteSmoke;
            dgvPagamentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPagamentos.Dock = DockStyle.Fill;
            dgvPagamentos.Location = new Point(10, 180);
            dgvPagamentos.MultiSelect = false;
            dgvPagamentos.Name = "dgvPagamentos";
            dgvPagamentos.ReadOnly = true;
            dgvPagamentos.RowHeadersVisible = false;
            dgvPagamentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPagamentos.Size = new Size(880, 350);
            dgvPagamentos.TabIndex = 1;
            dgvPagamentos.CellClick += dgvPagamentos_CellClick;
            // 
            // panelInput
            // 
            panelInput.Controls.Add(cbStatusPagamento);
            panelInput.Controls.Add(lblStatusPagamento);
            panelInput.Controls.Add(txtValor);
            panelInput.Controls.Add(lblValor);
            panelInput.Controls.Add(dtpDataPagamento);
            panelInput.Controls.Add(lblDataPagamento);
            panelInput.Controls.Add(cbAluno);
            panelInput.Controls.Add(lblAluno);
            panelInput.Controls.Add(panelButtons);
            panelInput.Dock = DockStyle.Top;
            panelInput.Location = new Point(10, 10);
            panelInput.Name = "panelInput";
            panelInput.Size = new Size(880, 170);
            panelInput.TabIndex = 0;
            // 
            // cbStatusPagamento
            // 
            cbStatusPagamento.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStatusPagamento.Font = new Font("Segoe UI", 9.75F);
            cbStatusPagamento.FormattingEnabled = true;
            cbStatusPagamento.Items.AddRange(new object[] { "pago", "pendente" });
            cbStatusPagamento.Location = new Point(480, 50);
            cbStatusPagamento.Name = "cbStatusPagamento";
            cbStatusPagamento.Size = new Size(150, 25);
            cbStatusPagamento.TabIndex = 3;
            // 
            // lblStatusPagamento
            // 
            lblStatusPagamento.AutoSize = true;
            lblStatusPagamento.Font = new Font("Segoe UI", 9.75F);
            lblStatusPagamento.Location = new Point(480, 30);
            lblStatusPagamento.Name = "lblStatusPagamento";
            lblStatusPagamento.Size = new Size(116, 17);
            lblStatusPagamento.TabIndex = 6;
            lblStatusPagamento.Text = "Status Pagamento:";
            // 
            // txtValor
            // 
            txtValor.Font = new Font("Segoe UI", 9.75F);
            txtValor.Location = new Point(320, 50);
            txtValor.Name = "txtValor";
            txtValor.Size = new Size(130, 25);
            txtValor.TabIndex = 2;
            // 
            // lblValor
            // 
            lblValor.AutoSize = true;
            lblValor.Font = new Font("Segoe UI", 9.75F);
            lblValor.Location = new Point(320, 30);
            lblValor.Name = "lblValor";
            lblValor.Size = new Size(41, 17);
            lblValor.TabIndex = 4;
            lblValor.Text = "Valor:";
            // 
            // dtpDataPagamento
            // 
            dtpDataPagamento.Font = new Font("Segoe UI", 9.75F);
            dtpDataPagamento.Format = DateTimePickerFormat.Short;
            dtpDataPagamento.Location = new Point(190, 50);
            dtpDataPagamento.Name = "dtpDataPagamento";
            dtpDataPagamento.Size = new Size(110, 25);
            dtpDataPagamento.TabIndex = 1;
            // 
            // lblDataPagamento
            // 
            lblDataPagamento.AutoSize = true;
            lblDataPagamento.Font = new Font("Segoe UI", 9.75F);
            lblDataPagamento.Location = new Point(190, 30);
            lblDataPagamento.Name = "lblDataPagamento";
            lblDataPagamento.Size = new Size(108, 17);
            lblDataPagamento.TabIndex = 2;
            lblDataPagamento.Text = "Data Pagamento:";
            // 
            // cbAluno
            // 
            cbAluno.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAluno.Font = new Font("Segoe UI", 9.75F);
            cbAluno.FormattingEnabled = true;
            cbAluno.Location = new Point(20, 50);
            cbAluno.Name = "cbAluno";
            cbAluno.Size = new Size(150, 25);
            cbAluno.TabIndex = 0;
            // 
            // lblAluno
            // 
            lblAluno.AutoSize = true;
            lblAluno.Font = new Font("Segoe UI", 9.75F);
            lblAluno.Location = new Point(20, 30);
            lblAluno.Name = "lblAluno";
            lblAluno.Size = new Size(44, 17);
            lblAluno.TabIndex = 0;
            lblAluno.Text = "Aluno:";
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(btnLimpar);
            panelButtons.Controls.Add(btnDeletar);
            panelButtons.Controls.Add(btnSalvar);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(0, 110);
            panelButtons.Name = "panelButtons";
            panelButtons.Padding = new Padding(10);
            panelButtons.Size = new Size(880, 60);
            panelButtons.TabIndex = 7;
            // 
            // btnLimpar
            // 
            btnLimpar.BackColor = Color.LightSlateGray;
            btnLimpar.FlatAppearance.BorderSize = 0;
            btnLimpar.FlatStyle = FlatStyle.Flat;
            btnLimpar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLimpar.ForeColor = Color.White;
            btnLimpar.Location = new Point(280, 15);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(100, 35);
            btnLimpar.TabIndex = 2;
            btnLimpar.Text = "Limpar";
            btnLimpar.UseVisualStyleBackColor = false;
            btnLimpar.Click += btnLimpar_Click;
            // 
            // btnDeletar
            // 
            btnDeletar.BackColor = Color.Firebrick;
            btnDeletar.FlatAppearance.BorderSize = 0;
            btnDeletar.FlatStyle = FlatStyle.Flat;
            btnDeletar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDeletar.ForeColor = Color.White;
            btnDeletar.Location = new Point(160, 15);
            btnDeletar.Name = "btnDeletar";
            btnDeletar.Size = new Size(100, 35);
            btnDeletar.TabIndex = 1;
            btnDeletar.Text = "Excluir";
            btnDeletar.UseVisualStyleBackColor = false;
            btnDeletar.Click += btnDeletar_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.BackColor = Color.FromArgb(0, 122, 204);
            btnSalvar.FlatAppearance.BorderSize = 0;
            btnSalvar.FlatStyle = FlatStyle.Flat;
            btnSalvar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSalvar.ForeColor = Color.White;
            btnSalvar.Location = new Point(40, 15);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(100, 35);
            btnSalvar.TabIndex = 0;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = false;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // FormPagamento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(900, 600);
            Controls.Add(panelContent);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormPagamento";
            Text = "FormPagamento";
            Load += FormPagamento_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPagamentos).EndInit();
            panelInput.ResumeLayout(false);
            panelInput.PerformLayout();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        // Declare os controles aqui
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTituloForm;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.ComboBox cbAluno;
        private System.Windows.Forms.Label lblAluno;
        private System.Windows.Forms.DateTimePicker dtpDataPagamento;
        private System.Windows.Forms.Label lblDataPagamento;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.ComboBox cbStatusPagamento;
        private System.Windows.Forms.Label lblStatusPagamento;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.DataGridView dgvPagamentos;
    }
}