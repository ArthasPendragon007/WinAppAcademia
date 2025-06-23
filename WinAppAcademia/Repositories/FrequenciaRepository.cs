using System;
using System.Collections.Generic;
using Npgsql;
using WinAppAcademia.Models;
using WinAppAcademia.Utils;

namespace WinAppAcademia.Repositories
{
    internal class FrequenciaRepository
    {
        private readonly string _connectionString;

        public FrequenciaRepository()
        {
            _connectionString = Conexao.ObterStringConexao();
        }

        public void Add(Frequencia frequencia)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            var sql = @"
                INSERT INTO Frequencia (id_aluno, id_aula, data_aula, presenca)
                VALUES (@id_aluno, @id_aula, @data_aula, @presenca);";
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("id_aluno", frequencia.IdAluno);
            cmd.Parameters.AddWithValue("id_aula", frequencia.IdAula);
            cmd.Parameters.AddWithValue("data_aula", frequencia.DataAula.Date);
            cmd.Parameters.AddWithValue("presenca", frequencia.Presenca);
            cmd.ExecuteNonQuery();
        }

        public void Update(Frequencia frequencia)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            var sql = @"
                UPDATE Frequencia
                SET id_aluno = @id_aluno, id_aula = @id_aula, data_aula = @data_aula, presenca = @presenca
                WHERE id_frequencia = @id_frequencia;";
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("id_aluno", frequencia.IdAluno);
            cmd.Parameters.AddWithValue("id_aula", frequencia.IdAula);
            cmd.Parameters.AddWithValue("data_aula", frequencia.DataAula.Date);
            cmd.Parameters.AddWithValue("presenca", frequencia.Presenca);
            cmd.Parameters.AddWithValue("id_frequencia", frequencia.IdFrequencia);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int idFrequencia)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            var sql = "DELETE FROM Frequencia WHERE id_frequencia = @id_frequencia;";
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("id_frequencia", idFrequencia);
            cmd.ExecuteNonQuery();
        }

        public Frequencia GetById(int id)
        {
            Frequencia frequencia = null;
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            string query = @"
                SELECT
                    F.id_frequencia, F.id_aluno, F.id_aula, F.data_aula, F.presenca,
                    A.nome AS nome_aluno,
                    M.nome_modalidade AS nome_modalidade,
                    P.nome AS nome_professor,
                    Aul.dia_semana, Aul.horario_inicio, Aul.horario_fim
                FROM Frequencia F
                JOIN Aluno A ON F.id_aluno = A.id_aluno
                JOIN Aula Aul ON F.id_aula = Aul.id_aula
                JOIN Modalidade M ON Aul.id_modalidade = M.id_modalidade
                JOIN Professor P ON Aul.id_professor = P.id_professor
                WHERE F.id_frequencia = @id_frequencia;";
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("id_frequencia", id);
            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                frequencia = new Frequencia
                {
                    IdFrequencia = reader.GetInt32(reader.GetOrdinal("id_frequencia")),
                    IdAluno = reader.GetInt32(reader.GetOrdinal("id_aluno")),
                    IdAula = reader.GetInt32(reader.GetOrdinal("id_aula")),
                    DataAula = reader.GetDateTime(reader.GetOrdinal("data_aula")),
                    Presenca = reader.GetString(reader.GetOrdinal("presenca")),
                    NomeAluno = reader.GetString(reader.GetOrdinal("nome_aluno")),
                    // Ajuste aqui: Removido o literal 'h' na formatação
                    NomeAula = $"{reader.GetString(reader.GetOrdinal("nome_modalidade"))} ({reader.GetString(reader.GetOrdinal("nome_professor"))} - {reader.GetString(reader.GetOrdinal("dia_semana"))} {reader.GetTimeSpan(reader.GetOrdinal("horario_inicio")):\\hh\\:mm}-{reader.GetTimeSpan(reader.GetOrdinal("horario_fim")):\\hh\\:mm})"
                };
            }
            return frequencia;
        }

        public List<Frequencia> GetAll()
        {
            var lista = new List<Frequencia>();
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            string query = @"
                SELECT
                    F.id_frequencia, F.id_aluno, F.id_aula, F.data_aula, F.presenca,
                    A.nome AS nome_aluno,
                    M.nome_modalidade AS nome_modalidade,
                    P.nome AS nome_professor,
                    Aul.dia_semana, Aul.horario_inicio, Aul.horario_fim
                FROM Frequencia F
                JOIN Aluno A ON F.id_aluno = A.id_aluno
                JOIN Aula Aul ON F.id_aula = Aul.id_aula
                JOIN Modalidade M ON Aul.id_modalidade = M.id_modalidade
                JOIN Professor P ON Aul.id_professor = P.id_professor
                ORDER BY F.data_aula DESC, A.nome ASC;";
            using var cmd = new NpgsqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new Frequencia
                {
                    IdFrequencia = reader.GetInt32(reader.GetOrdinal("id_frequencia")),
                    IdAluno = reader.GetInt32(reader.GetOrdinal("id_aluno")),
                    IdAula = reader.GetInt32(reader.GetOrdinal("id_aula")),
                    DataAula = reader.GetDateTime(reader.GetOrdinal("data_aula")),
                    Presenca = reader.GetString(reader.GetOrdinal("presenca")),
                    NomeAluno = reader.GetString(reader.GetOrdinal("nome_aluno")),
                    // Ajuste aqui: Removido o literal 'h' na formatação
                    NomeAula = $"{reader.GetString(reader.GetOrdinal("nome_modalidade"))} ({reader.GetString(reader.GetOrdinal("nome_professor"))} - {reader.GetString(reader.GetOrdinal("dia_semana"))} {reader.GetTimeSpan(reader.GetOrdinal("horario_inicio")).ToString("hh\\:mm")}-{reader.GetTimeSpan(reader.GetOrdinal("horario_fim")).ToString("hh\\:mm")})"
                });
            }
            return lista;
        }

        public bool Exists(int idAluno, int idAula, DateTime dataAula, int? idFrequenciaExcluir = null)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            string sql = @"
                SELECT COUNT(1)
                FROM Frequencia
                WHERE id_aluno = @id_aluno
                  AND id_aula = @id_aula
                  AND data_aula = @data_aula";

            if (idFrequenciaExcluir.HasValue && idFrequenciaExcluir.Value > 0)
            {
                sql += " AND id_frequencia != @id_frequencia_excluir";
            }

            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("id_aluno", idAluno);
            cmd.Parameters.AddWithValue("id_aula", idAula);
            cmd.Parameters.AddWithValue("data_aula", dataAula.Date);

            if (idFrequenciaExcluir.HasValue && idFrequenciaExcluir.Value > 0)
            {
                cmd.Parameters.AddWithValue("id_frequencia_excluir", idFrequenciaExcluir.Value);
            }

            return (long)cmd.ExecuteScalar() > 0;
        }
    }
}