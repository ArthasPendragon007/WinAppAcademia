using System;
using System.Drawing;
using System.Windows.Forms;
using WinAppAcademia.Utils;
using WinAppAcademia.Views;
using WinAppAcademia.UserControls;
using Timer = System.Windows.Forms.Timer;

namespace WinAppAcademia
{
    public partial class Main : Form
    {
        private Timer relogioTimer;

        public Main()
        {
            InitializeComponent();
            relogioTimer = new Timer { Interval = 1000 };
            relogioTimer.Tick += relogioTimer_Tick;
            relogioTimer.Start();

            // Ao iniciar, podemos carregar uma das telas de dashboard por padrão
            CarregarUserControl(new UserControlAlunosAtivosModalidades());
        }

        private void Main_Load(object sender, EventArgs e)
        {
            DBconfig.CriarEstruturaDoBanco();
        }

        private void relogioTimer_Tick(object sender, EventArgs e)
        {
            lblRelogio.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void AbrirFormulario(Form form)
        {
            panelConteudoPrincipal.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelConteudoPrincipal.Controls.Add(form);
            form.Show();
            form.BringToFront();
            panelConteudoPrincipal.Refresh();
        }

        private void CarregarUserControl(UserControl userControl)
        {
            panelConteudoPrincipal.Controls.Clear();
            userControl.Dock = DockStyle.Fill;
            panelConteudoPrincipal.Controls.Add(userControl);
            userControl.BringToFront();
            panelConteudoPrincipal.Refresh();
        }

        // --- Event Handlers para os botões de Gerenciamento (Forms - no menu vertical) ---
        private void btnAcademia_Click(object sender, EventArgs e) => AbrirFormulario(new FormAcademia());
        private void btnAlunos_Click(object sender, EventArgs e) => AbrirFormulario(new FormAluno());
        private void btnModalidades_Click(object sender, EventArgs e) => AbrirFormulario(new FormModalidade());
        private void btnProfessores_Click(object sender, EventArgs e) => AbrirFormulario(new FormProfessor());
        private void btnAulas_Click(object sender, EventArgs e) => AbrirFormulario(new FormAula());
        private void btnPagamentos_Click(object sender, EventArgs e) => AbrirFormulario(new FormPagamento());
        private void btnEquipamentos_Click(object sender, EventArgs e) => AbrirFormulario(new FormEquipamento());
        private void btnFrequencia_Click(object sender, EventArgs e) => AbrirFormulario(new FormFrequencia());
        private void btnMatriculas_Click(object sender, EventArgs e) => AbrirFormulario(new FormMatricula());

        // --- Event Handlers para os botões de Dashboard/Relatórios (UserControls - no painel horizontal) ---
        // Certifique-se que o nome do botão no Designer.cs (propriedade Name)
        // corresponde ao nome aqui (ex: btnAlunosAtivos, btnFrequenciaAulas, etc.)
        private void btnAlunosAtivos_Click(object sender, EventArgs e) => CarregarUserControl(new UserControlAlunosAtivosModalidades());
        private void btnFrequenciaAulas_Click(object sender, EventArgs e) => CarregarUserControl(new UserControlFrequenciaPorAula());
        private void btnPagamentosPendentes_Click(object sender, EventArgs e) => CarregarUserControl(new UserControlPagamentosPendentes());
        private void btnRegistrarPagamento_Click(object sender, EventArgs e) => CarregarUserControl(new UserControlRegistrarPagamento());
        private void btnTotalPagoAluno_Click(object sender, EventArgs e) => CarregarUserControl(new UserControlTotalPagoAluno());
        private void btnAtualizarStatusMatricula_Click(object sender, EventArgs e) => CarregarUserControl(new UserControlAtualizarStatusMatricula());

        private void btnSair_Click(object sender, EventArgs e) => this.Close();

        private void panelLateralForms_Paint(object sender, PaintEventArgs e)
        {
            // Este evento pode ser removido se não houver necessidade de desenho personalizado.
            // Mantenho-o apenas porque estava no seu código original.
        }

        private void lblDashboardsRelatoriosTitulo_Click(object sender, EventArgs e)
        {

        }
    }
}