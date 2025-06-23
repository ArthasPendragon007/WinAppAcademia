using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinAppAcademia.Controllers;
using WinAppAcademia.Models;
using System.Drawing;

namespace WinAppAcademia.Views
{
    public partial class FormAcademia : Form
    {
        private int? academiaSelecionadaId = null;
        private AcademiaController _controller;

        public FormAcademia()
        {
            InitializeComponent();
            _controller = new AcademiaController();
            ConfigurarDataGridView();
            CarregarDados();
        }

        // Método para configurar visualmente o DataGridView
        private void ConfigurarDataGridView()
        {
            dgvAcademias.AutoGenerateColumns = false;
            dgvAcademias.Columns.Clear();

            // Adiciona as colunas com os nomes e DataPropertyName corretos
            // Removidas colunas CNPJ, DataAbertura e Status
            dgvAcademias.Columns.Add(new DataGridViewTextBoxColumn { Name = "IdAcademia", HeaderText = "ID", DataPropertyName = "IdAcademia", ReadOnly = true, Width = 50 });
            dgvAcademias.Columns.Add(new DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome da Academia", DataPropertyName = "Nome", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvAcademias.Columns.Add(new DataGridViewTextBoxColumn { Name = "Endereco", HeaderText = "Endereço", DataPropertyName = "Endereco", ReadOnly = true, Width = 250 }); // Ajustei largura
            dgvAcademias.Columns.Add(new DataGridViewTextBoxColumn { Name = "Telefone", HeaderText = "Telefone", DataPropertyName = "Telefone", ReadOnly = true, Width = 120 });
            dgvAcademias.Columns.Add(new DataGridViewTextBoxColumn { Name = "Email", HeaderText = "Email", DataPropertyName = "Email", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill }); // Ajustei AutoSize

            // Configurações visuais do DataGridView (mantidas do FormAluno)
            dgvAcademias.EnableHeadersVisualStyles = false;
            dgvAcademias.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 122, 204);
            dgvAcademias.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvAcademias.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvAcademias.ColumnHeadersHeight = 35;

            dgvAcademias.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 150, 250);
            dgvAcademias.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvAcademias.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvAcademias.RowTemplate.Height = 30;

            dgvAcademias.BorderStyle = BorderStyle.None;
            dgvAcademias.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAcademias.GridColor = Color.Gainsboro;
        }

        private void CarregarDados()
        {
            var lista = _controller.BuscarTodos();
            dgvAcademias.DataSource = lista;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            // Validação de entrada na View - APENAS para os campos do DB Schema
            if (string.IsNullOrWhiteSpace(txtNome.Text)) // Nome é NOT NULL no DB
            {
                MessageBox.Show("O nome da academia é um campo obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var academia = new Academia
            {
                IdAcademia = academiaSelecionadaId ?? 0,
                Nome = txtNome.Text,
                Endereco = txtEndereco.Text,
                Telefone = txtTelefone.Text,
                Email = txtEmail.Text
                // CNPJ, DataAbertura e Status removidos
            };

            try
            {
                _controller.Salvar(academia);
                MessageBox.Show("Academia salva com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
                CarregarDados();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Erro de validação: " + ex.Message, "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar academia: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (academiaSelecionadaId.HasValue)
            {
                DialogResult confirm = MessageBox.Show($"Tem certeza que deseja excluir a academia ID: {academiaSelecionadaId.Value}?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        _controller.Remover(academiaSelecionadaId.Value);
                        MessageBox.Show("Academia excluída com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparCampos();
                        CarregarDados();
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show("Erro de validação: " + ex.Message, "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao excluir academia: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione uma academia para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            academiaSelecionadaId = null;
            txtNome.Clear();
            txtEndereco.Clear();
            txtTelefone.Clear();
            txtEmail.Clear();
            // txtCnpj.Clear();            // Removido
            // dtpDataAbertura.Value = DateTime.Now; // Removido
            // cbStatus.SelectedIndex = -1; // Removido
        }

        private void dgvAcademias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvAcademias.Rows.Count)
            {
                var selectedAcademia = dgvAcademias.Rows[e.RowIndex].DataBoundItem as Academia;

                if (selectedAcademia != null)
                {
                    academiaSelecionadaId = selectedAcademia.IdAcademia;
                    txtNome.Text = selectedAcademia.Nome;
                    txtEndereco.Text = selectedAcademia.Endereco;
                    txtTelefone.Text = selectedAcademia.Telefone;
                    txtEmail.Text = selectedAcademia.Email;
                    // txtCnpj.Text = selectedAcademia.CNPJ; // Removido
                    // dtpDataAbertura.Value = selectedAcademia.DataAbertura; // Removido
                    // cbStatus.SelectedItem = selectedAcademia.Status; // Removido
                }
            }
        }

        // Eventos vazios, caso o designer os crie:
        private void FormAcademia_Load(object sender, EventArgs e) { }
        private void lblNome_Click(object sender, EventArgs e) { }
        // ... outros eventos que o designer possa gerar
    }
}