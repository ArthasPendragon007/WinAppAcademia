using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinAppAcademia.Controllers;
using WinAppAcademia.Models;
using System.Drawing;

namespace WinAppAcademia.Views
{
    public partial class FormFrequencia : Form
    {
        private int? frequenciaSelecionadaId = null;
        private FrequenciaController _frequenciaController;
        private AlunoController _alunoController;
        private AulaController _aulaController;

        public FormFrequencia()
        {
            InitializeComponent();
            _frequenciaController = new FrequenciaController();
            _alunoController = new AlunoController();
            _aulaController = new AulaController();
            ConfigurarDataGridView();
            CarregarAlunos();
            CarregarAulas();
            CarregarDados();
            LimparCampos();

            // Configurar itens do ComboBox cbPresenca para 'sim' e 'não'
            cbPresenca.Items.Clear();
            cbPresenca.Items.Add("sim");
            cbPresenca.Items.Add("não");
        }

        private void ConfigurarDataGridView()
        {
            dgvFrequencias.AutoGenerateColumns = false;
            dgvFrequencias.Columns.Clear();

            // Coluna ID Freq.: Pequena, apenas para referência.
            dgvFrequencias.Columns.Add(new DataGridViewTextBoxColumn { Name = "IdFrequencia", HeaderText = "ID Freq.", DataPropertyName = "IdFrequencia", ReadOnly = true, Width = 50 }); // Diminuído de 60 para 50

            // Coluna Aluno: Preenche o espaço disponível, mas com um mínimo.
            dgvFrequencias.Columns.Add(new DataGridViewTextBoxColumn { Name = "NomeAluno", HeaderText = "Aluno", DataPropertyName = "NomeAluno", ReadOnly = true, MinimumWidth = 100, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });

            // Coluna Aula (Detalhes): Prioridade para preencher o espaço, ajustando-se ao conteúdo.
            // Removido AutoSizeMode.Fill para permitir que o preenchimento seja dividido com NomeAluno.
            // Adicionado FillWeight para dar mais peso a esta coluna.
            dgvFrequencias.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NomeAula",
                HeaderText = "Aula (Detalhes)",
                DataPropertyName = "NomeAula",
                ReadOnly = true,
                MinimumWidth = 200, // Defina um tamanho mínimo para garantir visibilidade
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 200 // Dá a esta coluna 2x mais peso no preenchimento do espaço que NomeAluno
            });

            // Coluna Data da Aula: Largura fixa menor, apenas o suficiente para a data.
            dgvFrequencias.Columns.Add(new DataGridViewTextBoxColumn { Name = "DataAula", HeaderText = "Data", DataPropertyName = "DataAula", ReadOnly = true, Width = 80, DefaultCellStyle = { Format = "dd/MM/yyyy" } }); // Diminuído de 100 para 80

            // Coluna Presença: Largura fixa, pequena.
            dgvFrequencias.Columns.Add(new DataGridViewTextBoxColumn { Name = "Presenca", HeaderText = "Presença", DataPropertyName = "Presenca", ReadOnly = true, Width = 70 }); // Diminuído de 80 para 70


            // Estilos visuais (mantidos como estavam, mas importante para a estética)
            dgvFrequencias.EnableHeadersVisualStyles = false;
            dgvFrequencias.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 122, 204);
            dgvFrequencias.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvFrequencias.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvFrequencias.ColumnHeadersHeight = 35;

            dgvFrequencias.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 150, 250);
            dgvFrequencias.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvFrequencias.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvFrequencias.RowTemplate.Height = 30;

            dgvFrequencias.BorderStyle = BorderStyle.None;
            dgvFrequencias.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvFrequencias.GridColor = Color.Gainsboro;
        }

        private void CarregarAlunos()
        {
            try
            {
                var alunos = _alunoController.BuscarTodos();
                cbAluno.DataSource = alunos;
                cbAluno.DisplayMember = "Nome";
                cbAluno.ValueMember = "IdAluno";
                cbAluno.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar alunos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarAulas()
        {
            try
            {
                var aulas = _aulaController.BuscarTodos();
                cbAula.DataSource = aulas;
                cbAula.DisplayMember = "DescricaoCompleta"; // Usa a propriedade DescricaoCompleta da classe Aula
                cbAula.ValueMember = "IdAula";
                cbAula.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar aulas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarDados()
        {
            try
            {
                var lista = _frequenciaController.BuscarTodos();
                dgvFrequencias.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar frequências: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            // Validação de entrada na View
            if (cbAluno.SelectedValue == null || cbAula.SelectedValue == null || cbPresenca.SelectedItem == null)
            {
                MessageBox.Show("Aluno, Aula e Presença são campos obrigatórios.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var frequencia = new Frequencia
            {
                IdFrequencia = frequenciaSelecionadaId ?? 0,
                IdAluno = (int)cbAluno.SelectedValue,
                IdAula = (int)cbAula.SelectedValue,
                DataAula = dtpDataAula.Value.Date,
                Presenca = cbPresenca.SelectedItem.ToString()
            };

            try
            {
                _frequenciaController.Salvar(frequencia);
                MessageBox.Show("Registro de frequência salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
                CarregarDados();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Erro de validação: " + ex.Message, "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar frequência: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (frequenciaSelecionadaId.HasValue && frequenciaSelecionadaId.Value > 0)
            {
                DialogResult confirm = MessageBox.Show($"Tem certeza que deseja excluir o registro de frequência ID: {frequenciaSelecionadaId.Value}?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        _frequenciaController.Remover(frequenciaSelecionadaId.Value);
                        MessageBox.Show("Registro de frequência excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparCampos();
                        CarregarDados();
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show("Erro de validação: " + ex.Message, "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao excluir frequência: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um registro de frequência para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            frequenciaSelecionadaId = null;
            cbAluno.SelectedIndex = -1;
            cbAula.SelectedIndex = -1;
            dtpDataAula.Value = DateTime.Now;
            cbPresenca.SelectedIndex = -1; // Desseleciona a presença
        }

        private void dgvFrequencias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvFrequencias.Rows.Count)
            {
                if (dgvFrequencias.Rows[e.RowIndex].DataBoundItem is Frequencia selectedFrequencia)
                {
                    frequenciaSelecionadaId = selectedFrequencia.IdFrequencia;
                    cbAluno.SelectedValue = selectedFrequencia.IdAluno;
                    cbAula.SelectedValue = selectedFrequencia.IdAula;
                    dtpDataAula.Value = selectedFrequencia.DataAula;
                    cbPresenca.SelectedItem = selectedFrequencia.Presenca;

                }
            }
        }

        private void FormFrequencia_Load(object sender, EventArgs e) { }
    }
}