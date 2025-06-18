using WinAppAcademia.Utils;
using WinAppAcademia.Views;

namespace WinAppAcademia
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            DBconfig.CriarEstruturaDoBanco();
        }

        private void FormularioAlunoPage(object sender, EventArgs e)
        {
            var formAluno = new FormAluno();
            formAluno.ShowDialog();
        }
    }
}
