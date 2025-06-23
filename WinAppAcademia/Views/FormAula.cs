using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinAppAcademia.Controllers;
using WinAppAcademia.Models;
using System.Drawing; // Para Color e Font

namespace WinAppAcademia.Views
{
    public partial class FormAula : Form
    {
        private int? aulaSelecionadaId = null;
        private AulaController _aulaController;
        private ModalidadeController _modalidadeController;
        private AcademiaController _academiaController;
        private ProfessorController _professorController;

        public FormAula()
        {
            InitializeComponent();
            _aulaController = new AulaController();
            _modalidadeController = new ModalidadeController();
            _academiaController = new AcademiaController();
            _professorController = new ProfessorController();

        }

        private void ConfigurarDataGridView()
        {
            dgvAulas.AutoGenerateColumns = false;
            dgvAulas.Columns.Clear();

            dgvAulas.Columns.Add(new DataGridViewTextBoxColumn { Name = "IdAula", HeaderText = "ID", DataPropertyName = "IdAula", ReadOnly = true, Width = 60 });
            dgvAulas.Columns.Add(new DataGridViewTextBoxColumn { Name = "NomeModalidade", HeaderText = "Modalidade", DataPropertyName = "NomeModalidade", ReadOnly = true, Width = 150 });
            dgvAulas.Columns.Add(new DataGridViewTextBoxColumn { Name = "NomeAcademia", HeaderText = "Academia", DataPropertyName = "NomeAcademia", ReadOnly = true, Width = 150 });
            dgvAulas.Columns.Add(new DataGridViewTextBoxColumn { Name = "NomeProfessor", HeaderText = "Professor", DataPropertyName = "NomeProfessor", ReadOnly = true, Width = 150 });
            dgvAulas.Columns.Add(new DataGridViewTextBoxColumn { Name = "DiaSemana", HeaderText = "Dia", DataPropertyName = "DiaSemana", ReadOnly = true, Width = 100 });
            dgvAulas.Columns.Add(new DataGridViewTextBoxColumn { Name = "HorarioInicio", HeaderText = "Início", DataPropertyName = "HorarioInicio", ReadOnly = true, Width = 80, DefaultCellStyle = { Format = "hh\\:mm" } });
            dgvAulas.Columns.Add(new DataGridViewTextBoxColumn { Name = "HorarioFim", HeaderText = "Fim", DataPropertyName = "HorarioFim", ReadOnly = true, Width = 80, DefaultCellStyle = { Format = "hh\\:mm" } });
            dgvAulas.Columns.Add(new DataGridViewTextBoxColumn { Name = "CapacidadeMaxima", HeaderText = "Cap. Máx.", DataPropertyName = "CapacidadeMaxima", ReadOnly = true, Width = 90 });

            // Configurações visuais do DataGridView (mantidas do FormAluno)
            dgvAulas.EnableHeadersVisualStyles = false;
            dgvAulas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 122, 204);
            dgvAulas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvAulas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvAulas.ColumnHeadersHeight = 35;

            dgvAulas.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 150, 250);
            dgvAulas.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvAulas.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvAulas.RowTemplate.Height = 30;

            dgvAulas.BorderStyle = BorderStyle.None;
            dgvAulas.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAulas.GridColor = Color.Gainsboro;
        }

        private void CarregarModalidades()
        {
            try
            {
                var modalidades = _modalidadeController.BuscarTodos();
                cbModalidade.DataSource = modalidades;
                cbModalidade.DisplayMember = "NomeModalidade";
                cbModalidade.ValueMember = "IdModalidade";
                cbModalidade.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar modalidades: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarAcademias()
        {
            try
            {
                var academias = _academiaController.BuscarTodos();
                cbAcademia.DataSource = academias;
                cbAcademia.DisplayMember = "Nome";
                cbAcademia.ValueMember = "IdAcademia";
                cbAcademia.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar academias: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarProfessores()
        {
            try
            {
                var professores = _professorController.BuscarTodos();
                cbProfessor.DataSource = professores;
                cbProfessor.DisplayMember = "Nome"; // Ou um formato "Nome (CPF)" se preferir
                cbProfessor.ValueMember = "IdProfessor";
                cbProfessor.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar professores: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarDados()
        {
            try
            {
                var lista = _aulaController.BuscarTodos();
                dgvAulas.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar aulas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            // Validações de entrada na View (apenas para campos obrigatórios pelos FKs)
            if (cbModalidade.SelectedValue == null)
            {
                MessageBox.Show("A modalidade da aula é obrigatória.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbAcademia.SelectedValue == null)
            {
                MessageBox.Show("A academia da aula é obrigatória.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbProfessor.SelectedValue == null)
            {
                MessageBox.Show("O professor da aula é obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TimeSpan? horarioInicio = dtpHorarioInicio.Checked ? dtpHorarioInicio.Value.TimeOfDay : (TimeSpan?)null;
            TimeSpan? horarioFim = dtpHorarioFim.Checked ? dtpHorarioFim.Value.TimeOfDay : (TimeSpan?)null;

            var aula = new Aula
            {
                IdAula = aulaSelecionadaId ?? 0,
                IdModalidade = (int)cbModalidade.SelectedValue,
                IdAcademia = (int)cbAcademia.SelectedValue,
                IdProfessor = (int)cbProfessor.SelectedValue,
                DiaSemana = cbDiaSemana.SelectedItem?.ToString(), // Nulo se nada selecionado
                HorarioInicio = horarioInicio,
                HorarioFim = horarioFim,
                CapacidadeMaxima = numCapacidadeMaxima.Value > 0 ? (int?)numCapacidadeMaxima.Value : (int?)null // Nulo se 0 ou desmarcado
            };

            try
            {
                _aulaController.Salvar(aula);
                MessageBox.Show("Aula salva com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
                CarregarDados();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Erro de validação: " + ex.Message, "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar aula: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (aulaSelecionadaId.HasValue && aulaSelecionadaId.Value > 0)
            {
                DialogResult confirm = MessageBox.Show($"Tem certeza que deseja excluir a aula ID: {aulaSelecionadaId.Value}?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        _aulaController.Remover(aulaSelecionadaId.Value);
                        MessageBox.Show("Aula excluída com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparCampos();
                        CarregarDados();
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show("Erro de validação: " + ex.Message, "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao excluir aula: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione uma aula para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            aulaSelecionadaId = null;
            cbModalidade.SelectedIndex = -1;
            cbAcademia.SelectedIndex = -1;
            cbProfessor.SelectedIndex = -1;
            cbDiaSemana.SelectedIndex = -1;

            dtpHorarioInicio.Value = DateTime.Now.Date; // Reseta para a data atual, mas a hora será a padrão (00:00)
            dtpHorarioInicio.Checked = false; // Permite que o campo de hora seja opcional
            dtpHorarioFim.Value = DateTime.Now.Date; // Reseta para a data atual
            dtpHorarioFim.Checked = false; // Permite que o campo de hora seja opcional

            numCapacidadeMaxima.Value = 0; // Ou um valor padrão
        }

        private void dgvAulas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvAulas.Rows.Count)
            {
                var selectedAula = dgvAulas.Rows[e.RowIndex].DataBoundItem as Aula;

                if (selectedAula != null)
                {
                    aulaSelecionadaId = selectedAula.IdAula;
                    cbModalidade.SelectedValue = selectedAula.IdModalidade;
                    cbAcademia.SelectedValue = selectedAula.IdAcademia;
                    cbProfessor.SelectedValue = selectedAula.IdProfessor;
                    cbDiaSemana.SelectedItem = selectedAula.DiaSemana;

                    if (selectedAula.HorarioInicio.HasValue)
                    {
                        dtpHorarioInicio.Value = DateTime.Today.Add(selectedAula.HorarioInicio.Value);
                        dtpHorarioInicio.Checked = true;
                    }
                    else
                    {
                        dtpHorarioInicio.Checked = false;
                    }

                    if (selectedAula.HorarioFim.HasValue)
                    {
                        dtpHorarioFim.Value = DateTime.Today.Add(selectedAula.HorarioFim.Value);
                        dtpHorarioFim.Checked = true;
                    }
                    else
                    {
                        dtpHorarioFim.Checked = false;
                    }

                    if (selectedAula.CapacidadeMaxima.HasValue)
                    {
                        numCapacidadeMaxima.Value = selectedAula.CapacidadeMaxima.Value;
                    }
                    else
                    {
                        numCapacidadeMaxima.Value = 0; // Ou um valor que indique "nenhum"
                    }
                }
            }
        }

        private void FormAula_Load(object sender, EventArgs e) 
        {
            ConfigurarDataGridView();
            CarregarModalidades();
            CarregarAcademias();
            CarregarProfessores();
            CarregarDados();
            LimparCampos();
        }
    }
}