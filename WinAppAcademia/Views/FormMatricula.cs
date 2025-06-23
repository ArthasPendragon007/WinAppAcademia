using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinAppAcademia.Controllers;
using WinAppAcademia.Models;
using System.Drawing; // Para Color e Font

namespace WinAppAcademia.Views
{
    public partial class FormMatricula : Form
    {
        private int? matriculaSelecionadaId = null;
        private MatriculaController _matriculaController;
        private AlunoController _alunoController;       // Para carregar a lista de alunos
        private ModalidadeController _modalidadeController; // Para carregar a lista de modalidades

        public FormMatricula()
        {
            InitializeComponent();
            _matriculaController = new MatriculaController();
            _alunoController = new AlunoController();
            _modalidadeController = new ModalidadeController();
            ConfigurarDataGridView();
            CarregarAlunos();     // Carrega os alunos para o ComboBox
            CarregarModalidades(); // Carrega as modalidades para o ComboBox
            CarregarDados();
            LimparCampos();
        }

        private void ConfigurarDataGridView()
        {
            dgvMatriculas.AutoGenerateColumns = false;
            dgvMatriculas.Columns.Clear();

            dgvMatriculas.Columns.Add(new DataGridViewTextBoxColumn { Name = "IdMatricula", HeaderText = "ID", DataPropertyName = "IdMatricula", ReadOnly = true, Width = 60 });
            dgvMatriculas.Columns.Add(new DataGridViewTextBoxColumn { Name = "NomeAluno", HeaderText = "Aluno", DataPropertyName = "NomeAluno", ReadOnly = true, Width = 200 });
            dgvMatriculas.Columns.Add(new DataGridViewTextBoxColumn { Name = "NomeModalidade", HeaderText = "Modalidade", DataPropertyName = "NomeModalidade", ReadOnly = true, Width = 180 });
            dgvMatriculas.Columns.Add(new DataGridViewTextBoxColumn { Name = "DataInicio", HeaderText = "Início", DataPropertyName = "DataInicio", ReadOnly = true, Width = 100, DefaultCellStyle = { Format = "dd/MM/yyyy" } });
            dgvMatriculas.Columns.Add(new DataGridViewTextBoxColumn { Name = "DataFim", HeaderText = "Fim", DataPropertyName = "DataFim", ReadOnly = true, Width = 100, DefaultCellStyle = { Format = "dd/MM/yyyy" } });
            dgvMatriculas.Columns.Add(new DataGridViewTextBoxColumn { Name = "StatusMatricula", HeaderText = "Status", DataPropertyName = "StatusMatricula", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });

            // Configurações visuais do DataGridView (mantidas do FormAluno)
            dgvMatriculas.EnableHeadersVisualStyles = false;
            dgvMatriculas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 122, 204);
            dgvMatriculas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvMatriculas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvMatriculas.ColumnHeadersHeight = 35;

            dgvMatriculas.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 150, 250);
            dgvMatriculas.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvMatriculas.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvMatriculas.RowTemplate.Height = 30;

            dgvMatriculas.BorderStyle = BorderStyle.None;
            dgvMatriculas.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvMatriculas.GridColor = Color.Gainsboro;
        }

        private void CarregarAlunos()
        {
            try
            {
                var alunos = _alunoController.BuscarTodos();
                cbAluno.DataSource = alunos;
                cbAluno.DisplayMember = "Nome"; // Propriedade a ser exibida no ComboBox
                cbAluno.ValueMember = "IdAluno"; // Propriedade a ser usada como valor
                cbAluno.SelectedIndex = -1; // Nada selecionado inicialmente
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar alunos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                var lista = _matriculaController.BuscarTodos();
                dgvMatriculas.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar matrículas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            // Validação de entrada na View (apenas para campos obrigatórios pelos FKs e NOT NULL)
            if (cbAluno.SelectedValue == null)
            {
                MessageBox.Show("O aluno é um campo obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbModalidade.SelectedValue == null)
            {
                MessageBox.Show("A modalidade é um campo obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbStatusMatricula.SelectedItem == null)
            {
                MessageBox.Show("O status da matrícula é um campo obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var matricula = new Matricula
            {
                IdMatricula = matriculaSelecionadaId ?? 0,
                IdAluno = (int)cbAluno.SelectedValue,
                IdModalidade = (int)cbModalidade.SelectedValue,
                DataInicio = dtpDataInicio.Value.Date, // Apenas a data
                DataFim = dtpDataFim.Checked ? dtpDataFim.Value.Date : (DateTime?)null, // Nulo se não marcado
                StatusMatricula = cbStatusMatricula.SelectedItem.ToString()
            };

            try
            {
                _matriculaController.Salvar(matricula);
                MessageBox.Show("Matrícula salva com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
                CarregarDados();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Erro de validação: " + ex.Message, "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar matrícula: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (matriculaSelecionadaId.HasValue && matriculaSelecionadaId.Value > 0)
            {
                DialogResult confirm = MessageBox.Show($"Tem certeza que deseja excluir a matrícula ID: {matriculaSelecionadaId.Value}?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        _matriculaController.Remover(matriculaSelecionadaId.Value);
                        MessageBox.Show("Matrícula excluída com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparCampos();
                        CarregarDados();
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show("Erro de validação: " + ex.Message, "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao excluir matrícula: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione uma matrícula para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            matriculaSelecionadaId = null;
            cbAluno.SelectedIndex = -1;
            cbModalidade.SelectedIndex = -1;
            dtpDataInicio.Value = DateTime.Now.Date; // Define para a data atual
            dtpDataFim.Value = DateTime.Now.Date;   // Define para a data atual
            dtpDataFim.Checked = false;             // Desmarca para indicar que é opcional
            cbStatusMatricula.SelectedIndex = -1;
        }

        private void dgvMatriculas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvMatriculas.Rows.Count)
            {
                var selectedMatricula = dgvMatriculas.Rows[e.RowIndex].DataBoundItem as Matricula;

                if (selectedMatricula != null)
                {
                    matriculaSelecionadaId = selectedMatricula.IdMatricula;
                    cbAluno.SelectedValue = selectedMatricula.IdAluno;
                    cbModalidade.SelectedValue = selectedMatricula.IdModalidade;
                    dtpDataInicio.Value = selectedMatricula.DataInicio;

                    if (selectedMatricula.DataFim.HasValue)
                    {
                        dtpDataFim.Value = selectedMatricula.DataFim.Value;
                        dtpDataFim.Checked = true;
                    }
                    else
                    {
                        dtpDataFim.Checked = false; // Desmarca se for nulo
                    }
                    cbStatusMatricula.SelectedItem = selectedMatricula.StatusMatricula;
                }
            }
        }

        // Eventos vazios, caso o designer os crie:
        private void FormMatricula_Load(object sender, EventArgs e) { }
    }
}