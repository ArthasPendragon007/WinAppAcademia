using System;
using System.Drawing;
using System.Windows.Forms;
using WinAppAcademia.Repositories;

namespace WinAppAcademia.UserControls
{
    public partial class UserControlPagamentosPendentes : UserControl
    {
        private DashboardRepository _dashboardRepository;

        public UserControlPagamentosPendentes()
        {
            InitializeComponent();
            _dashboardRepository = new DashboardRepository();
            ConfigurarDataGridView();
        }

        private void UserControlPagamentosPendentes_Load(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void ConfigurarDataGridView()
        {
            dgvPagamentosPendentes.AutoGenerateColumns = false;
            dgvPagamentosPendentes.Columns.Clear();

            dgvPagamentosPendentes.Columns.Add(new DataGridViewTextBoxColumn { Name = "IdAluno", HeaderText = "ID Aluno", DataPropertyName = "IdAluno", ReadOnly = true, Width = 80 });
            dgvPagamentosPendentes.Columns.Add(new DataGridViewTextBoxColumn { Name = "AlunoNome", HeaderText = "Nome do Aluno", DataPropertyName = "AlunoNome", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvPagamentosPendentes.Columns.Add(new DataGridViewTextBoxColumn { Name = "Valor", HeaderText = "Valor", DataPropertyName = "Valor", ReadOnly = true, Width = 120, DefaultCellStyle = { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleLeft } });
            dgvPagamentosPendentes.Columns.Add(new DataGridViewTextBoxColumn { Name = "DataPagamento", HeaderText = "Data Vencimento/Registro", DataPropertyName = "DataPagamento", ReadOnly = true, Width = 150, DefaultCellStyle = { Format = "dd/MM/yyyy" } });

            // Configurações visuais do DataGridView
            dgvPagamentosPendentes.EnableHeadersVisualStyles = false;
            dgvPagamentosPendentes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 122, 204);
            dgvPagamentosPendentes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPagamentosPendentes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvPagamentosPendentes.ColumnHeadersHeight = 35;

            dgvPagamentosPendentes.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 150, 250);
            dgvPagamentosPendentes.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvPagamentosPendentes.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvPagamentosPendentes.RowTemplate.Height = 30;

            dgvPagamentosPendentes.BorderStyle = BorderStyle.None;
            dgvPagamentosPendentes.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPagamentosPendentes.GridColor = Color.Gainsboro;
        }

        private void CarregarDados()
        {
            try
            {
                var data = _dashboardRepository.GetPagamentosPendentes();
                dgvPagamentosPendentes.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CarregarDados();
        }
    }
}