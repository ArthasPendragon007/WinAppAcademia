namespace WinAppAcademia.Views
{
    partial class FormAcademia
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
            dgvAcademias = new DataGridView();
            panelInput = new Panel();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtTelefone = new TextBox();
            lblTelefone = new Label();
            txtEndereco = new TextBox();
            lblEndereco = new Label();
            txtNome = new TextBox();
            lblNome = new Label();
            panelButtons = new Panel();
            btnLimpar = new Button();
            btnDeletar = new Button();
            btnSalvar = new Button();
            panelTop.SuspendLayout();
            panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAcademias).BeginInit();
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
            lblTituloForm.Size = new Size(276, 32);
            lblTituloForm.TabIndex = 0;
            lblTituloForm.Text = "Cadastro de Academias";
            //
            // panelContent
            //
            panelContent.Controls.Add(dgvAcademias);
            panelContent.Controls.Add(panelInput);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 60);
            panelContent.Name = "panelContent";
            panelContent.Padding = new Padding(10);
            panelContent.Size = new Size(900, 540);
            panelContent.TabIndex = 1;
            //
            // dgvAcademias
            //
            dgvAcademias.AllowUserToAddRows = false;
            dgvAcademias.AllowUserToDeleteRows = false;
            dgvAcademias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAcademias.BackgroundColor = Color.WhiteSmoke;
            dgvAcademias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAcademias.Dock = DockStyle.Fill;
            dgvAcademias.Location = new Point(10, 150); // Reduzida a altura do input para refletir menos campos
            dgvAcademias.MultiSelect = false;
            dgvAcademias.Name = "dgvAcademias";
            dgvAcademias.ReadOnly = true;
            dgvAcademias.RowHeadersVisible = false;
            dgvAcademias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAcademias.Size = new Size(880, 380); // Aumentada altura do DGV
            dgvAcademias.TabIndex = 1;
            dgvAcademias.CellClick += dgvAcademias_CellClick;
            //
            // panelInput
            //
            // Removidos lblStatus, cbStatus, dtpDataAbertura, lblDataAbertura, txtCnpj, lblCnpj
            panelInput.Controls.Add(txtEmail);
            panelInput.Controls.Add(lblEmail);
            panelInput.Controls.Add(txtTelefone);
            panelInput.Controls.Add(lblTelefone);
            panelInput.Controls.Add(txtEndereco);
            panelInput.Controls.Add(lblEndereco);
            panelInput.Controls.Add(txtNome);
            panelInput.Controls.Add(lblNome);
            panelInput.Controls.Add(panelButtons);
            panelInput.Dock = DockStyle.Top;
            panelInput.Location = new Point(10, 10);
            panelInput.Name = "panelInput";
            panelInput.Size = new Size(880, 140); // Altura ajustada para 3 linhas de input + botões
            panelInput.TabIndex = 0;
            //
            // txtEmail
            //
            txtEmail.Font = new Font("Segoe UI", 9.75F);
            txtEmail.Location = new Point(500, 50); // Posição ajustada
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(250, 25);
            txtEmail.TabIndex = 3; // Ajustado tabindex
            //
            // lblEmail
            //
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9.75F);
            lblEmail.Location = new Point(500, 30);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(42, 17);
            lblEmail.TabIndex = 8;
            lblEmail.Text = "Email:";
            //
            // txtTelefone
            //
            txtTelefone.Font = new Font("Segoe UI", 9.75F);
            txtTelefone.Location = new Point(370, 50); // Posição ajustada
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(110, 25);
            txtTelefone.TabIndex = 2; // Ajustado tabindex
            //
            // lblTelefone
            //
            lblTelefone.AutoSize = true;
            lblTelefone.Font = new Font("Segoe UI", 9.75F);
            lblTelefone.Location = new Point(370, 30);
            lblTelefone.Name = "lblTelefone";
            lblTelefone.Size = new Size(60, 17);
            lblTelefone.TabIndex = 6;
            lblTelefone.Text = "Telefone:";
            //
            // txtEndereco
            //
            txtEndereco.Font = new Font("Segoe UI", 9.75F);
            txtEndereco.Location = new Point(230, 50); // Posição ajustada
            txtEndereco.Name = "txtEndereco";
            txtEndereco.Size = new Size(120, 25);
            txtEndereco.TabIndex = 1; // Ajustado tabindex
            //
            // lblEndereco
            //
            lblEndereco.AutoSize = true;
            lblEndereco.Font = new Font("Segoe UI", 9.75F);
            lblEndereco.Location = new Point(230, 30);
            lblEndereco.Name = "lblEndereco";
            lblEndereco.Size = new Size(67, 17);
            lblEndereco.TabIndex = 4;
            lblEndereco.Text = "Endereço:";
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
            panelButtons.Location = new Point(0, 80); // Posição ajustada para ficar logo abaixo dos inputs
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
            // FormAcademia
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(900, 600);
            Controls.Add(panelContent);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormAcademia";
            Text = "FormAcademia";
            Load += FormAcademia_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAcademias).EndInit();
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
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.Label lblEndereco;
        private System.Windows.Forms.TextBox txtTelefone;
        private System.Windows.Forms.Label lblTelefone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.DataGridView dgvAcademias;
    }
}