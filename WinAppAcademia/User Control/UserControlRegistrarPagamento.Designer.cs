using System.Windows.Forms;
using System.Xml.Linq;

namespace WinAppAcademia.UserControls
{
    partial class UserControlRegistrarPagamento
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitulo = new Label();
            lblAluno = new Label();
            cbAluno = new ComboBox();
            lblValor = new Label();
            txtValor = new TextBox();
            lblDataPagamento = new Label();
            dtpDataPagamento = new DateTimePicker();
            btnRegistrarPagamento = new Button();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(0, 102, 184);
            lblTitulo.Location = new Point(20, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(224, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Registrar Pagamento";
            //
            // lblAluno
            //
            lblAluno.AutoSize = true;
            lblAluno.Font = new Font("Segoe UI", 10F);
            lblAluno.Location = new Point(25, 70);
            lblAluno.Name = "lblAluno";
            lblAluno.Size = new Size(49, 19);
            lblAluno.TabIndex = 1;
            lblAluno.Text = "Aluno:";
            //
            // cbAluno
            //
            cbAluno.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAluno.Font = new Font("Segoe UI", 10F);
            cbAluno.FormattingEnabled = true;
            cbAluno.Location = new Point(25, 95);
            cbAluno.Name = "cbAluno";
            cbAluno.Size = new Size(250, 25);
            cbAluno.TabIndex = 0;
            //
            // lblValor
            //
            lblValor.AutoSize = true;
            lblValor.Font = new Font("Segoe UI", 10F);
            lblValor.Location = new Point(25, 135);
            lblValor.Name = "lblValor";
            lblValor.Size = new Size(44, 19);
            lblValor.TabIndex = 3;
            lblValor.Text = "Valor:";
            //
            // txtValor
            //
            txtValor.Font = new Font("Segoe UI", 10F);
            txtValor.Location = new Point(25, 160);
            txtValor.Name = "txtValor";
            txtValor.Size = new Size(150, 25);
            txtValor.TabIndex = 1;
            //
            // lblDataPagamento
            //
            lblDataPagamento.AutoSize = true;
            lblDataPagamento.Font = new Font("Segoe UI", 10F);
            lblDataPagamento.Location = new Point(25, 200);
            lblDataPagamento.Name = "lblDataPagamento";
            lblDataPagamento.Size = new Size(125, 19);
            lblDataPagamento.TabIndex = 5;
            lblDataPagamento.Text = "Data Pagamento:";
            //
            // dtpDataPagamento
            //
            dtpDataPagamento.Font = new Font("Segoe UI", 10F);
            dtpDataPagamento.Format = DateTimePickerFormat.Short;
            dtpDataPagamento.Location = new Point(25, 225);
            dtpDataPagamento.Name = "dtpDataPagamento";
            dtpDataPagamento.Size = new Size(150, 25);
            dtpDataPagamento.TabIndex = 2;
            //
            // btnRegistrarPagamento
            //
            btnRegistrarPagamento.BackColor = Color.FromArgb(0, 122, 204);
            btnRegistrarPagamento.FlatAppearance.BorderSize = 0;
            btnRegistrarPagamento.FlatStyle = FlatStyle.Flat;
            btnRegistrarPagamento.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRegistrarPagamento.ForeColor = Color.White;
            btnRegistrarPagamento.Location = new Point(25, 280);
            btnRegistrarPagamento.Name = "btnRegistrarPagamento";
            btnRegistrarPagamento.Size = new Size(180, 40);
            btnRegistrarPagamento.TabIndex = 3;
            btnRegistrarPagamento.Text = "Registrar Pagamento";
            btnRegistrarPagamento.UseVisualStyleBackColor = false;
            btnRegistrarPagamento.Click += btnRegistrarPagamento_Click;
            //
            // UserControlRegistrarPagamento
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(btnRegistrarPagamento);
            Controls.Add(dtpDataPagamento);
            Controls.Add(lblDataPagamento);
            Controls.Add(txtValor);
            Controls.Add(lblValor);
            Controls.Add(cbAluno);
            Controls.Add(lblAluno);
            Controls.Add(lblTitulo);
            Name = "UserControlRegistrarPagamento";
            Size = new Size(800, 400); // Tamanho padrão para UserControl
            Load += UserControlRegistrarPagamento_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblAluno;
        private ComboBox cbAluno;
        private Label lblValor;
        private TextBox txtValor;
        private Label lblDataPagamento;
        private DateTimePicker dtpDataPagamento;
        private Button btnRegistrarPagamento;
    }
}