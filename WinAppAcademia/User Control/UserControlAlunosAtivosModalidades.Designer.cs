using System.Windows.Forms;
using System.Xml.Linq;

namespace WinAppAcademia.UserControls
{
    partial class UserControlAlunosAtivosModalidades
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
            dgvAlunosAtivos = new DataGridView();
            btnAtualizar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvAlunosAtivos).BeginInit();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(0, 102, 184);
            lblTitulo.Location = new Point(20, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(328, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Alunos Ativos e Suas Modalidades";
            //
            // dgvAlunosAtivos
            //
            dgvAlunosAtivos.AllowUserToAddRows = false;
            dgvAlunosAtivos.AllowUserToDeleteRows = false;
            dgvAlunosAtivos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvAlunosAtivos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAlunosAtivos.BackgroundColor = Color.WhiteSmoke;
            dgvAlunosAtivos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAlunosAtivos.Location = new Point(20, 70);
            dgvAlunosAtivos.Name = "dgvAlunosAtivos";
            dgvAlunosAtivos.ReadOnly = true;
            dgvAlunosAtivos.RowHeadersVisible = false;
            dgvAlunosAtivos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAlunosAtivos.Size = new Size(760, 250);
            dgvAlunosAtivos.TabIndex = 1;
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
            // UserControlAlunosAtivosModalidades
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(btnAtualizar);
            Controls.Add(dgvAlunosAtivos);
            Controls.Add(lblTitulo);
            Name = "UserControlAlunosAtivosModalidades";
            Size = new Size(800, 400);
            Load += UserControlAlunosAtivosModalidades_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAlunosAtivos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private DataGridView dgvAlunosAtivos;
        private Button btnAtualizar;
    }
}