namespace WinAppAcademia.Views
{
    partial class FormEquipamento
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
            dgvEquipamentos = new DataGridView();
            panelInput = new Panel();
            cbAcademia = new ComboBox();
            lblAcademia = new Label();
            cbEstado = new ComboBox();
            lblEstado = new Label();
            dtpDataAquisicao = new DateTimePicker();
            lblDataAquisicao = new Label();
            txtDescricao = new TextBox();
            lblDescricao = new Label();
            txtNome = new TextBox();
            lblNome = new Label();
            panelButtons = new Panel();
            btnLimpar = new Button();
            btnDeletar = new Button();
            btnSalvar = new Button();
            panelTop.SuspendLayout();
            panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEquipamentos).BeginInit();
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
            lblTituloForm.Size = new Size(320, 32);
            lblTituloForm.TabIndex = 0;
            lblTituloForm.Text = "Cadastro de Equipamentos";
            // 
            // panelContent
            // 
            panelContent.Controls.Add(dgvEquipamentos);
            panelContent.Controls.Add(panelInput);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 60);
            panelContent.Name = "panelContent";
            panelContent.Padding = new Padding(10);
            panelContent.Size = new Size(900, 540);
            panelContent.TabIndex = 1;
            // 
            // dgvEquipamentos
            // 
            dgvEquipamentos.AllowUserToAddRows = false;
            dgvEquipamentos.AllowUserToDeleteRows = false;
            dgvEquipamentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEquipamentos.BackgroundColor = Color.WhiteSmoke;
            dgvEquipamentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEquipamentos.Dock = DockStyle.Fill;
            dgvEquipamentos.Location = new Point(10, 210);
            dgvEquipamentos.MultiSelect = false;
            dgvEquipamentos.Name = "dgvEquipamentos";
            dgvEquipamentos.ReadOnly = true;
            dgvEquipamentos.RowHeadersVisible = false;
            dgvEquipamentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEquipamentos.Size = new Size(880, 320);
            dgvEquipamentos.TabIndex = 1;
            dgvEquipamentos.CellClick += dgvEquipamentos_CellClick;
            // 
            // panelInput
            // 
            panelInput.Controls.Add(cbAcademia);
            panelInput.Controls.Add(lblAcademia);
            panelInput.Controls.Add(cbEstado);
            panelInput.Controls.Add(lblEstado);
            panelInput.Controls.Add(dtpDataAquisicao);
            panelInput.Controls.Add(lblDataAquisicao);
            panelInput.Controls.Add(txtDescricao);
            panelInput.Controls.Add(lblDescricao);
            panelInput.Controls.Add(txtNome);
            panelInput.Controls.Add(lblNome);
            panelInput.Controls.Add(panelButtons);
            panelInput.Dock = DockStyle.Top;
            panelInput.Location = new Point(10, 10);
            panelInput.Name = "panelInput";
            panelInput.Size = new Size(880, 200);
            panelInput.TabIndex = 0;
            // 
            // cbAcademia
            // 
            cbAcademia.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAcademia.Font = new Font("Segoe UI", 9.75F);
            cbAcademia.FormattingEnabled = true;
            cbAcademia.Location = new Point(550, 50);
            cbAcademia.Name = "cbAcademia";
            cbAcademia.Size = new Size(200, 25);
            cbAcademia.TabIndex = 4;
            // 
            // lblAcademia
            // 
            lblAcademia.AutoSize = true;
            lblAcademia.Font = new Font("Segoe UI", 9.75F);
            lblAcademia.Location = new Point(550, 30);
            lblAcademia.Name = "lblAcademia";
            lblAcademia.Size = new Size(68, 17);
            lblAcademia.TabIndex = 8;
            lblAcademia.Text = "Academia:";
            // 
            // cbEstado
            // 
            cbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEstado.Font = new Font("Segoe UI", 9.75F);
            cbEstado.FormattingEnabled = true;
            cbEstado.Items.AddRange(new object[] { "novo", "usado", "manutenção", "danificado" });
            cbEstado.Location = new Point(400, 50);
            cbEstado.Name = "cbEstado";
            cbEstado.Size = new Size(120, 25);
            cbEstado.TabIndex = 3;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Segoe UI", 9.75F);
            lblEstado.Location = new Point(400, 30);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(51, 17);
            lblEstado.TabIndex = 6;
            lblEstado.Text = "Estado:";
            // 
            // dtpDataAquisicao
            // 
            dtpDataAquisicao.Font = new Font("Segoe UI", 9.75F);
            dtpDataAquisicao.Format = DateTimePickerFormat.Short;
            dtpDataAquisicao.Location = new Point(230, 50);
            dtpDataAquisicao.Name = "dtpDataAquisicao";
            dtpDataAquisicao.Size = new Size(150, 25);
            dtpDataAquisicao.TabIndex = 2;
            // 
            // lblDataAquisicao
            // 
            lblDataAquisicao.AutoSize = true;
            lblDataAquisicao.Font = new Font("Segoe UI", 9.75F);
            lblDataAquisicao.Location = new Point(230, 30);
            lblDataAquisicao.Name = "lblDataAquisicao";
            lblDataAquisicao.Size = new Size(98, 17);
            lblDataAquisicao.TabIndex = 4;
            lblDataAquisicao.Text = "Data Aquisição:";
            // 
            // txtDescricao
            // 
            txtDescricao.Font = new Font("Segoe UI", 9.75F);
            txtDescricao.Location = new Point(20, 98);
            txtDescricao.Multiline = true;
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(730, 40);
            txtDescricao.TabIndex = 1;
            // 
            // lblDescricao
            // 
            lblDescricao.AutoSize = true;
            lblDescricao.Font = new Font("Segoe UI", 9.75F);
            lblDescricao.Location = new Point(20, 78);
            lblDescricao.Name = "lblDescricao";
            lblDescricao.Size = new Size(68, 17);
            lblDescricao.TabIndex = 2;
            lblDescricao.Text = "Descrição:";
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
            // FormEquipamento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(900, 600);
            Controls.Add(panelContent);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormEquipamento";
            Text = "FormEquipamento";
            Load += FormEquipamento_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEquipamentos).EndInit();
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
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.DateTimePicker dtpDataAquisicao;
        private System.Windows.Forms.Label lblDataAquisicao;
        private System.Windows.Forms.ComboBox cbEstado;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cbAcademia;
        private System.Windows.Forms.Label lblAcademia;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.DataGridView dgvEquipamentos;
    }
}