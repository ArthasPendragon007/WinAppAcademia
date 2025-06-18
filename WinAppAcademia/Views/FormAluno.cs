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
        private AlunoController _controller;

        public FormAluno()
        {
            _controller = new AlunoController();
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
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var aluno = new Aluno
            {
                Id = 0, // Default value, will be set if editing an existing record
                Nome = txtNome.Text,
                CPF = txtCpf.Text,
                DataNascimento = dtpNascimento.Value,
                Sexo = cbSexo.Text,
                Telefone = txtTelefone.Text,
                Email = txtEmail.Text,
                DataMatricula = DateTime.Now,
                Status = cbStatus.Text
            };

            if (int.TryParse(txtId.Text, out int id))
                aluno.Id = id;

            _controller.Salvar(aluno);
            LimparCampos();
            CarregarDados();
        }

        private void dgvAlunos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtId.Text = dgvAlunos.Rows[e.RowIndex].Cells[0].Value.ToString();
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
            if (int.TryParse(txtId.Text, out int id))
            {
                _controller.Remover(id);
                LimparCampos();
                CarregarDados();
            }
        }

        private void LimparCampos()
        {
            txtId.Clear();
            txtNome.Clear();
            txtCpf.Clear();
            txtTelefone.Clear();
            txtEmail.Clear();
            cbSexo.SelectedIndex = -1;
            cbStatus.SelectedIndex = -1;
            dtpNascimento.Value = DateTime.Now;
            dtpMatricula.Value = DateTime.Now;
        }
    }
}
  
