using System;
using System.Windows.Forms;
using WinAppAcademia.Repositories; // Para o DashboardRepository
using System.Drawing; // Para Color e Font

namespace WinAppAcademia.UserControls
{
    public partial class UserControlAlunosAtivosModalidades : UserControl
    {
        private DashboardRepository _dashboardRepository;

        public UserControlAlunosAtivosModalidades()
        {
            InitializeComponent();
            _dashboardRepository = new DashboardRepository();
            ConfigurarDataGridView();
        }

        private void UserControlAlunosAtivosModalidades_Load(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void ConfigurarDataGridView()
        {
            dgvAlunosAtivos.AutoGenerateColumns = false;
            dgvAlunosAtivos.Columns.Clear();

            dgvAlunosAtivos.Columns.Add(new DataGridViewTextBoxColumn { Name = "AlunoNome", HeaderText = "Nome do Aluno", DataPropertyName = "AlunoNome", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvAlunosAtivos.Columns.Add(new DataGridViewTextBoxColumn { Name = "NomeModalidade", HeaderText = "Modalidade", DataPropertyName = "NomeModalidade", ReadOnly = true, Width = 150 });
            dgvAlunosAtivos.Columns.Add(new DataGridViewTextBoxColumn { Name = "StatusMatricula", HeaderText = "Status Matrícula", DataPropertyName = "StatusMatricula", ReadOnly = true, Width = 120 });

            // Configurações visuais do DataGridView
            dgvAlunosAtivos.EnableHeadersVisualStyles = false;
            dgvAlunosAtivos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 122, 204);
            dgvAlunosAtivos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvAlunosAtivos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvAlunosAtivos.ColumnHeadersHeight = 35;

            dgvAlunosAtivos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 150, 250);
            dgvAlunosAtivos.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvAlunosAtivos.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvAlunosAtivos.RowTemplate.Height = 30;

            dgvAlunosAtivos.BorderStyle = BorderStyle.None;
            dgvAlunosAtivos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAlunosAtivos.GridColor = Color.Gainsboro;
        }

        private void CarregarDados()
        {
            try
            {
                var data = _dashboardRepository.GetAlunosAtivosModalidades();
                dgvAlunosAtivos.DataSource = data;
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