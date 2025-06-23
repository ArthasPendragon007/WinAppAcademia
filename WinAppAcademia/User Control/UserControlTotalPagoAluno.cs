using System;
using System.Globalization;
using System.Windows.Forms;
using WinAppAcademia.Controllers;
using WinAppAcademia.Repositories;

namespace WinAppAcademia.UserControls
{
    public partial class UserControlTotalPagoAluno : UserControl
    {
        private DashboardRepository _dashboardRepository;
        private AlunoController _alunoController;

        public UserControlTotalPagoAluno()
        {
            InitializeComponent();
            _dashboardRepository = new DashboardRepository();
            _alunoController = new AlunoController();
        }

        private void UserControlTotalPagoAluno_Load(object sender, EventArgs e)
        {
            CarregarAlunos();
            txtTotalPago.Text = "R$ 0,00"; // Valor inicial
        }

        private void CarregarAlunos()
        {
            try
            {
                var alunos = _alunoController.BuscarTodos();
                cbAluno.DataSource = alunos;
                cbAluno.DisplayMember = "Nome"; // Assumindo que o modelo Aluno tem uma propriedade Nome
                cbAluno.ValueMember = "IdAluno";     // Assumindo que o modelo Aluno tem uma propriedade Id
                cbAluno.SelectedIndex = -1; // Nada selecionado inicialmente
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar alunos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCalcularTotal_Click(object sender, EventArgs e)
        {
            if (cbAluno.SelectedValue == null)
            {
                MessageBox.Show("Selecione um aluno para calcular o total pago.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idAluno = (int)cbAluno.SelectedValue;

            try
            {
                decimal total = _dashboardRepository.CalcularTotalPagoPorAluno(idAluno);
                txtTotalPago.Text = total.ToString("C2", CultureInfo.CurrentCulture); // Formato monetário
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao calcular total pago: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTotalPago.Text = "Erro!";
            }
        }
    }
}