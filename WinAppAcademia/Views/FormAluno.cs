using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinAppAcademia.Controllers;
using WinAppAcademia.Models;

namespace WinAppAcademia.Views
{
    public partial class FormAluno : Form
    {
        private int? alunoSelecionadoId = null;        // Controller to handle business logic and data operations
        private AlunoController _controller;

        public FormAluno()
        {
            _controller = new AlunoController();
            InitializeComponent();
            CarregarDados();
        }

        private void CarregarDados()
        {
            var lista = _controller.BuscarTodos();
            foreach (var a in lista)
            {
                dgvAlunos.Rows.Add(a.Id, a.Nome, a.CPF, a.DataNascimento.ToShortDateString(), a.Sexo,
                                   a.Telefone, a.Email, a.DataMatricula.ToShortDateString(), a.Status);
            }
            dgvAlunos.Columns.Clear();
            dgvAlunos.Columns.Add("Id", "ID");
            dgvAlunos.Columns.Add("Nome", "Nome");
            dgvAlunos.Columns.Add("CPF", "CPF");
            dgvAlunos.Columns.Add("Nascimento", "Data Nasc.");
            dgvAlunos.Columns.Add("Sexo", "Sexo");
            dgvAlunos.Columns.Add("Telefone", "Telefone");
            dgvAlunos.Columns.Add("Email", "Email");
            dgvAlunos.Columns.Add("Matricula", "Data Matrícula");
            dgvAlunos.Columns.Add("Status", "Status");
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var aluno = new Aluno
            {
                Id = alunoSelecionadoId ?? 0,
                Nome = txtNome.Text,
                CPF = txtCpf.Text,
                DataNascimento = dtpNascimento.Value,
                Sexo = cbSexo.Text,
                Telefone = txtTelefone.Text,
                Email = txtEmail.Text,
                DataMatricula = DateTime.Now,
                Status = cbStatus.Text
            };


            _controller.Salvar(aluno);
            LimparCampos();
            CarregarDados();
        }

        private void dgvAlunos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvAlunos.Rows[e.RowIndex];
                alunoSelecionadoId = Convert.ToInt32(row.Cells[0].Value);


                txtNome.Text = dgvAlunos.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtCpf.Text = dgvAlunos.Rows[e.RowIndex].Cells[2].Value.ToString();
                dtpNascimento.Value = DateTime.Parse(dgvAlunos.Rows[e.RowIndex].Cells[3].Value.ToString());
                cbSexo.Text = dgvAlunos.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtTelefone.Text = dgvAlunos.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtEmail.Text = dgvAlunos.Rows[e.RowIndex]
                                         .Cells[6].Value
                                         .ToString();
                dtpMatricula.Value = dgvAlunos.Rows[e.RowIndex].Cells[7].Value != null
                       ? DateTime.Parse(dgvAlunos.Rows[index: e.RowIndex].Cells[7].Value.ToString())
                       : DateTime.Now; // Default value if null);
                cbStatus.Text = dgvAlunos.Rows[e.RowIndex].Cells[8].Value.ToString();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (alunoSelecionadoId.HasValue)
            {
                _controller.Remover(alunoSelecionadoId.Value);
                LimparCampos();
                CarregarDados();
            }
        }

        private void LimparCampos()
        {
            alunoSelecionadoId = null;
            txtNome.Clear();
            txtCpf.Clear();
            txtTelefone.Clear();
            txtEmail.Clear();
            cbSexo.SelectedIndex = -1;
            cbStatus.SelectedIndex = -1;
            dtpNascimento.Value = DateTime.Now;
            dtpMatricula.Value = DateTime.Now;
        }
        private void dgvAlunos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }


        private void cbSexo_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {

        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void lblNascimento_Click(object sender, EventArgs e)
        {

        }
    }
}
  
