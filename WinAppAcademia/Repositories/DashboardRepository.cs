using System;
using System.Collections.Generic;
using Npgsql; // Usar Npgsql diretamente
using WinAppAcademia.Models;
using WinAppAcademia.Utils; // Para Conexao.ObterStringConexao()

namespace WinAppAcademia.Repositories
{
    internal class DashboardRepository
    {
        private readonly string _connectionString;

        public DashboardRepository()
        {
            _connectionString = Conexao.ObterStringConexao(); // Usando a classe de conexão fornecida
        }

        // --- Views ---

        public List<AlunoAtivoModalidadeView> GetAlunosAtivosModalidades()
        {
            var lista = new List<AlunoAtivoModalidadeView>();
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            var sql = "SELECT aluno_nome, nome_modalidade, status_matricula FROM vw_alunos_ativos_modalidades";
            using var cmd = new NpgsqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new AlunoAtivoModalidadeView
                {
                    AlunoNome = reader.GetString(reader.GetOrdinal("aluno_nome")),
                    NomeModalidade = reader.GetString(reader.GetOrdinal("nome_modalidade")),
                    StatusMatricula = reader.GetString(reader.GetOrdinal("status_matricula"))
                });
            }
            return lista;
        }

        public List<FrequenciaPorAulaView> GetFrequenciaPorAula()
        {
            var lista = new List<FrequenciaPorAulaView>();
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            // A view original não inclui nomes, então fazemos JOINs aqui para enriquecer os dados para a UI
            var sql = @"
                SELECT
                    f.id_aula AS IdAula,
                    COUNT(CASE WHEN f.presenca = 'sim' THEN 1 END) AS TotalPresentes,
                    p.id_professor AS IdProfessor,
                    p.nome AS NomeProfessor,
                    m.nome_modalidade AS NomeAula
                FROM
                    Frequencia f
                JOIN
                    Aula a ON f.id_aula = a.id_aula
                JOIN
                    Professor p ON a.id_professor = p.id_professor
                JOIN
                    Modalidade m ON a.id_modalidade = m.id_modalidade
                GROUP BY
                    f.id_aula, p.id_professor, p.nome, m.nome_modalidade
                ORDER BY
                    m.nome_modalidade, p.nome;";

            using var cmd = new NpgsqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new FrequenciaPorAulaView
                {
                    IdAula = reader.GetInt32(reader.GetOrdinal("IdAula")),
                    TotalPresentes = reader.GetInt32(reader.GetOrdinal("TotalPresentes")),
                    IdProfessor = reader.GetInt32(reader.GetOrdinal("IdProfessor")),
                    NomeProfessor = reader.GetString(reader.GetOrdinal("NomeProfessor")),
                    NomeAula = reader.GetString(reader.GetOrdinal("NomeAula"))
                });
            }
            return lista;
        }

        public List<PagamentoPendenteView> GetPagamentosPendentes()
        {
            var lista = new List<PagamentoPendenteView>();
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            var sql = "SELECT id_aluno, aluno_nome, valor, data_pagamento FROM vw_pagamentos_pendentes";
            using var cmd = new NpgsqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new PagamentoPendenteView
                {
                    IdAluno = reader.GetInt32(reader.GetOrdinal("id_aluno")),
                    AlunoNome = reader.GetString(reader.GetOrdinal("aluno_nome")),
                    Valor = reader.GetDecimal(reader.GetOrdinal("valor")),
                    DataPagamento = reader.GetDateTime(reader.GetOrdinal("data_pagamento"))
                });
            }
            return lista;
        }

        // --- Procedures ---

        public void RegistrarPagamento(int idAluno, decimal valor, DateTime data)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            using var cmd = new NpgsqlCommand("CALL registrar_pagamento(@p_id_aluno, @p_valor, @p_data);", conn);
            cmd.Parameters.AddWithValue("p_id_aluno", idAluno);
            cmd.Parameters.AddWithValue("p_valor", valor);
            cmd.Parameters.AddWithValue("p_data", NpgsqlTypes.NpgsqlDbType.Date, data.Date);
            cmd.ExecuteNonQuery();
        }


        public void AtualizarStatusMatricula(int idMatricula, string status)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            var sql = "CALL atualizar_status_matricula(@p_id_matricula, @p_status);";
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("p_id_matricula", idMatricula);
            cmd.Parameters.AddWithValue("p_status", status);
            cmd.ExecuteNonQuery();
        }

        // --- Functions ---

        public decimal CalcularTotalPagoPorAluno(int idAluno)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            // Para chamar funções que retornam um único valor, use ExecuteScalar
            var sql = "SELECT total_pago_por_aluno(@p_id_aluno);";
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("p_id_aluno", idAluno);
            object result = cmd.ExecuteScalar();
            return (result == DBNull.Value || result == null) ? 0 : Convert.ToDecimal(result);
        }
    }
}