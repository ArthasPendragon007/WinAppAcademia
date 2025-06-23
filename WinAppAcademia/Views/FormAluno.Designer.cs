namespace WinAppAcademia.Views
{
    partial class FormAluno
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
            dgvAlunos = new DataGridView();
            panelInput = new Panel();
            lblStatus = new Label();
            cbStatus = new ComboBox();
            dtpMatricula = new DateTimePicker();
            lblMatricula = new Label();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtTelefone = new TextBox();
            lblTelefone = new Label();
            cbSexo = new ComboBox();
            lblSexo = new Label();
            dtpNascimento = new DateTimePicker();
            lblNascimento = new Label();
            txtCpf = new TextBox();
            lblCpf = new Label();
            txtNome = new TextBox();
            lblNome = new Label();
            panelButtons = new Panel();
            btnLimpar = new Button();
            btnDeletar = new Button();
            btnSalvar = new Button();
            panelTop.SuspendLayout();
            panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAlunos).BeginInit();
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
            panelTop.Paint += panelTop_Paint;
            // 
            // lblTituloForm
            // 
            lblTituloForm.AutoSize = true;
            lblTituloForm.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTituloForm.ForeColor = Color.White;
            lblTituloForm.Location = new Point(20, 15);
            lblTituloForm.Name = "lblTituloForm";
            lblTituloForm.Size = new Size(237, 32);
            lblTituloForm.TabIndex = 0;
            lblTituloForm.Text = "Cadastro de Alunos";
            // 
            // panelContent
            // 
            panelContent.Controls.Add(dgvAlunos);
            panelContent.Controls.Add(panelInput);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 60);
            panelContent.Name = "panelContent";
            panelContent.Padding = new Padding(10);
            panelContent.Size = new Size(900, 540);
            panelContent.TabIndex = 1;
            // 
            // dgvAlunos
            // 
            dgvAlunos.AllowUserToAddRows = false;
            dgvAlunos.AllowUserToDeleteRows = false;
            dgvAlunos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAlunos.BackgroundColor = Color.WhiteSmoke;
            dgvAlunos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAlunos.Dock = DockStyle.Fill;
            dgvAlunos.Location = new Point(10, 240);
            dgvAlunos.MultiSelect = false;
            dgvAlunos.Name = "dgvAlunos";
            dgvAlunos.ReadOnly = true;
            dgvAlunos.RowHeadersVisible = false;
            dgvAlunos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAlunos.Size = new Size(880, 290);
            dgvAlunos.TabIndex = 1;
            dgvAlunos.CellClick += dgvAlunos_CellClick;
            // 
            // panelInput
            // 
            panelInput.Controls.Add(lblStatus);
            panelInput.Controls.Add(cbStatus);
            panelInput.Controls.Add(dtpMatricula);
            panelInput.Controls.Add(lblMatricula);
            panelInput.Controls.Add(txtEmail);
            panelInput.Controls.Add(lblEmail);
            panelInput.Controls.Add(txtTelefone);
            panelInput.Controls.Add(lblTelefone);
            panelInput.Controls.Add(cbSexo);
            panelInput.Controls.Add(lblSexo);
            panelInput.Controls.Add(dtpNascimento);
            panelInput.Controls.Add(lblNascimento);
            panelInput.Controls.Add(txtCpf);
            panelInput.Controls.Add(lblCpf);
            panelInput.Controls.Add(txtNome);
            panelInput.Controls.Add(lblNome);
            panelInput.Controls.Add(panelButtons);
            panelInput.Dock = DockStyle.Top;
            panelInput.Location = new Point(10, 10);
            panelInput.Name = "panelInput";
            panelInput.Size = new Size(880, 230);
            panelInput.TabIndex = 0;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9.75F);
            lblStatus.Location = new Point(580, 105);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(43, 17);
            lblStatus.TabIndex = 15;
            lblStatus.Text = "Status";
            // 
            // cbStatus
            // 
            cbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStatus.Font = new Font("Segoe UI", 9.75F);
            cbStatus.FormattingEnabled = true;
            cbStatus.Items.AddRange(new object[] { "ativo", "inativo" });
            cbStatus.Location = new Point(580, 125);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(150, 25);
            cbStatus.TabIndex = 8;
            // 
            // dtpMatricula
            // 
            dtpMatricula.Font = new Font("Segoe UI", 9.75F);
            dtpMatricula.Format = DateTimePickerFormat.Short;
            dtpMatricula.Location = new Point(400, 125);
            dtpMatricula.Name = "dtpMatricula";
            dtpMatricula.Size = new Size(150, 25);
            dtpMatricula.TabIndex = 7;
            // 
            // lblMatricula
            // 
            lblMatricula.AutoSize = true;
            lblMatricula.Font = new Font("Segoe UI", 9.75F);
            lblMatricula.Location = new Point(400, 105);
            lblMatricula.Name = "lblMatricula";
            lblMatricula.Size = new Size(93, 17);
            lblMatricula.TabIndex = 12;
            lblMatricula.Text = "Data Matrícula";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 9.75F);
            txtEmail.Location = new Point(20, 125);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(350, 25);
            txtEmail.TabIndex = 5;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9.75F);
            lblEmail.Location = new Point(20, 105);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(42, 17);
            lblEmail.TabIndex = 10;
            lblEmail.Text = "Email:";
            // 
            // txtTelefone
            // 
            txtTelefone.Font = new Font("Segoe UI", 9.75F);
            txtTelefone.Location = new Point(600, 50);
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(150, 25);
            txtTelefone.TabIndex = 4;
            // 
            // lblTelefone
            // 
            lblTelefone.AutoSize = true;
            lblTelefone.Font = new Font("Segoe UI", 9.75F);
            lblTelefone.Location = new Point(600, 30);
            lblTelefone.Name = "lblTelefone";
            lblTelefone.Size = new Size(60, 17);
            lblTelefone.TabIndex = 8;
            lblTelefone.Text = "Telefone:";
            // 
            // cbSexo
            // 
            cbSexo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSexo.Font = new Font("Segoe UI", 9.75F);
            cbSexo.FormattingEnabled = true;
            cbSexo.Items.AddRange(new object[] { "M", "F" });
            cbSexo.Location = new Point(500, 50);
            cbSexo.Name = "cbSexo";
            cbSexo.Size = new Size(70, 25);
            cbSexo.TabIndex = 3;
            // 
            // lblSexo
            // 
            lblSexo.AutoSize = true;
            lblSexo.Font = new Font("Segoe UI", 9.75F);
            lblSexo.Location = new Point(500, 30);
            lblSexo.Name = "lblSexo";
            lblSexo.Size = new Size(39, 17);
            lblSexo.TabIndex = 6;
            lblSexo.Text = "Sexo:";
            // 
            // dtpNascimento
            // 
            dtpNascimento.Font = new Font("Segoe UI", 9.75F);
            dtpNascimento.Format = DateTimePickerFormat.Short;
            dtpNascimento.Location = new Point(370, 50);
            dtpNascimento.Name = "dtpNascimento";
            dtpNascimento.Size = new Size(110, 25);
            dtpNascimento.TabIndex = 2;
            // 
            // lblNascimento
            // 
            lblNascimento.AutoSize = true;
            lblNascimento.Font = new Font("Segoe UI", 9.75F);
            lblNascimento.Location = new Point(370, 30);
            lblNascimento.Name = "lblNascimento";
            lblNascimento.Size = new Size(80, 17);
            lblNascimento.TabIndex = 4;
            lblNascimento.Text = "Nascimento:";
            // 
            // txtCpf
            // 
            txtCpf.Font = new Font("Segoe UI", 9.75F);
            txtCpf.Location = new Point(230, 50);
            txtCpf.Name = "txtCpf";
            txtCpf.Size = new Size(120, 25);
            txtCpf.TabIndex = 1;
            // 
            // lblCpf
            // 
            lblCpf.AutoSize = true;
            lblCpf.Font = new Font("Segoe UI", 9.75F);
            lblCpf.Location = new Point(230, 30);
            lblCpf.Name = "lblCpf";
            lblCpf.Size = new Size(32, 17);
            lblCpf.TabIndex = 2;
            lblCpf.Text = "CPF:";
            // 
            // txtNome
            // 
            txtNome.Font = new Font("Segoe UI", 9.75F);
            txtNome.Location = new Point(20, 50);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(190, 25);
            txtNome.TabIndex = 0;
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Font = new Font("Segoe UI", 9.75F);
            lblNome.Location = new Point(20, 30);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(47, 17);
            lblNome.TabIndex = 0;
            lblNome.Text = "Nome:";
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(btnLimpar);
            panelButtons.Controls.Add(btnDeletar);
            panelButtons.Controls.Add(btnSalvar);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(0, 170);
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
            // FormAluno
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(900, 600);
            Controls.Add(panelContent);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormAluno";
            Text = "FormAluno";
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAlunos).EndInit();
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
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtCpf;
        private System.Windows.Forms.Label lblCpf;
        private System.Windows.Forms.DateTimePicker dtpNascimento;
        private System.Windows.Forms.Label lblNascimento;
        private System.Windows.Forms.ComboBox cbSexo;
        private System.Windows.Forms.Label lblSexo;
        private System.Windows.Forms.TextBox txtTelefone;
        private System.Windows.Forms.Label lblTelefone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.DateTimePicker dtpMatricula;
        private System.Windows.Forms.Label lblMatricula;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnDeletar; // Renomeado de Deletar para btnDeletar para consistência
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.DataGridView dgvAlunos;
    }
}