namespace WinAppAcademia.Views
{
    partial class FormModalidade
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
            dgvModalidades = new DataGridView();
            panelInput = new Panel();
            txtValorMensalidade = new TextBox();
            lblValorMensalidade = new Label();
            txtDescricao = new TextBox();
            lblDescricao = new Label();
            txtNomeModalidade = new TextBox();
            lblNomeModalidade = new Label();
            panelButtons = new Panel();
            btnLimpar = new Button();
            btnDeletar = new Button();
            btnSalvar = new Button();
            panelTop.SuspendLayout();
            panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvModalidades).BeginInit();
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
            lblTituloForm.Size = new Size(304, 32);
            lblTituloForm.TabIndex = 0;
            lblTituloForm.Text = "Cadastro de Modalidades";
            // 
            // panelContent
            // 
            panelContent.Controls.Add(dgvModalidades);
            panelContent.Controls.Add(panelInput);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 60);
            panelContent.Name = "panelContent";
            panelContent.Padding = new Padding(10);
            panelContent.Size = new Size(900, 540);
            panelContent.TabIndex = 1;
            // 
            // dgvModalidades
            // 
            dgvModalidades.AllowUserToAddRows = false;
            dgvModalidades.AllowUserToDeleteRows = false;
            dgvModalidades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvModalidades.BackgroundColor = Color.WhiteSmoke;
            dgvModalidades.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvModalidades.Dock = DockStyle.Fill;
            dgvModalidades.Location = new Point(10, 200);
            dgvModalidades.MultiSelect = false;
            dgvModalidades.Name = "dgvModalidades";
            dgvModalidades.ReadOnly = true;
            dgvModalidades.RowHeadersVisible = false;
            dgvModalidades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvModalidades.Size = new Size(880, 330);
            dgvModalidades.TabIndex = 1;
            dgvModalidades.CellClick += dgvModalidades_CellClick;
            // 
            // panelInput
            // 
            panelInput.Controls.Add(txtValorMensalidade);
            panelInput.Controls.Add(lblValorMensalidade);
            panelInput.Controls.Add(txtDescricao);
            panelInput.Controls.Add(lblDescricao);
            panelInput.Controls.Add(txtNomeModalidade);
            panelInput.Controls.Add(lblNomeModalidade);
            panelInput.Controls.Add(panelButtons);
            panelInput.Dock = DockStyle.Top;
            panelInput.Location = new Point(10, 10);
            panelInput.Name = "panelInput";
            panelInput.Size = new Size(880, 190);
            panelInput.TabIndex = 0;
            // 
            // txtValorMensalidade
            // 
            txtValorMensalidade.Font = new Font("Segoe UI", 9.75F);
            txtValorMensalidade.Location = new Point(20, 31);
            txtValorMensalidade.Name = "txtValorMensalidade";
            txtValorMensalidade.Size = new Size(150, 25);
            txtValorMensalidade.TabIndex = 1;
            // 
            // lblValorMensalidade
            // 
            lblValorMensalidade.AutoSize = true;
            lblValorMensalidade.Font = new Font("Segoe UI", 9.75F);
            lblValorMensalidade.Location = new Point(20, 11);
            lblValorMensalidade.Name = "lblValorMensalidade";
            lblValorMensalidade.Size = new Size(120, 17);
            lblValorMensalidade.TabIndex = 2;
            lblValorMensalidade.Text = "Valor Mensalidade:";
            // 
            // txtDescricao
            // 
            txtDescricao.Font = new Font("Segoe UI", 9.75F);
            txtDescricao.Location = new Point(20, 84);
            txtDescricao.Multiline = true;
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(730, 40);
            txtDescricao.TabIndex = 2;
            // 
            // lblDescricao
            // 
            lblDescricao.AutoSize = true;
            lblDescricao.Font = new Font("Segoe UI", 9.75F);
            lblDescricao.Location = new Point(20, 64);
            lblDescricao.Name = "lblDescricao";
            lblDescricao.Size = new Size(68, 17);
            lblDescricao.TabIndex = 4;
            lblDescricao.Text = "Descrição:";
            // 
            // txtNomeModalidade
            // 
            txtNomeModalidade.Font = new Font("Segoe UI", 9.75F);
            txtNomeModalidade.Location = new Point(200, 31);
            txtNomeModalidade.Name = "txtNomeModalidade";
            txtNomeModalidade.Size = new Size(300, 25);
            txtNomeModalidade.TabIndex = 0;
            // 
            // lblNomeModalidade
            // 
            lblNomeModalidade.AutoSize = true;
            lblNomeModalidade.Font = new Font("Segoe UI", 9.75F);
            lblNomeModalidade.Location = new Point(200, 11);
            lblNomeModalidade.Name = "lblNomeModalidade";
            lblNomeModalidade.Size = new Size(107, 17);
            lblNomeModalidade.TabIndex = 0;
            lblNomeModalidade.Text = "Nome Modalide:";
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(btnLimpar);
            panelButtons.Controls.Add(btnDeletar);
            panelButtons.Controls.Add(btnSalvar);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(0, 130);
            panelButtons.Name = "panelButtons";
            panelButtons.Padding = new Padding(10);
            panelButtons.Size = new Size(880, 60);
            panelButtons.TabIndex = 5;
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
            // FormModalidade
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(900, 600);
            Controls.Add(panelContent);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormModalidade";
            Text = "FormModalidade";
            Load += FormModalidade_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvModalidades).EndInit();
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
        private System.Windows.Forms.TextBox txtNomeModalidade;
        private System.Windows.Forms.Label lblNomeModalidade;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtValorMensalidade;
        private System.Windows.Forms.Label lblValorMensalidade;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.DataGridView dgvModalidades;
    }
}