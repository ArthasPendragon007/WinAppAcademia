using System;
using System.Globalization;
using System.Windows.Forms;
using WinAppAcademia.Controllers;
using WinAppAcademia.Repositories; // Para o DashboardRepository

namespace WinAppAcademia.UserControls
{
    public partial class UserControlRegistrarPagamento : UserControl
    {
        private DashboardRepository _dashboardRepository;
        private AlunoController _alunoController;

        public UserControlRegistrarPagamento()
        {
            InitializeComponent();
            _dashboardRepository = new DashboardRepository();
            _alunoController = new AlunoController();
        }

        private void UserControlRegistrarPagamento_Load(object sender, EventArgs e)
        {
            CarregarAlunos();
            LimparCampos();
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

        private void btnRegistrarPagamento_Click(object sender, EventArgs e)
        {
            if (cbAluno.SelectedValue == null)
            {
                MessageBox.Show("Selecione um aluno.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtValor.Text.Replace("R$", "").Trim(), NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal valor))
            {
                MessageBox.Show("Valor inválido. Digite um número decimal válido (ex: 150,00).", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (valor <= 0)
            {
                MessageBox.Show("O valor do pagamento deve ser positivo.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int IdAluno = (int)cbAluno.SelectedValue;
            DateTime dataPagamento = dtpDataPagamento.Value.Date;

            try
            {
                _dashboardRepository.RegistrarPagamento(IdAluno, valor, dataPagamento);
                MessageBox.Show("Pagamento registrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao registrar pagamento: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            cbAluno.SelectedIndex = -1;
            txtValor.Clear();
            dtpDataPagamento.Value = DateTime.Now.Date;
        }
    }
}