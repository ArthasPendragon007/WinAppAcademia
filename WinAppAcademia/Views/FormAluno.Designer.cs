
namespace WinAppAcademia.Views
{
    partial class FormAluno
    {
        /// <summary>  
        /// Required designer variable.  
        /// </summary>  
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvAlunos;
        private System.Windows.Forms.TextBox  txtId;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtCpf;
        private System.Windows.Forms.DateTimePicker dtpNascimento;
        private System.Windows.Forms.DateTimePicker dtpMatricula;
        private System.Windows.Forms.ComboBox cbSexo;
        private System.Windows.Forms.TextBox txtTelefone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblCpf;
        private System.Windows.Forms.Label lblNascimento;
        private System.Windows.Forms.Label lblSexo;
        private System.Windows.Forms.Label lblTelefone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblStatus;

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
            dgvAlunos = new DataGridView();
            txtNome = new TextBox();
            txtCpf = new TextBox();
            dtpMatricula = new DateTimePicker();
            dtpNascimento = new DateTimePicker();
            cbSexo = new ComboBox();
            txtTelefone = new TextBox();
            txtEmail = new TextBox();
            cbStatus = new ComboBox();
            btnSalvar = new Button();
            btnLimpar = new Button();
            lblNome = new Label();
            lblCpf = new Label();
            lblNascimento = new Label();
            lblSexo = new Label();
            lblTelefone = new Label();
            lblEmail = new Label();
            lblStatus = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvAlunos).BeginInit();
            SuspendLayout();
            // 
            // dgvAlunos
            // 
            dgvAlunos.Location = new Point(20, 350);
            dgvAlunos.Name = "dgvAlunos";
            dgvAlunos.Size = new Size(740, 250);
            dgvAlunos.TabIndex = 16;
            dgvAlunos.CellClick += dgvAlunos_CellClick;
            dgvAlunos.CellContentClick += dgvAlunos_CellContentClick;
            
            // txtNome
            // 
            txtNome.Location = new Point(100, 20);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(100, 23);
            txtNome.TabIndex = 1;
            // 
            // txtCpf
            // 
            txtCpf.Location = new Point(100, 60);
            txtCpf.Name = "txtCpf";
            txtCpf.Size = new Size(100, 23);
            txtCpf.TabIndex = 3;
            // 
            // dtpMatricula
            // 
            dtpMatricula.Location = new Point(0, 0);
            dtpMatricula.Name = "dtpMatricula";
            dtpMatricula.Size = new Size(200, 23);
            dtpMatricula.TabIndex = 0;
            // 
            // dtpNascimento
            // 
            dtpNascimento.Format = DateTimePickerFormat.Short;
            dtpNascimento.Location = new Point(116, 100);
            dtpNascimento.Name = "dtpNascimento";
            dtpNascimento.Size = new Size(105, 23);
            dtpNascimento.TabIndex = 5;
            // 
            // cbSexo
            // 
            cbSexo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSexo.Items.AddRange(new object[] { "M", "F" });
            cbSexo.Location = new Point(100, 140);
            cbSexo.Name = "cbSexo";
            cbSexo.Size = new Size(121, 23);
            cbSexo.TabIndex = 7;
            cbSexo.SelectedIndexChanged += this.cbSexo_SelectedIndexChanged;
            // 
            // txtTelefone
            // 
            txtTelefone.Location = new Point(100, 180);
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(100, 23);
            txtTelefone.TabIndex = 9;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(100, 220);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(100, 23);
            txtEmail.TabIndex = 11;
            // 
            // cbStatus
            // 
            cbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStatus.Items.AddRange(new object[] { "ativo", "inativo" });
            cbStatus.Location = new Point(100, 260);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(121, 23);
            cbStatus.TabIndex = 13;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(100, 300);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(75, 23);
            btnSalvar.TabIndex = 14;
            btnSalvar.Text = "Salvar";
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnLimpar
            // 
            btnLimpar.Location = new Point(200, 300);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(75, 23);
            btnLimpar.TabIndex = 15;
            btnLimpar.Text = "Limpar";
            // 
            // lblNome
            // 
            lblNome.Location = new Point(20, 20);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(100, 23);
            lblNome.TabIndex = 0;
            lblNome.Text = "Nome:";
            // 
            // lblCpf
            // 
            lblCpf.Location = new Point(20, 60);
            lblCpf.Name = "lblCpf";
            lblCpf.Size = new Size(100, 23);
            lblCpf.TabIndex = 2;
            lblCpf.Text = "CPF:";
            // 
            // lblNascimento
            // 
            lblNascimento.Location = new Point(20, 100);
            lblNascimento.Name = "lblNascimento";
            lblNascimento.Size = new Size(100, 23);
            lblNascimento.TabIndex = 4;
            lblNascimento.Text = "Nascimento:";
            // 
            // lblSexo
            // 
            lblSexo.Location = new Point(20, 140);
            lblSexo.Name = "lblSexo";
            lblSexo.Size = new Size(100, 23);
            lblSexo.TabIndex = 6;
            lblSexo.Text = "Sexo:";
            // 
            // lblTelefone
            // 
            lblTelefone.Location = new Point(20, 180);
            lblTelefone.Name = "lblTelefone";
            lblTelefone.Size = new Size(100, 23);
            lblTelefone.TabIndex = 8;
            lblTelefone.Text = "Telefone:";
            // 
            // lblEmail
            // 
            lblEmail.Location = new Point(20, 220);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(100, 23);
            lblEmail.TabIndex = 10;
            lblEmail.Text = "Email:";
            // 
            // lblStatus
            // 
            lblStatus.Location = new Point(20, 260);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(100, 23);
            lblStatus.TabIndex = 12;
            lblStatus.Text = "Status:";
            // 
            // FormAluno
            // 
            ClientSize = new Size(800, 620);
            Controls.Add(lblNome);
            Controls.Add(txtNome);
            Controls.Add(lblCpf);
            Controls.Add(txtCpf);
            Controls.Add(lblNascimento);
            Controls.Add(dtpNascimento);
            Controls.Add(lblSexo);
            Controls.Add(cbSexo);
            Controls.Add(lblTelefone);
            Controls.Add(txtTelefone);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(lblStatus);
            Controls.Add(cbStatus);
            Controls.Add(btnSalvar);
            Controls.Add(btnLimpar);
            Controls.Add(dgvAlunos);
            Name = "FormAluno";
            Text = "Cadastro de Aluno";
            ((System.ComponentModel.ISupportInitialize)dgvAlunos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void dgvAlunos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }


        private void cbSexo_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}