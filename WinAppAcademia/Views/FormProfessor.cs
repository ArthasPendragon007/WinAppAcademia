using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinAppAcademia.Controllers;
using WinAppAcademia.Models;
using System.Drawing; // Para Color e Font

namespace WinAppAcademia.Views
{
    public partial class FormProfessor : Form
    {
        private int? professorSelecionadoId = null;
        private ProfessorController _professorController;
        private AcademiaController _academiaController;   // Para carregar a lista de academias
        private ModalidadeController _modalidadeController; // Para carregar a lista de modalidades

        public FormProfessor()
        {
            InitializeComponent();
            _professorController = new ProfessorController();
            _academiaController = new AcademiaController();
            _modalidadeController = new ModalidadeController();
            ConfigurarDataGridView();
            CarregarAcademias();   // Carrega as academias para o ComboBox
            CarregarModalidades(); // Carrega as modalidades para o ComboBox
            CarregarDados();
            LimparCampos();
        }

        private void ConfigurarDataGridView()
        {
            dgvProfessores.AutoGenerateColumns = false;
            dgvProfessores.Columns.Clear();

            dgvProfessores.Columns.Add(new DataGridViewTextBoxColumn { Name = "IdProfessor", HeaderText = "ID", DataPropertyName = "IdProfessor", ReadOnly = true, Width = 60 });
            dgvProfessores.Columns.Add(new DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome", DataPropertyName = "Nome", ReadOnly = true, Width = 150 });
            dgvProfessores.Columns.Add(new DataGridViewTextBoxColumn { Name = "Cpf", HeaderText = "CPF", DataPropertyName = "Cpf", ReadOnly = true, Width = 120 });
            dgvProfessores.Columns.Add(new DataGridViewTextBoxColumn { Name = "DataNascimento", HeaderText = "Nascimento", DataPropertyName = "DataNascimento", ReadOnly = true, Width = 100, DefaultCellStyle = { Format = "dd/MM/yyyy" } });
            dgvProfessores.Columns.Add(new DataGridViewTextBoxColumn { Name = "Sexo", HeaderText = "Sexo", DataPropertyName = "Sexo", ReadOnly = true, Width = 50 });
            dgvProfessores.Columns.Add(new DataGridViewTextBoxColumn { Name = "Telefone", HeaderText = "Telefone", DataPropertyName = "Telefone", ReadOnly = true, Width = 120 });
            dgvProfessores.Columns.Add(new DataGridViewTextBoxColumn { Name = "Email", HeaderText = "Email", DataPropertyName = "Email", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvProfessores.Columns.Add(new DataGridViewTextBoxColumn { Name = "NomeAcademia", HeaderText = "Academia", DataPropertyName = "NomeAcademia", ReadOnly = true, Width = 120 });
            dgvProfessores.Columns.Add(new DataGridViewTextBoxColumn { Name = "NomeModalidade", HeaderText = "Modalidade", DataPropertyName = "NomeModalidade", ReadOnly = true, Width = 120 });

            // Configurações visuais do DataGridView (mantidas do FormAluno)
            dgvProfessores.EnableHeadersVisualStyles = false;
            dgvProfessores.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 122, 204);
            dgvProfessores.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvProfessores.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvProfessores.ColumnHeadersHeight = 35;

            dgvProfessores.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 150, 250);
            dgvProfessores.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvProfessores.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvProfessores.RowTemplate.Height = 30;

            dgvProfessores.BorderStyle = BorderStyle.None;
            dgvProfessores.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProfessores.GridColor = Color.Gainsboro;
        }

        private void CarregarAcademias()
        {
            try
            {
                var academias = _academiaController.BuscarTodos();
                cbAcademia.DataSource = academias;
                cbAcademia.DisplayMember = "Nome"; // Propriedade a ser exibida no ComboBox
                cbAcademia.ValueMember = "IdAcademia"; // Propriedade a ser usada como valor
                cbAcademia.SelectedIndex = -1; // Nada selecionado inicialmente
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar academias: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarModalidades()
        {
            try
            {
                var modalidades = _modalidadeController.BuscarTodos();
                cbModalidade.DataSource = modalidades;
                cbModalidade.DisplayMember = "NomeModalidade"; // Propriedade a ser exibida no ComboBox
                cbModalidade.ValueMember = "IdModalidade";     // Propriedade a ser usada como valor
                cbModalidade.SelectedIndex = -1; // Nada selecionado inicialmente
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar modalidades: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarDados()
        {
            try
            {
                var lista = _professorController.BuscarTodos();
                dgvProfessores.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar professores: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            // Validação de entrada na View (apenas para campos obrigatórios visíveis)
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("O nome do professor é um campo obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtCpf.Text))
            {
                MessageBox.Show("O CPF do professor é um campo obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbAcademia.SelectedValue == null)
            {
                MessageBox.Show("A academia do professor é um campo obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbModalidade.SelectedValue == null)
            {
                MessageBox.Show("A modalidade do professor é um campo obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var professor = new Professor
            {
                IdProfessor = professorSelecionadoId ?? 0,
                IdAcademia = (int)cbAcademia.SelectedValue,
                IdModalidade = (int)cbModalidade.SelectedValue,
                Nome = txtNome.Text,
                Cpf = txtCpf.Text,
                DataNascimento = dtpNascimento.Checked ? dtpNascimento.Value : (DateTime?)null, // Nulo se não marcado
                Sexo = cbSexo.SelectedItem?.ToString().FirstOrDefault(), // Primeiro caractere se algo for selecionado
                Telefone = txtTelefone.Text,
                Email = txtEmail.Text
            };

            try
            {
                _professorController.Salvar(professor);
                MessageBox.Show("Professor salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
                CarregarDados();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Erro de validação: " + ex.Message, "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar professor: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (professorSelecionadoId.HasValue && professorSelecionadoId.Value > 0)
            {
                DialogResult confirm = MessageBox.Show($"Tem certeza que deseja excluir o professor ID: {professorSelecionadoId.Value}?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        _professorController.Remover(professorSelecionadoId.Value);
                        MessageBox.Show("Professor excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparCampos();
                        CarregarDados();
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show("Erro de validação: " + ex.Message, "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao excluir professor: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um professor para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            professorSelecionadoId = null;
            txtNome.Clear();
            txtCpf.Clear();
            dtpNascimento.Value = DateTime.Now; // Define para a data atual
            dtpNascimento.Checked = false;      // Permite que seja nulo
            cbSexo.SelectedIndex = -1;
            txtTelefone.Clear();
            txtEmail.Clear();
            cbAcademia.SelectedIndex = -1;
            cbModalidade.SelectedIndex = -1;
        }

        private void dgvProfessores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvProfessores.Rows.Count)
            {
                var selectedProfessor = dgvProfessores.Rows[e.RowIndex].DataBoundItem as Professor;

                if (selectedProfessor != null)
                {
                    professorSelecionadoId = selectedProfessor.IdProfessor;
                    txtNome.Text = selectedProfessor.Nome;
                    txtCpf.Text = selectedProfessor.Cpf;

                    if (selectedProfessor.DataNascimento.HasValue)
                    {
                        dtpNascimento.Value = selectedProfessor.DataNascimento.Value;
                        dtpNascimento.Checked = true;
                    }
                    else
                    {
                        dtpNascimento.Checked = false; // Desmarca se for nulo
                    }

                    cbSexo.SelectedItem = selectedProfessor.Sexo?.ToString();
                    txtTelefone.Text = selectedProfessor.Telefone;
                    txtEmail.Text = selectedProfessor.Email;
                    cbAcademia.SelectedValue = selectedProfessor.IdAcademia;
                    cbModalidade.SelectedValue = selectedProfessor.IdModalidade;
                }
            }
        }

        // Eventos vazios, caso o designer os crie:
        private void FormProfessor_Load(object sender, EventArgs e) { }
    }
}