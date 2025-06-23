using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinAppAcademia.Controllers;
using WinAppAcademia.Models;
using System.Drawing; // Adicionado para Color

namespace WinAppAcademia.Views
{
    public partial class FormAluno : Form
    {
        private int? alunoSelecionadoId = null;
        private AlunoController _controller;

        public FormAluno()
        {
            InitializeComponent(); // Este método é gerado pelo Designer.cs
            _controller = new AlunoController();
            ConfigurarDataGridView(); // Novo método para configurar o DataGridView
            CarregarDados();
        }

        // Novo método para configurar visualmente o DataGridView
        private void ConfigurarDataGridView()
        {
            // Remover a geração automática de colunas se você for defini-las manualmente
            dgvAlunos.AutoGenerateColumns = false;

            // Limpa as colunas existentes para garantir que não haja duplicação
            dgvAlunos.Columns.Clear();

            // Adiciona as colunas com os nomes desejados
            dgvAlunos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "ID", DataPropertyName = "Id", ReadOnly = true, Width = 50 });
            dgvAlunos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome", DataPropertyName = "Nome", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvAlunos.Columns.Add(new DataGridViewTextBoxColumn { Name = "CPF", HeaderText = "CPF", DataPropertyName = "CPF", ReadOnly = true, Width = 120 });
            dgvAlunos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Nascimento", HeaderText = "Data Nasc.", DataPropertyName = "DataNascimento", ReadOnly = true, Width = 100 });
            dgvAlunos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Sexo", HeaderText = "Sexo", DataPropertyName = "Sexo", ReadOnly = true, Width = 50 });
            dgvAlunos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Telefone", HeaderText = "Telefone", DataPropertyName = "Telefone", ReadOnly = true, Width = 120 });
            dgvAlunos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Email", HeaderText = "Email", DataPropertyName = "Email", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvAlunos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Matricula", HeaderText = "Data Matrícula", DataPropertyName = "DataMatricula", ReadOnly = true, Width = 100 });
            dgvAlunos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Status", HeaderText = "Status", DataPropertyName = "Status", ReadOnly = true, Width = 80 });

            // Configurações visuais do DataGridView
            dgvAlunos.EnableHeadersVisualStyles = false;
            dgvAlunos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 122, 204); // Azul do cabeçalho
            dgvAlunos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Texto branco
            dgvAlunos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold); // Fonte negrito
            dgvAlunos.ColumnHeadersHeight = 35; // Altura do cabeçalho

            dgvAlunos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 150, 250); // Cor de seleção mais clara
            dgvAlunos.DefaultCellStyle.SelectionForeColor = Color.White; // Texto branco na seleção
            dgvAlunos.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray; // Linhas alternadas para melhor visualização
            dgvAlunos.RowTemplate.Height = 30; // Altura das linhas

            dgvAlunos.BorderStyle = BorderStyle.None; // Sem borda padrão
            dgvAlunos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal; // Linhas horizontais
            dgvAlunos.GridColor = Color.Gainsboro; // Cor das grades
        }


        private void CarregarDados()
        {
            // O dgvAlunos.Rows.Clear() e Columns.Clear() não são mais necessários aqui
            // pois o AutoGenerateColumns está false e as colunas são definidas no ConfigurarDataGridView.

            var lista = _controller.BuscarTodos();
            // Atribua a lista diretamente ao DataSource para aproveitar as DataPropertyName
            dgvAlunos.DataSource = lista;

            // Se você quiser continuar adicionando linha por linha e não usar DataSource:
            // dgvAlunos.Rows.Clear(); // Mantenha se quiser adicionar manualmente
            // foreach (var a in lista)
            // {
            //     dgvAlunos.Rows.Add(
            //         a.Id,
            //         a.Nome,
            //         a.CPF,
            //         a.DataNascimento.ToShortDateString(),
            //         a.Sexo,
            //         a.Telefone,
            //         a.Email,
            //         a.DataMatricula.ToShortDateString(),
            //         a.Status
            //     );
            // }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            // Validação de entrada básica
            if (string.IsNullOrWhiteSpace(txtNome.Text) || string.IsNullOrWhiteSpace(txtCpf.Text))
            {
                MessageBox.Show("Nome e CPF são campos obrigatórios.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var aluno = new Aluno
            {
                // Se alunoSelecionadoId for nulo, é um novo aluno (Id será 0 e o BD gerará um novo)
                // Se não for nulo, é uma atualização
                IdAluno = alunoSelecionadoId ?? 0,
                Nome = txtNome.Text,
                CPF = txtCpf.Text,
                DataNascimento = dtpNascimento.Value,
                Sexo = cbSexo.SelectedItem?.ToString() ?? "", // Use SelectedItem para ComboBox
                Telefone = txtTelefone.Text,
                Email = txtEmail.Text,
                DataMatricula = dtpMatricula.Value,
                // Garante que o status seja 'ativo' ou 'inativo'
                Status = cbStatus.SelectedItem?.ToString() ?? "ativo"
            };

            try
            {
                _controller.Salvar(aluno);
                MessageBox.Show("Aluno salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
                CarregarDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar aluno: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvAlunos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < dgvAlunos.Rows.Count)
                {
                    // Obtém a linha completa selecionada
                    var selectedAluno = dgvAlunos.Rows[e.RowIndex].DataBoundItem as Aluno;

                    if (selectedAluno != null)
                    {
                        alunoSelecionadoId = selectedAluno.IdAluno;
                        txtNome.Text = selectedAluno.Nome;
                        txtCpf.Text = selectedAluno.CPF;
                        dtpNascimento.Value = selectedAluno.DataNascimento;
                        cbSexo.SelectedItem = selectedAluno.Sexo; // Seleciona o item pelo valor
                        txtTelefone.Text = selectedAluno.Telefone;
                        txtEmail.Text = selectedAluno.Email;
                        dtpMatricula.Value = selectedAluno.DataMatricula;
                        cbStatus.SelectedItem = selectedAluno.Status; // Seleciona o item pelo valor
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados do aluno: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e) // Renomeado o evento para consistência
        {
            if (alunoSelecionadoId.HasValue)
            {
                DialogResult confirm = MessageBox.Show($"Tem certeza que deseja excluir o aluno ID: {alunoSelecionadoId.Value}?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        _controller.Remover(alunoSelecionadoId.Value);
                        MessageBox.Show("Aluno excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparCampos();
                        CarregarDados();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao excluir aluno: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um aluno para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            alunoSelecionadoId = null;
            txtNome.Clear();
            txtCpf.Clear();
            txtTelefone.Clear();
            txtEmail.Clear();
            cbSexo.SelectedIndex = -1; // Limpa a seleção
            cbStatus.SelectedIndex = -1; // Limpa a seleção
            dtpNascimento.Value = DateTime.Now;
            dtpMatricula.Value = DateTime.Now;
        }

        // Mantive os eventos "inúteis" caso realmente sejam usados em algum designer
        private void cbSexo_SelectedIndexChanged(object sender, EventArgs e) { }
        private void lblStatus_Click(object sender, EventArgs e) { }
        private void lblNascimento_Click(object sender, EventArgs e) { }

        private void panelTop_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}