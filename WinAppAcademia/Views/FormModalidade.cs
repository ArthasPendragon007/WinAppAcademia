using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinAppAcademia.Controllers;
using WinAppAcademia.Models;
using System.Drawing;
using System.Globalization; // Para InvariantCulture

namespace WinAppAcademia.Views
{
    public partial class FormModalidade : Form
    {
        private int? modalidadeSelecionadaId = null;
        private ModalidadeController _modalidadeController;

        public FormModalidade()
        {
            InitializeComponent();
            _modalidadeController = new ModalidadeController();
            ConfigurarDataGridView();
            CarregarDados();
            LimparCampos();
        }

        private void ConfigurarDataGridView()
        {
            dgvModalidades.AutoGenerateColumns = false;
            dgvModalidades.Columns.Clear();

            dgvModalidades.Columns.Add(new DataGridViewTextBoxColumn { Name = "IdModalidade", HeaderText = "ID", DataPropertyName = "IdModalidade", ReadOnly = true, Width = 60 });
            dgvModalidades.Columns.Add(new DataGridViewTextBoxColumn { Name = "NomeModalidade", HeaderText = "Nome da Modalidade", DataPropertyName = "NomeModalidade", ReadOnly = true, Width = 200 });
            dgvModalidades.Columns.Add(new DataGridViewTextBoxColumn { Name = "Descricao", HeaderText = "Descrição", DataPropertyName = "Descricao", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvModalidades.Columns.Add(new DataGridViewTextBoxColumn { Name = "ValorMensalidade", HeaderText = "Valor Mensalidade", DataPropertyName = "ValorMensalidade", ReadOnly = true, Width = 120, DefaultCellStyle = { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight } }); // Formato monetário

            // Configurações visuais do DataGridView (mantidas do FormAluno)
            dgvModalidades.EnableHeadersVisualStyles = false;
            dgvModalidades.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 122, 204);
            dgvModalidades.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvModalidades.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvModalidades.ColumnHeadersHeight = 35;

            dgvModalidades.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 150, 250);
            dgvModalidades.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvModalidades.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvModalidades.RowTemplate.Height = 30;

            dgvModalidades.BorderStyle = BorderStyle.None;
            dgvModalidades.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvModalidades.GridColor = Color.Gainsboro;
        }

        private void CarregarDados()
        {
            try
            {
                var lista = _modalidadeController.BuscarTodos();
                dgvModalidades.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar modalidades: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            // Validação de entrada na View
            if (string.IsNullOrWhiteSpace(txtNomeModalidade.Text))
            {
                MessageBox.Show("O nome da modalidade é um campo obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validação e conversão do valor da mensalidade
            if (!decimal.TryParse(txtValorMensalidade.Text.Replace("R$", "").Trim(), NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal valorMensalidade))
            {
                MessageBox.Show("Valor da mensalidade inválido. Digite um número decimal válido (ex: 150,00).", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var modalidade = new Modalidade
            {
                IdModalidade = modalidadeSelecionadaId ?? 0,
                NomeModalidade = txtNomeModalidade.Text,
                Descricao = txtDescricao.Text,
                ValorMensalidade = valorMensalidade
            };

            try
            {
                _modalidadeController.Salvar(modalidade);
                MessageBox.Show("Modalidade salva com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
                CarregarDados();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Erro de validação: " + ex.Message, "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar modalidade: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (modalidadeSelecionadaId.HasValue && modalidadeSelecionadaId.Value > 0)
            {
                DialogResult confirm = MessageBox.Show($"Tem certeza que deseja excluir a modalidade ID: {modalidadeSelecionadaId.Value}?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        _modalidadeController.Remover(modalidadeSelecionadaId.Value);
                        MessageBox.Show("Modalidade excluída com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparCampos();
                        CarregarDados();
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show("Erro de validação: " + ex.Message, "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao excluir modalidade: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione uma modalidade para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            modalidadeSelecionadaId = null;
            txtNomeModalidade.Clear();
            txtDescricao.Clear();
            txtValorMensalidade.Clear();
        }

        private void dgvModalidades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvModalidades.Rows.Count)
            {
                var selectedModalidade = dgvModalidades.Rows[e.RowIndex].DataBoundItem as Modalidade;

                if (selectedModalidade != null)
                {
                    modalidadeSelecionadaId = selectedModalidade.IdModalidade;
                    txtNomeModalidade.Text = selectedModalidade.NomeModalidade;
                    txtDescricao.Text = selectedModalidade.Descricao;
                    txtValorMensalidade.Text = selectedModalidade.ValorMensalidade.ToString("N2", CultureInfo.CurrentCulture); // Formato monetário
                }
            }
        }

        // Eventos vazios, caso o designer os crie:
        private void FormModalidade_Load(object sender, EventArgs e) { }
    }
}