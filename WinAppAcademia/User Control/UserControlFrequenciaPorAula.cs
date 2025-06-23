using System;
using System.Windows.Forms;
using WinAppAcademia.Repositories;
using System.Drawing;

namespace WinAppAcademia.UserControls
{
    public partial class UserControlFrequenciaPorAula : UserControl
    {
        private DashboardRepository _dashboardRepository;

        public UserControlFrequenciaPorAula()
        {
            InitializeComponent();
            _dashboardRepository = new DashboardRepository();
            ConfigurarDataGridView();
        }

        private void UserControlFrequenciaPorAula_Load(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void ConfigurarDataGridView()
        {
            dgvFrequenciaAula.AutoGenerateColumns = false;
            dgvFrequenciaAula.Columns.Clear();

            // Colunas para exibir os dados da view
            dgvFrequenciaAula.Columns.Add(new DataGridViewTextBoxColumn { Name = "IdAula", HeaderText = "ID Aula", DataPropertyName = "IdAula", ReadOnly = true, Width = 80 });
            dgvFrequenciaAula.Columns.Add(new DataGridViewTextBoxColumn { Name = "NomeAula", HeaderText = "Aula (Modalidade)", DataPropertyName = "NomeAula", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvFrequenciaAula.Columns.Add(new DataGridViewTextBoxColumn { Name = "NomeProfessor", HeaderText = "Professor", DataPropertyName = "NomeProfessor", ReadOnly = true, Width = 200 });
            dgvFrequenciaAula.Columns.Add(new DataGridViewTextBoxColumn { Name = "TotalPresentes", HeaderText = "Total Presentes", DataPropertyName = "TotalPresentes", ReadOnly = true, Width = 150 });

            // Configurações visuais do DataGridView
            dgvFrequenciaAula.EnableHeadersVisualStyles = false;
            dgvFrequenciaAula.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 122, 204);
            dgvFrequenciaAula.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvFrequenciaAula.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvFrequenciaAula.ColumnHeadersHeight = 35;

            dgvFrequenciaAula.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 150, 250);
            dgvFrequenciaAula.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvFrequenciaAula.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvFrequenciaAula.RowTemplate.Height = 30;

            dgvFrequenciaAula.BorderStyle = BorderStyle.None;
            dgvFrequenciaAula.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvFrequenciaAula.GridColor = Color.Gainsboro;
        }

        private void CarregarDados()
        {
            try
            {
                var data = _dashboardRepository.GetFrequenciaPorAula();
                dgvFrequenciaAula.DataSource = data;
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