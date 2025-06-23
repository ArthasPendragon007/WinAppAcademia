using System;
using System.Collections.Generic;
using Npgsql; // Usando Npgsql
using WinAppAcademia.Models;
using WinAppAcademia.Utils; // Para Conexao

namespace WinAppAcademia.Repositories
{
    internal class MatriculaRepository
    {
        private readonly string _connectionString;

        public MatriculaRepository()
        {
            _connectionString = Conexao.ObterStringConexao();
        }

        public List<Matricula> GetAll()
        {
            var matriculas = new List<Matricula>();
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            string query = @"
                SELECT
                    m.id_matricula,
                    m.id_aluno,
                    m.id_modalidade,
                    m.data_inicio,
                    m.data_fim,
                    m.status_matricula,
                    a.nome AS nome_aluno,
                    mod.nome_modalidade
                FROM Matricula m
                JOIN Aluno a ON m.id_aluno = a.id_aluno
                JOIN Modalidade mod ON m.id_modalidade = mod.id_modalidade;";
            using var cmd = new NpgsqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                matriculas.Add(new Matricula
                {
                    IdMatricula = reader.GetInt32(reader.GetOrdinal("id_matricula")),
                    IdAluno = reader.GetInt32(reader.GetOrdinal("id_aluno")),
                    IdModalidade = reader.GetInt32(reader.GetOrdinal("id_modalidade")),
                    DataInicio = reader.GetDateTime(reader.GetOrdinal("data_inicio")),
                    DataFim = reader.IsDBNull(reader.GetOrdinal("data_fim")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("data_fim")),
                    StatusMatricula = reader.GetString(reader.GetOrdinal("status_matricula")),
                    NomeAluno = reader.GetString(reader.GetOrdinal("nome_aluno")),
                    NomeModalidade = reader.GetString(reader.GetOrdinal("nome_modalidade"))
                });
            }
            return matriculas;
        }

        public Matricula GetById(int id)
        {
            Matricula matricula = null;
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            string query = @"
                SELECT
                    m.id_matricula,
                    m.id_aluno,
                    m.id_modalidade,
                    m.data_inicio,
                    m.data_fim,
                    m.status_matricula,
                    a.nome AS nome_aluno,
                    mod.nome_modalidade
                FROM Matricula m
                JOIN Aluno a ON m.id_aluno = a.id_aluno
                JOIN Modalidade mod ON m.id_modalidade = mod.id_modalidade
                WHERE m.id_matricula = @id_matricula;";
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("id_matricula", id);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                matricula = new Matricula
                {
                    IdMatricula = reader.GetInt32(reader.GetOrdinal("id_matricula")),
                    IdAluno = reader.GetInt32(reader.GetOrdinal("id_aluno")),
                    IdModalidade = reader.GetInt32(reader.GetOrdinal("id_modalidade")),
                    DataInicio = reader.GetDateTime(reader.GetOrdinal("data_inicio")),
                    DataFim = reader.IsDBNull(reader.GetOrdinal("data_fim")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("data_fim")),
                    StatusMatricula = reader.GetString(reader.GetOrdinal("status_matricula")),
                    NomeAluno = reader.GetString(reader.GetOrdinal("nome_aluno")),
                    NomeModalidade = reader.GetString(reader.GetOrdinal("nome_modalidade"))
                };
            }
            return matricula;
        }

        public void Add(Matricula matricula)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            string query = @"
                INSERT INTO Matricula (id_aluno, id_modalidade, data_inicio, data_fim, status_matricula)
                VALUES (@id_aluno, @id_modalidade, @data_inicio, @data_fim, @status_matricula);";
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("id_aluno", matricula.IdAluno);
            cmd.Parameters.AddWithValue("id_modalidade", matricula.IdModalidade);
            cmd.Parameters.AddWithValue("data_inicio", matricula.DataInicio);
            cmd.Parameters.AddWithValue("data_fim", (object)matricula.DataFim ?? DBNull.Value);
            cmd.Parameters.AddWithValue("status_matricula", matricula.StatusMatricula);
            cmd.ExecuteNonQuery();
        }

        public void Update(Matricula matricula)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            string query = @"
                UPDATE Matricula
                SET id_aluno = @id_aluno,
                    id_modalidade = @id_modalidade,
                    data_inicio = @data_inicio,
                    data_fim = @data_fim,
                    status_matricula = @status_matricula
                WHERE id_matricula = @id_matricula;";
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("id_aluno", matricula.IdAluno);
            cmd.Parameters.AddWithValue("id_modalidade", matricula.IdModalidade);
            cmd.Parameters.AddWithValue("data_inicio", matricula.DataInicio);
            cmd.Parameters.AddWithValue("data_fim", (object)matricula.DataFim ?? DBNull.Value);
            cmd.Parameters.AddWithValue("status_matricula", matricula.StatusMatricula);
            cmd.Parameters.AddWithValue("id_matricula", matricula.IdMatricula);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            string query = "DELETE FROM Matricula WHERE id_matricula = @id_matricula;";
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("id_matricula", id);
            cmd.ExecuteNonQuery();
        }
    }
}