using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinAppAcademia.Controllers;
using WinAppAcademia.Models;
using System.Drawing;

namespace WinAppAcademia.Views
{
    public partial class FormEquipamento : Form
    {
        private int? equipamentoSelecionadoId = null;
        private EquipamentoController _equipamentoController;
        private AcademiaController _academiaController; // Para carregar a lista de academias

        public FormEquipamento()
        {
            InitializeComponent();
            _equipamentoController = new EquipamentoController();
            _academiaController = new AcademiaController(); // Inicializa o controller de Academia
            ConfigurarDataGridView();
            CarregarAcademias(); // Carrega as academias para o ComboBox
            CarregarDados();
            LimparCampos();
        }

        private void ConfigurarDataGridView()
        {
            dgvEquipamentos.AutoGenerateColumns = false;
            dgvEquipamentos.Columns.Clear();

            dgvEquipamentos.Columns.Add(new DataGridViewTextBoxColumn { Name = "IdEquipamento", HeaderText = "ID", DataPropertyName = "IdEquipamento", ReadOnly = true, Width = 60 });
            dgvEquipamentos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome", DataPropertyName = "Nome", ReadOnly = true, Width = 150 });
            dgvEquipamentos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Descricao", HeaderText = "Descrição", DataPropertyName = "Descricao", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvEquipamentos.Columns.Add(new DataGridViewTextBoxColumn { Name = "DataAquisicao", HeaderText = "Aquisição", DataPropertyName = "DataAquisicao", ReadOnly = true, Width = 100, DefaultCellStyle = { Format = "dd/MM/yyyy" } });
            dgvEquipamentos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Estado", HeaderText = "Estado", DataPropertyName = "Estado", ReadOnly = true, Width = 100 });
            dgvEquipamentos.Columns.Add(new DataGridViewTextBoxColumn { Name = "NomeAcademia", HeaderText = "Academia", DataPropertyName = "NomeAcademia", ReadOnly = true, Width = 150 }); // Exibe o nome da academia

            // Configurações visuais do DataGridView (mantidas do FormAluno)
            dgvEquipamentos.EnableHeadersVisualStyles = false;
            dgvEquipamentos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 122, 204);
            dgvEquipamentos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvEquipamentos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvEquipamentos.ColumnHeadersHeight = 35;

            dgvEquipamentos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 150, 250);
            dgvEquipamentos.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvEquipamentos.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvEquipamentos.RowTemplate.Height = 30;

            dgvEquipamentos.BorderStyle = BorderStyle.None;
            dgvEquipamentos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvEquipamentos.GridColor = Color.Gainsboro;
        }

        private void CarregarAcademias()
        {
            try
            {
                var academias = _academiaController.BuscarTodos();
                cbAcademia.DataSource = academias;
                cbAcademia.DisplayMember = "Nome"; // Exibe o nome da academia
                cbAcademia.ValueMember = "IdAcademia"; // Usa o ID da academia como valor
                cbAcademia.SelectedIndex = -1; // Nada selecionado inicialmente
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar academias: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarDados()
        {
            try
            {
                var lista = _equipamentoController.BuscarTodos();
                dgvEquipamentos.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar equipamentos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            // Validação de entrada na View
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("O nome do equipamento é um campo obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbEstado.SelectedValue == null || string.IsNullOrWhiteSpace(cbEstado.SelectedItem?.ToString()))
            {
                MessageBox.Show("O estado do equipamento é um campo obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbAcademia.SelectedValue == null) // id_academia é NOT NULL agora
            {
                MessageBox.Show("A academia do equipamento é um campo obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var equipamento = new Equipamento
            {
                IdEquipamento = equipamentoSelecionadoId ?? 0,
                IdAcademia = (int)cbAcademia.SelectedValue, // id_academia é INT NOT NULL
                Nome = txtNome.Text,
                Descricao = txtDescricao.Text,
                DataAquisicao = dtpDataAquisicao.Checked ? dtpDataAquisicao.Value : (DateTime?)null, // Pode ser nulo
                Estado = cbEstado.SelectedItem.ToString()
            };

            try
            {
                _equipamentoController.Salvar(equipamento);
                MessageBox.Show("Equipamento salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
                CarregarDados();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Erro de validação: " + ex.Message, "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar equipamento: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (equipamentoSelecionadoId.HasValue && equipamentoSelecionadoId.Value > 0)
            {
                DialogResult confirm = MessageBox.Show($"Tem certeza que deseja excluir o equipamento ID: {equipamentoSelecionadoId.Value}?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        _equipamentoController.Remover(equipamentoSelecionadoId.Value);
                        MessageBox.Show("Equipamento excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparCampos();
                        CarregarDados();
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show("Erro de validação: " + ex.Message, "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao excluir equipamento: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um equipamento para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            equipamentoSelecionadoId = null;
            txtNome.Clear();
            txtDescricao.Clear();
            dtpDataAquisicao.Value = DateTime.Now;
            dtpDataAquisicao.Checked = false; // Define como não preenchido se for opcional
            cbEstado.SelectedIndex = -1;
            cbAcademia.SelectedIndex = -1;
        }

        private void dgvEquipamentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvEquipamentos.Rows.Count)
            {
                var selectedEquipamento = dgvEquipamentos.Rows[e.RowIndex].DataBoundItem as Equipamento;

                if (selectedEquipamento != null)
                {
                    equipamentoSelecionadoId = selectedEquipamento.IdEquipamento;
                    txtNome.Text = selectedEquipamento.Nome;
                    txtDescricao.Text = selectedEquipamento.Descricao;

                    if (selectedEquipamento.DataAquisicao.HasValue)
                    {
                        dtpDataAquisicao.Value = selectedEquipamento.DataAquisicao.Value;
                        dtpDataAquisicao.Checked = true;
                    }
                    else
                    {
                        dtpDataAquisicao.Checked = false; // Desmarca se for nulo
                    }

                    cbEstado.SelectedItem = selectedEquipamento.Estado;
                    cbAcademia.SelectedValue = selectedEquipamento.IdAcademia; // Definir o valor selecionado
                }
            }
        }

        // Eventos vazios, caso o designer os crie:
        private void FormEquipamento_Load(object sender, EventArgs e) { }
    }
}