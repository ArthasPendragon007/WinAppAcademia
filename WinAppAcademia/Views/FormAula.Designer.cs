﻿namespace WinAppAcademia.Views
{
    partial class FormAula
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
            dgvAulas = new DataGridView();
            panelInput = new Panel();
            numCapacidadeMaxima = new NumericUpDown();
            lblCapacidadeMaxima = new Label();
            dtpHorarioFim = new DateTimePicker();
            lblHorarioFim = new Label();
            dtpHorarioInicio = new DateTimePicker();
            lblHorarioInicio = new Label();
            cbDiaSemana = new ComboBox();
            lblDiaSemana = new Label();
            cbProfessor = new ComboBox();
            lblProfessor = new Label();
            cbAcademia = new ComboBox();
            lblAcademia = new Label();
            cbModalidade = new ComboBox();
            lblModalidade = new Label();
            panelButtons = new Panel();
            btnLimpar = new Button();
            btnDeletar = new Button();
            btnSalvar = new Button();
            panelTop.SuspendLayout();
            panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAulas).BeginInit();
            panelInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCapacidadeMaxima).BeginInit();
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
            lblTituloForm.Size = new Size(271, 41);
            lblTituloForm.TabIndex = 0;
            lblTituloForm.Text = "Cadastro de Aulas";
            // 
            // panelContent
            // 
            panelContent.Controls.Add(dgvAulas);
            panelContent.Controls.Add(panelInput);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 80);
            panelContent.Margin = new Padding(3, 4, 3, 4);
            panelContent.Name = "panelContent";
            panelContent.Padding = new Padding(11, 13, 11, 13);
            panelContent.Size = new Size(1029, 720);
            panelContent.TabIndex = 1;
            // 
            // dgvAulas
            // 
            dgvAulas.AllowUserToAddRows = false;
            dgvAulas.AllowUserToDeleteRows = false;
            dgvAulas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAulas.BackgroundColor = Color.WhiteSmoke;
            dgvAulas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAulas.Dock = DockStyle.Fill;
            dgvAulas.Location = new Point(11, 280);
            dgvAulas.Margin = new Padding(3, 4, 3, 4);
            dgvAulas.MultiSelect = false;
            dgvAulas.Name = "dgvAulas";
            dgvAulas.ReadOnly = true;
            dgvAulas.RowHeadersVisible = false;
            dgvAulas.RowHeadersWidth = 51;
            dgvAulas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAulas.Size = new Size(1007, 427);
            dgvAulas.TabIndex = 1;
            dgvAulas.CellClick += dgvAulas_CellClick;
            // 
            // panelInput
            // 
            panelInput.Controls.Add(numCapacidadeMaxima);
            panelInput.Controls.Add(lblCapacidadeMaxima);
            panelInput.Controls.Add(dtpHorarioFim);
            panelInput.Controls.Add(lblHorarioFim);
            panelInput.Controls.Add(dtpHorarioInicio);
            panelInput.Controls.Add(lblHorarioInicio);
            panelInput.Controls.Add(cbDiaSemana);
            panelInput.Controls.Add(lblDiaSemana);
            panelInput.Controls.Add(cbProfessor);
            panelInput.Controls.Add(lblProfessor);
            panelInput.Controls.Add(cbAcademia);
            panelInput.Controls.Add(lblAcademia);
            panelInput.Controls.Add(cbModalidade);
            panelInput.Controls.Add(lblModalidade);
            panelInput.Controls.Add(panelButtons);
            panelInput.Dock = DockStyle.Top;
            panelInput.Location = new Point(11, 13);
            panelInput.Margin = new Padding(3, 4, 3, 4);
            panelInput.Name = "panelInput";
            panelInput.Size = new Size(1007, 267);
            panelInput.TabIndex = 0;
            // 
            // numCapacidadeMaxima
            // 
            numCapacidadeMaxima.Font = new Font("Segoe UI", 9.75F);
            numCapacidadeMaxima.Location = new Point(583, 129);
            numCapacidadeMaxima.Margin = new Padding(3, 4, 3, 4);
            numCapacidadeMaxima.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            numCapacidadeMaxima.Name = "numCapacidadeMaxima";
            numCapacidadeMaxima.Size = new Size(137, 29);
            numCapacidadeMaxima.TabIndex = 6;
            // 
            // lblCapacidadeMaxima
            // 
            lblCapacidadeMaxima.AutoSize = true;
            lblCapacidadeMaxima.Font = new Font("Segoe UI", 9.75F);
            lblCapacidadeMaxima.Location = new Point(583, 103);
            lblCapacidadeMaxima.Name = "lblCapacidadeMaxima";
            lblCapacidadeMaxima.Size = new Size(168, 23);
            lblCapacidadeMaxima.TabIndex = 12;
            lblCapacidadeMaxima.Text = "Capacidade Máxima:";
            // 
            // dtpHorarioFim
            // 
            dtpHorarioFim.CustomFormat = "HH:mm";
            dtpHorarioFim.Font = new Font("Segoe UI", 9.75F);
            dtpHorarioFim.Format = DateTimePickerFormat.Custom;
            dtpHorarioFim.Location = new Point(398, 129);
            dtpHorarioFim.Margin = new Padding(3, 4, 3, 4);
            dtpHorarioFim.Name = "dtpHorarioFim";
            dtpHorarioFim.ShowUpDown = true;
            dtpHorarioFim.Size = new Size(114, 29);
            dtpHorarioFim.TabIndex = 5;
            // 
            // lblHorarioFim
            // 
            lblHorarioFim.AutoSize = true;
            lblHorarioFim.Font = new Font("Segoe UI", 9.75F);
            lblHorarioFim.Location = new Point(398, 103);
            lblHorarioFim.Name = "lblHorarioFim";
            lblHorarioFim.Size = new Size(103, 23);
            lblHorarioFim.TabIndex = 10;
            lblHorarioFim.Text = "Horário Fim:";
            // 
            // dtpHorarioInicio
            // 
            dtpHorarioInicio.CustomFormat = "HH:mm";
            dtpHorarioInicio.Font = new Font("Segoe UI", 9.75F);
            dtpHorarioInicio.Format = DateTimePickerFormat.Custom;
            dtpHorarioInicio.Location = new Point(261, 129);
            dtpHorarioInicio.Margin = new Padding(3, 4, 3, 4);
            dtpHorarioInicio.Name = "dtpHorarioInicio";
            dtpHorarioInicio.ShowUpDown = true;
            dtpHorarioInicio.Size = new Size(114, 29);
            dtpHorarioInicio.TabIndex = 4;
            // 
            // lblHorarioInicio
            // 
            lblHorarioInicio.AutoSize = true;
            lblHorarioInicio.Font = new Font("Segoe UI", 9.75F);
            lblHorarioInicio.Location = new Point(261, 103);
            lblHorarioInicio.Name = "lblHorarioInicio";
            lblHorarioInicio.Size = new Size(117, 23);
            lblHorarioInicio.TabIndex = 8;
            lblHorarioInicio.Text = "Horário Início:";
            // 
            // cbDiaSemana
            // 
            cbDiaSemana.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDiaSemana.Font = new Font("Segoe UI", 9.75F);
            cbDiaSemana.FormattingEnabled = true;
            cbDiaSemana.Items.AddRange(new object[] { "Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sábado", "Domingo" });
            cbDiaSemana.Location = new Point(23, 129);
            cbDiaSemana.Margin = new Padding(3, 4, 3, 4);
            cbDiaSemana.Name = "cbDiaSemana";
            cbDiaSemana.Size = new Size(171, 29);
            cbDiaSemana.TabIndex = 3;
            // 
            // lblDiaSemana
            // 
            lblDiaSemana.AutoSize = true;
            lblDiaSemana.Font = new Font("Segoe UI", 9.75F);
            lblDiaSemana.Location = new Point(23, 103);
            lblDiaSemana.Name = "lblDiaSemana";
            lblDiaSemana.Size = new Size(129, 23);
            lblDiaSemana.TabIndex = 6;
            lblDiaSemana.Text = "Dia da Semana:";
            // 
            // cbProfessor
            // 
            cbProfessor.DropDownStyle = ComboBoxStyle.DropDownList;
            cbProfessor.Font = new Font("Segoe UI", 9.75F);
            cbProfessor.FormattingEnabled = true;
            cbProfessor.Location = new Point(549, 67);
            cbProfessor.Margin = new Padding(3, 4, 3, 4);
            cbProfessor.Name = "cbProfessor";
            cbProfessor.Size = new Size(228, 29);
            cbProfessor.TabIndex = 2;
            // 
            // lblProfessor
            // 
            lblProfessor.AutoSize = true;
            lblProfessor.Font = new Font("Segoe UI", 9.75F);
            lblProfessor.Location = new Point(549, 40);
            lblProfessor.Name = "lblProfessor";
            lblProfessor.Size = new Size(84, 23);
            lblProfessor.TabIndex = 4;
            lblProfessor.Text = "Professor:";
            // 
            // cbAcademia
            // 
            cbAcademia.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAcademia.Font = new Font("Segoe UI", 9.75F);
            cbAcademia.FormattingEnabled = true;
            cbAcademia.Location = new Point(286, 67);
            cbAcademia.Margin = new Padding(3, 4, 3, 4);
            cbAcademia.Name = "cbAcademia";
            cbAcademia.Size = new Size(228, 29);
            cbAcademia.TabIndex = 1;
            // 
            // lblAcademia
            // 
            lblAcademia.AutoSize = true;
            lblAcademia.Font = new Font("Segoe UI", 9.75F);
            lblAcademia.Location = new Point(286, 40);
            lblAcademia.Name = "lblAcademia";
            lblAcademia.Size = new Size(89, 23);
            lblAcademia.TabIndex = 2;
            lblAcademia.Text = "Academia:";
            // 
            // cbModalidade
            // 
            cbModalidade.DropDownStyle = ComboBoxStyle.DropDownList;
            cbModalidade.Font = new Font("Segoe UI", 9.75F);
            cbModalidade.FormattingEnabled = true;
            cbModalidade.Location = new Point(23, 67);
            cbModalidade.Margin = new Padding(3, 4, 3, 4);
            cbModalidade.Name = "cbModalidade";
            cbModalidade.Size = new Size(228, 29);
            cbModalidade.TabIndex = 0;
            // 
            // lblModalidade
            // 
            lblModalidade.AutoSize = true;
            lblModalidade.Font = new Font("Segoe UI", 9.75F);
            lblModalidade.Location = new Point(23, 40);
            lblModalidade.Name = "lblModalidade";
            lblModalidade.Size = new Size(104, 23);
            lblModalidade.TabIndex = 0;
            lblModalidade.Text = "Modalidade:";
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
            panelButtons.TabIndex = 13;
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
            // FormAula
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1029, 800);
            Controls.Add(panelContent);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormAula";
            Text = "FormAula";
            Load += FormAula_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAulas).EndInit();
            panelInput.ResumeLayout(false);
            panelInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCapacidadeMaxima).EndInit();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        // Declare os controles aqui
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTituloForm;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.ComboBox cbModalidade;
        private System.Windows.Forms.Label lblModalidade;
        private System.Windows.Forms.ComboBox cbAcademia;
        private System.Windows.Forms.Label lblAcademia;
        private System.Windows.Forms.ComboBox cbProfessor;
        private System.Windows.Forms.Label lblProfessor;
        private System.Windows.Forms.ComboBox cbDiaSemana;
        private System.Windows.Forms.Label lblDiaSemana;
        private System.Windows.Forms.DateTimePicker dtpHorarioInicio;
        private System.Windows.Forms.Label lblHorarioInicio;
        private System.Windows.Forms.DateTimePicker dtpHorarioFim;
        private System.Windows.Forms.Label lblHorarioFim;
        private System.Windows.Forms.NumericUpDown numCapacidadeMaxima;
        private System.Windows.Forms.Label lblCapacidadeMaxima;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.DataGridView dgvAulas;
    }
}