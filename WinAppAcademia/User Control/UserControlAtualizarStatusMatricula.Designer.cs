using System.Windows.Forms;
using System.Xml.Linq;

namespace WinAppAcademia.UserControls
{
    partial class UserControlAtualizarStatusMatricula
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
            lblMatricula = new Label();
            cbMatricula = new ComboBox();
            lblStatus = new Label();
            cbStatus = new ComboBox();
            btnAtualizarStatus = new Button();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(0, 102, 184);
            lblTitulo.Location = new Point(20, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(295, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Atualizar Status da Matrícula";
            //
            // lblMatricula
            //
            lblMatricula.AutoSize = true;
            lblMatricula.Font = new Font("Segoe UI", 10F);
            lblMatricula.Location = new Point(25, 70);
            lblMatricula.Name = "lblMatricula";
            lblMatricula.Size = new Size(71, 19);
            lblMatricula.TabIndex = 1;
            lblMatricula.Text = "Matrícula:";
            //
            // cbMatricula
            //
            cbMatricula.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMatricula.Font = new Font("Segoe UI", 10F);
            cbMatricula.FormattingEnabled = true;
            cbMatricula.Location = new Point(25, 95);
            cbMatricula.Name = "cbMatricula";
            cbMatricula.Size = new Size(300, 25);
            cbMatricula.TabIndex = 0;
            //
            // lblStatus
            //
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 10F);
            lblStatus.Location = new Point(25, 135);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(49, 19);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "Status:";
            //
            // cbStatus
            //
            cbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStatus.Font = new Font("Segoe UI", 10F);
            cbStatus.FormattingEnabled = true;
            cbStatus.Items.AddRange(new object[] { "ativa", "cancelada" });
            cbStatus.Location = new Point(25, 160);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(150, 25);
            cbStatus.TabIndex = 1;
            //
            // btnAtualizarStatus
            //
            btnAtualizarStatus.BackColor = Color.FromArgb(0, 122, 204);
            btnAtualizarStatus.FlatAppearance.BorderSize = 0;
            btnAtualizarStatus.FlatStyle = FlatStyle.Flat;
            btnAtualizarStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAtualizarStatus.ForeColor = Color.White;
            btnAtualizarStatus.Location = new Point(25, 210);
            btnAtualizarStatus.Name = "btnAtualizarStatus";
            btnAtualizarStatus.Size = new Size(180, 40);
            btnAtualizarStatus.TabIndex = 2;
            btnAtualizarStatus.Text = "Atualizar Status";
            btnAtualizarStatus.UseVisualStyleBackColor = false;
            btnAtualizarStatus.Click += btnAtualizarStatus_Click;
            //
            // UserControlAtualizarStatusMatricula
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(btnAtualizarStatus);
            Controls.Add(cbStatus);
            Controls.Add(lblStatus);
            Controls.Add(cbMatricula);
            Controls.Add(lblMatricula);
            Controls.Add(lblTitulo);
            Name = "UserControlAtualizarStatusMatricula";
            Size = new Size(800, 400); // Tamanho padrão para UserControl
            Load += UserControlAtualizarStatusMatricula_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblMatricula;
        private ComboBox cbMatricula;
        private Label lblStatus;
        private ComboBox cbStatus;
        private Button btnAtualizarStatus;
    }
}