using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinAppAcademia.Controllers;
using WinAppAcademia.Models;
using System.Drawing; // Para Color e Font
using System.Globalization; // Para CultureInfo e NumberStyles

namespace WinAppAcademia.Views
{
    public partial class FormPagamento : Form
    {
        private int? pagamentoSelecionadoId = null;
        private PagamentoController _pagamentoController;
        private AlunoController _alunoController; // Para carregar a lista de alunos

        public FormPagamento()
        {
            InitializeComponent();
            _pagamentoController = new PagamentoController();
            _alunoController = new AlunoController();
            ConfigurarDataGridView();
            CarregarAlunos(); // Carrega os alunos para o ComboBox
            CarregarDados();
            LimparCampos();
        }

        private void ConfigurarDataGridView()
        {
            dgvPagamentos.AutoGenerateColumns = false;
            dgvPagamentos.Columns.Clear();

            dgvPagamentos.Columns.Add(new DataGridViewTextBoxColumn { Name = "IdPagamento", HeaderText = "ID", DataPropertyName = "IdPagamento", ReadOnly = true, Width = 60 });
            dgvPagamentos.Columns.Add(new DataGridViewTextBoxColumn { Name = "NomeAluno", HeaderText = "Aluno", DataPropertyName = "NomeAluno", ReadOnly = true, Width = 200 });
            dgvPagamentos.Columns.Add(new DataGridViewTextBoxColumn { Name = "DataPagamento", HeaderText = "Data Pagamento", DataPropertyName = "DataPagamento", ReadOnly = true, Width = 120, DefaultCellStyle = { Format = "dd/MM/yyyy" } });
            dgvPagamentos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Valor", HeaderText = "Valor", DataPropertyName = "Valor", ReadOnly = true, Width = 120, DefaultCellStyle = { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleLeft } }); // Formato monetário
            dgvPagamentos.Columns.Add(new DataGridViewTextBoxColumn { Name = "StatusPagamento", HeaderText = "Status", DataPropertyName = "StatusPagamento", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });

            // Configurações visuais do DataGridView (mantidas do FormAluno)
            dgvPagamentos.EnableHeadersVisualStyles = false;
            dgvPagamentos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 122, 204);
            dgvPagamentos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPagamentos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvPagamentos.ColumnHeadersHeight = 35;

            dgvPagamentos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 150, 250);
            dgvPagamentos.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvPagamentos.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvPagamentos.RowTemplate.Height = 30;

            dgvPagamentos.BorderStyle = BorderStyle.None;
            dgvPagamentos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPagamentos.GridColor = Color.Gainsboro;
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

        private void CarregarDados()
        {
            try
            {
                var lista = _pagamentoController.BuscarTodos();
                dgvPagamentos.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar pagamentos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            // Validação de entrada na View
            if (cbAluno.SelectedValue == null)
            {
                MessageBox.Show("O aluno é um campo obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbStatusPagamento.SelectedItem == null)
            {
                MessageBox.Show("O status do pagamento é um campo obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validação e conversão do valor
            if (!decimal.TryParse(txtValor.Text.Replace("R$", "").Trim(), NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal valorPagamento))
            {
                MessageBox.Show("Valor do pagamento inválido. Digite um número decimal válido (ex: 150,00).", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (valorPagamento <= 0)
            {
                MessageBox.Show("O valor do pagamento deve ser positivo.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var pagamento = new Pagamento
            {
                IdPagamento = pagamentoSelecionadoId ?? 0,
                IdAluno = (int)cbAluno.SelectedValue,
                DataPagamento = dtpDataPagamento.Value.Date, // Apenas a data
                Valor = valorPagamento,
                StatusPagamento = cbStatusPagamento.SelectedItem.ToString()
            };

            try
            {
                _pagamentoController.Salvar(pagamento);
                MessageBox.Show("Pagamento salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
                CarregarDados();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Erro de validação: " + ex.Message, "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar pagamento: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (pagamentoSelecionadoId.HasValue && pagamentoSelecionadoId.Value > 0)
            {
                DialogResult confirm = MessageBox.Show($"Tem certeza que deseja excluir o pagamento ID: {pagamentoSelecionadoId.Value}?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        _pagamentoController.Remover(pagamentoSelecionadoId.Value);
                        MessageBox.Show("Pagamento excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparCampos();
                        CarregarDados();
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show("Erro de validação: " + ex.Message, "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao excluir pagamento: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um pagamento para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            pagamentoSelecionadoId = null;
            cbAluno.SelectedIndex = -1;
            dtpDataPagamento.Value = DateTime.Now.Date; // Define para a data atual
            txtValor.Clear();
            cbStatusPagamento.SelectedIndex = -1;
        }

        private void dgvPagamentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvPagamentos.Rows.Count)
            {
                var selectedPagamento = dgvPagamentos.Rows[e.RowIndex].DataBoundItem as Pagamento;

                if (selectedPagamento != null)
                {
                    pagamentoSelecionadoId = selectedPagamento.IdPagamento;
                    cbAluno.SelectedValue = selectedPagamento.IdAluno;
                    dtpDataPagamento.Value = selectedPagamento.DataPagamento;
                    txtValor.Text = selectedPagamento.Valor.ToString("N2", CultureInfo.CurrentCulture); // Formato monetário
                    cbStatusPagamento.SelectedItem = selectedPagamento.StatusPagamento;
                }
            }
        }

        // Eventos vazios, caso o designer os crie:
        private void FormPagamento_Load(object sender, EventArgs e) { }
    }
}