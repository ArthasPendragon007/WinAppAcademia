using System.Windows.Forms;
using System.Xml.Linq;

namespace WinAppAcademia.UserControls
{
    partial class UserControlFrequenciaPorAula
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
            dgvFrequenciaAula = new DataGridView();
            btnAtualizar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvFrequenciaAula).BeginInit();
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
            lblTitulo.Text = "Frequência de Alunos por Aula";
            //
            // dgvFrequenciaAula
            //
            dgvFrequenciaAula.AllowUserToAddRows = false;
            dgvFrequenciaAula.AllowUserToDeleteRows = false;
            dgvFrequenciaAula.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvFrequenciaAula.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFrequenciaAula.BackgroundColor = Color.WhiteSmoke;
            dgvFrequenciaAula.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFrequenciaAula.Location = new Point(20, 70);
            dgvFrequenciaAula.Name = "dgvFrequenciaAula";
            dgvFrequenciaAula.ReadOnly = true;
            dgvFrequenciaAula.RowHeadersVisible = false;
            dgvFrequenciaAula.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFrequenciaAula.Size = new Size(760, 250);
            dgvFrequenciaAula.TabIndex = 1;
            //
            // btnAtualizar
            //
            btnAtualizar.BackColor = Color.FromArgb(0, 122, 204);
            btnAtualizar.FlatAppearance.BorderSize = 0;
            btnAtualizar.FlatStyle = FlatStyle.Flat;
            btnAtualizar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAtualizar.ForeColor = Color.White;
            btnAtualizar.Location = new Point(20, 335);
            btnAtualizar.Name = "btnAtualizar";
            btnAtualizar.Size = new Size(150, 40);
            btnAtualizar.TabIndex = 2;
            btnAtualizar.Text = "Atualizar Dados";
            btnAtualizar.UseVisualStyleBackColor = false;
            btnAtualizar.Click += btnAtualizar_Click;
            //
            // UserControlFrequenciaPorAula
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(btnAtualizar);
            Controls.Add(dgvFrequenciaAula);
            Controls.Add(lblTitulo);
            Name = "UserControlFrequenciaPorAula";
            Size = new Size(800, 400);
            Load += UserControlFrequenciaPorAula_Load;
            ((System.ComponentModel.ISupportInitialize)dgvFrequenciaAula).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private DataGridView dgvFrequenciaAula;
        private Button btnAtualizar;
    }
}