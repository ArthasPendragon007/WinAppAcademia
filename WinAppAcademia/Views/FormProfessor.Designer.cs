namespace WinAppAcademia.Views
{
    partial class FormProfessor
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
            dgvProfessores = new DataGridView();
            panelInput = new Panel();
            cbModalidade = new ComboBox();
            lblModalidade = new Label();
            cbAcademia = new ComboBox();
            lblAcademia = new Label();
            txtEmail = new TextBox();
            txtNome = new TextBox();
            lblEmail = new Label();
            txtTelefone = new TextBox();
            lblTelefone = new Label();
            cbSexo = new ComboBox();
            lblSexo = new Label();
            dtpNascimento = new DateTimePicker();
            lblNascimento = new Label();
            txtCpf = new TextBox();
            lblCpf = new Label();
            lblNome = new Label();
            panelButtons = new Panel();
            btnLimpar = new Button();
            btnDeletar = new Button();
            btnSalvar = new Button();
            panelTop.SuspendLayout();
            panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProfessores).BeginInit();
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
            panelTop.Margin = new Padding(3, 4, 3, 4);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1029, 80);
            panelTop.TabIndex = 0;
            // 
            // lblTituloForm
            // 
            lblTituloForm.AutoSize = true;
            lblTituloForm.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTituloForm.ForeColor = Color.White;
            lblTituloForm.Location = new Point(23, 20);
            lblTituloForm.Name = "lblTituloForm";
            lblTituloForm.Size = new Size(355, 41);
            lblTituloForm.TabIndex = 0;
            lblTituloForm.Text = "Cadastro de Professores";
            // 
            // panelContent
            // 
            panelContent.Controls.Add(dgvProfessores);
            panelContent.Controls.Add(panelInput);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 80);
            panelContent.Margin = new Padding(3, 4, 3, 4);
            panelContent.Name = "panelContent";
            panelContent.Padding = new Padding(11, 13, 11, 13);
            panelContent.Size = new Size(1029, 720);
            panelContent.TabIndex = 1;
            // 
            // dgvProfessores
            // 
            dgvProfessores.AllowUserToAddRows = false;
            dgvProfessores.AllowUserToDeleteRows = false;
            dgvProfessores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProfessores.BackgroundColor = Color.WhiteSmoke;
            dgvProfessores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProfessores.Dock = DockStyle.Fill;
            dgvProfessores.Location = new Point(11, 280);
            dgvProfessores.Margin = new Padding(3, 4, 3, 4);
            dgvProfessores.MultiSelect = false;
            dgvProfessores.Name = "dgvProfessores";
            dgvProfessores.ReadOnly = true;
            dgvProfessores.RowHeadersVisible = false;
            dgvProfessores.RowHeadersWidth = 51;
            dgvProfessores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProfessores.Size = new Size(1007, 427);
            dgvProfessores.TabIndex = 1;
            dgvProfessores.CellClick += dgvProfessores_CellClick;
            // 
            // panelInput
            // 
            panelInput.Controls.Add(cbModalidade);
            panelInput.Controls.Add(lblModalidade);
            panelInput.Controls.Add(cbAcademia);
            panelInput.Controls.Add(lblAcademia);
            panelInput.Controls.Add(txtEmail);
            panelInput.Controls.Add(txtNome);
            panelInput.Controls.Add(lblEmail);
            panelInput.Controls.Add(txtTelefone);
            panelInput.Controls.Add(lblTelefone);
            panelInput.Controls.Add(cbSexo);
            panelInput.Controls.Add(lblSexo);
            panelInput.Controls.Add(dtpNascimento);
            panelInput.Controls.Add(lblNascimento);
            panelInput.Controls.Add(txtCpf);
            panelInput.Controls.Add(lblCpf);
            panelInput.Controls.Add(lblNome);
            panelInput.Controls.Add(panelButtons);
            panelInput.Dock = DockStyle.Top;
            panelInput.Location = new Point(11, 13);
            panelInput.Margin = new Padding(3, 4, 3, 4);
            panelInput.Name = "panelInput";
            panelInput.Size = new Size(1007, 267);
            panelInput.TabIndex = 0;
            // 
            // cbModalidade
            // 
            cbModalidade.DropDownStyle = ComboBoxStyle.DropDownList;
            cbModalidade.Font = new Font("Segoe UI", 9.75F);
            cbModalidade.FormattingEnabled = true;
            cbModalidade.Location = new Point(320, 141);
            cbModalidade.Margin = new Padding(3, 4, 3, 4);
            cbModalidade.Name = "cbModalidade";
            cbModalidade.Size = new Size(228, 29);
            cbModalidade.TabIndex = 5;
            // 
            // lblModalidade
            // 
            lblModalidade.AutoSize = true;
            lblModalidade.Font = new Font("Segoe UI", 9.75F);
            lblModalidade.Location = new Point(320, 114);
            lblModalidade.Name = "lblModalidade";
            lblModalidade.Size = new Size(104, 23);
            lblModalidade.TabIndex = 10;
            lblModalidade.Text = "Modalidade:";
            // 
            // cbAcademia
            // 
            cbAcademia.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAcademia.Font = new Font("Segoe UI", 9.75F);
            cbAcademia.FormattingEnabled = true;
            cbAcademia.Location = new Point(598, 141);
            cbAcademia.Margin = new Padding(3, 4, 3, 4);
            cbAcademia.Name = "cbAcademia";
            cbAcademia.Size = new Size(228, 29);
            cbAcademia.TabIndex = 6;
            // 
            // lblAcademia
            // 
            lblAcademia.AutoSize = true;
            lblAcademia.Font = new Font("Segoe UI", 9.75F);
            lblAcademia.Location = new Point(598, 114);
            lblAcademia.Name = "lblAcademia";
            lblAcademia.Size = new Size(89, 23);
            lblAcademia.TabIndex = 12;
            lblAcademia.Text = "Academia:";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 9.75F);
            txtEmail.Location = new Point(126, 141);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(171, 29);
            txtEmail.TabIndex = 4;
            // 
            // txtNome
            // 
            txtNome.Font = new Font("Segoe UI", 9.75F);
            txtNome.Location = new Point(32, 63);
            txtNome.Margin = new Padding(3, 4, 3, 4);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(228, 29);
            txtNome.TabIndex = 0;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9.75F);
            lblEmail.Location = new Point(126, 114);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(55, 23);
            lblEmail.TabIndex = 8;
            lblEmail.Text = "Email:";
            // 
            // txtTelefone
            // 
            txtTelefone.Font = new Font("Segoe UI", 9.75F);
            txtTelefone.Location = new Point(818, 63);
            txtTelefone.Margin = new Padding(3, 4, 3, 4);
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(114, 29);
            txtTelefone.TabIndex = 3;
            // 
            // lblTelefone
            // 
            lblTelefone.AutoSize = true;
            lblTelefone.Font = new Font("Segoe UI", 9.75F);
            lblTelefone.Location = new Point(818, 36);
            lblTelefone.Name = "lblTelefone";
            lblTelefone.Size = new Size(77, 23);
            lblTelefone.TabIndex = 6;
            lblTelefone.Text = "Telefone:";
            // 
            // cbSexo
            // 
            cbSexo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSexo.Font = new Font("Segoe UI", 9.75F);
            cbSexo.FormattingEnabled = true;
            cbSexo.Items.AddRange(new object[] { "M", "F" });
            cbSexo.Location = new Point(726, 63);
            cbSexo.Margin = new Padding(3, 4, 3, 4);
            cbSexo.Name = "cbSexo";
            cbSexo.Size = new Size(68, 29);
            cbSexo.TabIndex = 2;
            // 
            // lblSexo
            // 
            lblSexo.AutoSize = true;
            lblSexo.Font = new Font("Segoe UI", 9.75F);
            lblSexo.Location = new Point(726, 36);
            lblSexo.Name = "lblSexo";
            lblSexo.Size = new Size(50, 23);
            lblSexo.TabIndex = 4;
            lblSexo.Text = "Sexo:";
            // 
            // dtpNascimento
            // 
            dtpNascimento.Font = new Font("Segoe UI", 9.75F);
            dtpNascimento.Format = DateTimePickerFormat.Short;
            dtpNascimento.Location = new Point(532, 63);
            dtpNascimento.Margin = new Padding(3, 4, 3, 4);
            dtpNascimento.Name = "dtpNascimento";
            dtpNascimento.Size = new Size(171, 29);
            dtpNascimento.TabIndex = 1;
            // 
            // lblNascimento
            // 
            lblNascimento.AutoSize = true;
            lblNascimento.Font = new Font("Segoe UI", 9.75F);
            lblNascimento.Location = new Point(532, 36);
            lblNascimento.Name = "lblNascimento";
            lblNascimento.Size = new Size(105, 23);
            lblNascimento.TabIndex = 2;
            lblNascimento.Text = "Nascimento:";
            // 
            // txtCpf
            // 
            txtCpf.Font = new Font("Segoe UI", 9.75F);
            txtCpf.Location = new Point(292, 63);
            txtCpf.Margin = new Padding(3, 4, 3, 4);
            txtCpf.Name = "txtCpf";
            txtCpf.Size = new Size(217, 29);
            txtCpf.TabIndex = 0;
            // 
            // lblCpf
            // 
            lblCpf.AutoSize = true;
            lblCpf.Font = new Font("Segoe UI", 9.75F);
            lblCpf.Location = new Point(292, 36);
            lblCpf.Name = "lblCpf";
            lblCpf.Size = new Size(43, 23);
            lblCpf.TabIndex = 0;
            lblCpf.Text = "CPF:";
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Font = new Font("Segoe UI", 9.75F);
            lblNome.Location = new Point(32, 36);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(61, 23);
            lblNome.TabIndex = 0;
            lblNome.Text = "Nome:";
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(btnLimpar);
            panelButtons.Controls.Add(btnDeletar);
            panelButtons.Controls.Add(btnSalvar);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(0, 187);
            panelButtons.Margin = new Padding(3, 4, 3, 4);
            panelButtons.Name = "panelButtons";
            panelButtons.Padding = new Padding(11, 13, 11, 13);
            panelButtons.Size = new Size(1007, 80);
            panelButtons.TabIndex = 9;
            // 
            // btnLimpar
            // 
            btnLimpar.BackColor = Color.LightSlateGray;
            btnLimpar.FlatAppearance.BorderSize = 0;
            btnLimpar.FlatStyle = FlatStyle.Flat;
            btnLimpar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLimpar.ForeColor = Color.White;
            btnLimpar.Location = new Point(320, 20);
            btnLimpar.Margin = new Padding(3, 4, 3, 4);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(114, 47);
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
            btnDeletar.Location = new Point(183, 20);
            btnDeletar.Margin = new Padding(3, 4, 3, 4);
            btnDeletar.Name = "btnDeletar";
            btnDeletar.Size = new Size(114, 47);
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
            btnSalvar.Location = new Point(46, 20);
            btnSalvar.Margin = new Padding(3, 4, 3, 4);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(114, 47);
            btnSalvar.TabIndex = 0;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = false;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // FormProfessor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1029, 800);
            Controls.Add(panelContent);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormProfessor";
            Text = "FormProfessor";
            Load += FormProfessor_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProfessores).EndInit();
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
        private System.Windows.Forms.ComboBox cbModalidade;
        private System.Windows.Forms.Label lblModalidade;
        private System.Windows.Forms.ComboBox cbAcademia;
        private System.Windows.Forms.Label lblAcademia;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.DataGridView dgvProfessores;
    }
}