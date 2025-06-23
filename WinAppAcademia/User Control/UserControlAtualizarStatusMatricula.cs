using System;
using System.Windows.Forms;
using WinAppAcademia.Controllers;
using WinAppAcademia.Repositories;
using WinAppAcademia.Models; // Para a classe Matricula

namespace WinAppAcademia.UserControls
{
    public partial class UserControlAtualizarStatusMatricula : UserControl
    {
        private DashboardRepository _dashboardRepository;
        private MatriculaController _matriculaController;

        public UserControlAtualizarStatusMatricula()
        {
            InitializeComponent();
            _dashboardRepository = new DashboardRepository();
            _matriculaController = new MatriculaController();
        }

        private void UserControlAtualizarStatusMatricula_Load(object sender, EventArgs e)
        {
            CarregarMatriculas();
            LimparCampos();
        }

        private void CarregarMatriculas()
        {
            try
            {
                var matriculas = _matriculaController.BuscarTodos();
                // Exibe uma combinação do nome do aluno e modalidade
                cbMatricula.DataSource = matriculas;
                cbMatricula.DisplayMember = "NomeAluno"; // Assuming Matricula has a NomeAluno property
                cbMatricula.ValueMember = "IdMatricula"; // Assuming Matricula has an IdMatricula property
                cbMatricula.SelectedIndex = -1; // Nada selecionado inicialmente
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar matrículas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAtualizarStatus_Click(object sender, EventArgs e)
        {
            if (cbMatricula.SelectedValue == null)
            {
                MessageBox.Show("Selecione uma matrícula.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbStatus.SelectedItem == null)
            {
                MessageBox.Show("Selecione um status.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idMatricula = (int)cbMatricula.SelectedValue;
            string novoStatus = cbStatus.SelectedItem.ToString();

            try
            {
                _dashboardRepository.AtualizarStatusMatricula(idMatricula, novoStatus);
                MessageBox.Show("Status da matrícula atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
                CarregarMatriculas(); // Recarregar para ver o status atualizado
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar status da matrícula: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            cbMatricula.SelectedIndex = -1;
            cbStatus.SelectedIndex = -1;
        }
    }
}