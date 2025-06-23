using System.Windows.Forms;
using System.Xml.Linq;

namespace WinAppAcademia.UserControls
{
    partial class UserControlTotalPagoAluno
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
            btnCalcularTotal = new Button();
            lblTotalPago = new Label();
            txtTotalPago = new TextBox();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(0, 102, 184);
            lblTitulo.Location = new Point(20, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(250, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Calcular Total Pago Aluno";
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
            // btnCalcularTotal
            //
            btnCalcularTotal.BackColor = Color.FromArgb(0, 122, 204);
            btnCalcularTotal.FlatAppearance.BorderSize = 0;
            btnCalcularTotal.FlatStyle = FlatStyle.Flat;
            btnCalcularTotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCalcularTotal.ForeColor = Color.White;
            btnCalcularTotal.Location = new Point(25, 140);
            btnCalcularTotal.Name = "btnCalcularTotal";
            btnCalcularTotal.Size = new Size(150, 40);
            btnCalcularTotal.TabIndex = 1;
            btnCalcularTotal.Text = "Calcular Total";
            btnCalcularTotal.UseVisualStyleBackColor = false;
            btnCalcularTotal.Click += btnCalcularTotal_Click;
            //
            // lblTotalPago
            //
            lblTotalPago.AutoSize = true;
            lblTotalPago.Font = new Font("Segoe UI", 10F);
            lblTotalPago.Location = new Point(25, 200);
            lblTotalPago.Name = "lblTotalPago";
            lblTotalPago.Size = new Size(76, 19);
            lblTotalPago.TabIndex = 4;
            lblTotalPago.Text = "Total Pago:";
            //
            // txtTotalPago
            //
            txtTotalPago.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txtTotalPago.Location = new Point(25, 225);
            txtTotalPago.Name = "txtTotalPago";
            txtTotalPago.ReadOnly = true;
            txtTotalPago.Size = new Size(150, 29);
            txtTotalPago.TabIndex = 5;
            txtTotalPago.TextAlign = HorizontalAlignment.Right;
            //
            // UserControlTotalPagoAluno
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(txtTotalPago);
            Controls.Add(lblTotalPago);
            Controls.Add(btnCalcularTotal);
            Controls.Add(cbAluno);
            Controls.Add(lblAluno);
            Controls.Add(lblTitulo);
            Name = "UserControlTotalPagoAluno";
            Size = new Size(800, 400); // Tamanho padrão para UserControl
            Load += UserControlTotalPagoAluno_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblAluno;
        private ComboBox cbAluno;
        private Button btnCalcularTotal;
        private Label lblTotalPago;
        private TextBox txtTotalPago;
    }
}