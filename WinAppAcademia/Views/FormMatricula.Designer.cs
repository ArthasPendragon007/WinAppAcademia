namespace WinAppAcademia.Views
{
    partial class FormMatricula
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
            dgvMatriculas = new DataGridView();
            panelInput = new Panel();
            cbStatusMatricula = new ComboBox();
            lblStatusMatricula = new Label();
            dtpDataFim = new DateTimePicker();
            lblDataFim = new Label();
            dtpDataInicio = new DateTimePicker();
            lblDataInicio = new Label();
            cbModalidade = new ComboBox();
            lblModalidade = new Label();
            cbAluno = new ComboBox();
            lblAluno = new Label();
            panelButtons = new Panel();
            btnLimpar = new Button();
            btnDeletar = new Button();
            btnSalvar = new Button();
            panelTop.SuspendLayout();
            panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMatriculas).BeginInit();
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
            lblTituloForm.Size = new Size(277, 32);
            lblTituloForm.TabIndex = 0;
            lblTituloForm.Text = "Cadastro de Matrículas";
            // 
            // panelContent
            // 
            panelContent.Controls.Add(dgvMatriculas);
            panelContent.Controls.Add(panelInput);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 60);
            panelContent.Name = "panelContent";
            panelContent.Padding = new Padding(10);
            panelContent.Size = new Size(900, 540);
            panelContent.TabIndex = 1;
            // 
            // dgvMatriculas
            // 
            dgvMatriculas.AllowUserToAddRows = false;
            dgvMatriculas.AllowUserToDeleteRows = false;
            dgvMatriculas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMatriculas.BackgroundColor = Color.WhiteSmoke;
            dgvMatriculas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMatriculas.Dock = DockStyle.Fill;
            dgvMatriculas.Location = new Point(10, 210);
            dgvMatriculas.MultiSelect = false;
            dgvMatriculas.Name = "dgvMatriculas";
            dgvMatriculas.ReadOnly = true;
            dgvMatriculas.RowHeadersVisible = false;
            dgvMatriculas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMatriculas.Size = new Size(880, 320);
            dgvMatriculas.TabIndex = 1;
            dgvMatriculas.CellClick += dgvMatriculas_CellClick;
            // 
            // panelInput
            // 
            panelInput.Controls.Add(cbStatusMatricula);
            panelInput.Controls.Add(lblStatusMatricula);
            panelInput.Controls.Add(dtpDataFim);
            panelInput.Controls.Add(lblDataFim);
            panelInput.Controls.Add(dtpDataInicio);
            panelInput.Controls.Add(lblDataInicio);
            panelInput.Controls.Add(cbModalidade);
            panelInput.Controls.Add(lblModalidade);
            panelInput.Controls.Add(cbAluno);
            panelInput.Controls.Add(lblAluno);
            panelInput.Controls.Add(panelButtons);
            panelInput.Dock = DockStyle.Top;
            panelInput.Location = new Point(10, 10);
            panelInput.Name = "panelInput";
            panelInput.Size = new Size(880, 200);
            panelInput.TabIndex = 0;
            // 
            // cbStatusMatricula
            // 
            cbStatusMatricula.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStatusMatricula.Font = new Font("Segoe UI", 9.75F);
            cbStatusMatricula.FormattingEnabled = true;
            cbStatusMatricula.Items.AddRange(new object[] { "ativa", "cancelada" });
            cbStatusMatricula.Location = new Point(480, 99);
            cbStatusMatricula.Name = "cbStatusMatricula";
            cbStatusMatricula.Size = new Size(150, 25);
            cbStatusMatricula.TabIndex = 4;
            // 
            // lblStatusMatricula
            // 
            lblStatusMatricula.AutoSize = true;
            lblStatusMatricula.Font = new Font("Segoe UI", 9.75F);
            lblStatusMatricula.Location = new Point(480, 79);
            lblStatusMatricula.Name = "lblStatusMatricula";
            lblStatusMatricula.Size = new Size(123, 17);
            lblStatusMatricula.TabIndex = 8;
            lblStatusMatricula.Text = "Status da Matrícula:";
            // 
            // dtpDataFim
            // 
            dtpDataFim.Font = new Font("Segoe UI", 9.75F);
            dtpDataFim.Format = DateTimePickerFormat.Short;
            dtpDataFim.Location = new Point(250, 99);
            dtpDataFim.Name = "dtpDataFim";
            dtpDataFim.ShowCheckBox = true;
            dtpDataFim.Size = new Size(150, 25);
            dtpDataFim.TabIndex = 3;
            // 
            // lblDataFim
            // 
            lblDataFim.AutoSize = true;
            lblDataFim.Font = new Font("Segoe UI", 9.75F);
            lblDataFim.Location = new Point(250, 79);
            lblDataFim.Name = "lblDataFim";
            lblDataFim.Size = new Size(81, 17);
            lblDataFim.TabIndex = 6;
            lblDataFim.Text = "Data de Fim:";
            // 
            // dtpDataInicio
            // 
            dtpDataInicio.Font = new Font("Segoe UI", 9.75F);
            dtpDataInicio.Format = DateTimePickerFormat.Short;
            dtpDataInicio.Location = new Point(20, 99);
            dtpDataInicio.Name = "dtpDataInicio";
            dtpDataInicio.Size = new Size(150, 25);
            dtpDataInicio.TabIndex = 2;
            // 
            // lblDataInicio
            // 
            lblDataInicio.AutoSize = true;
            lblDataInicio.Font = new Font("Segoe UI", 9.75F);
            lblDataInicio.Location = new Point(20, 79);
            lblDataInicio.Name = "lblDataInicio";
            lblDataInicio.Size = new Size(91, 17);
            lblDataInicio.TabIndex = 4;
            lblDataInicio.Text = "Data de Início:";
            // 
            // cbModalidade
            // 
            cbModalidade.DropDownStyle = ComboBoxStyle.DropDownList;
            cbModalidade.Font = new Font("Segoe UI", 9.75F);
            cbModalidade.FormattingEnabled = true;
            cbModalidade.Location = new Point(250, 50);
            cbModalidade.Name = "cbModalidade";
            cbModalidade.Size = new Size(200, 25);
            cbModalidade.TabIndex = 1;
            // 
            // lblModalidade
            // 
            lblModalidade.AutoSize = true;
            lblModalidade.Font = new Font("Segoe UI", 9.75F);
            lblModalidade.Location = new Point(250, 30);
            lblModalidade.Name = "lblModalidade";
            lblModalidade.Size = new Size(82, 17);
            lblModalidade.TabIndex = 2;
            lblModalidade.Text = "Modalidade:";
            // 
            // cbAluno
            // 
            cbAluno.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAluno.Font = new Font("Segoe UI", 9.75F);
            cbAluno.FormattingEnabled = true;
            cbAluno.Location = new Point(20, 50);
            cbAluno.Name = "cbAluno";
            cbAluno.Size = new Size(200, 25);
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
            panelButtons.Location = new Point(0, 140);
            panelButtons.Name = "panelButtons";
            panelButtons.Padding = new Padding(10);
            panelButtons.Size = new Size(880, 60);
            panelButtons.TabIndex = 9;
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
            // FormMatricula
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(900, 600);
            Controls.Add(panelContent);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormMatricula";
            Text = "FormMatricula";
            Load += FormMatricula_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMatriculas).EndInit();
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
        private System.Windows.Forms.ComboBox cbModalidade;
        private System.Windows.Forms.Label lblModalidade;
        private System.Windows.Forms.DateTimePicker dtpDataInicio;
        private System.Windows.Forms.Label lblDataInicio;
        private System.Windows.Forms.DateTimePicker dtpDataFim;
        private System.Windows.Forms.Label lblDataFim;
        private System.Windows.Forms.ComboBox cbStatusMatricula;
        private System.Windows.Forms.Label lblStatusMatricula;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.DataGridView dgvMatriculas;
    }
}