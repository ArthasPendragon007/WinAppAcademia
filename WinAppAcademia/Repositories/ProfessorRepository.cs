using System;
using System.Collections.Generic;
using Npgsql; // Usando Npgsql
using WinAppAcademia.Models;
using WinAppAcademia.Utils; // Para Conexao

namespace WinAppAcademia.Repositories
{
    internal class ProfessorRepository
    {
        private readonly string _connectionString;

        public ProfessorRepository()
        {
            _connectionString = Conexao.ObterStringConexao();
        }

        public List<Professor> GetAll()
        {
            var professores = new List<Professor>();
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            string query = @"
                SELECT
                    p.id_professor,
                    p.id_academia,
                    p.id_modalidade,
                    p.nome,
                    p.cpf,
                    p.data_nascimento,
                    p.sexo,
                    p.telefone,
                    p.email,
                    ac.nome AS nome_academia,
                    m.nome_modalidade
                FROM Professor p
                JOIN Academia ac ON p.id_academia = ac.id_academia
                JOIN Modalidade m ON p.id_modalidade = m.id_modalidade;";
            using var cmd = new NpgsqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                professores.Add(new Professor
                {
                    IdProfessor = reader.GetInt32(reader.GetOrdinal("id_professor")),
                    IdAcademia = reader.GetInt32(reader.GetOrdinal("id_academia")),
                    IdModalidade = reader.GetInt32(reader.GetOrdinal("id_modalidade")),
                    Nome = reader.GetString(reader.GetOrdinal("nome")),
                    Cpf = reader.GetString(reader.GetOrdinal("cpf")),
                    DataNascimento = reader.IsDBNull(reader.GetOrdinal("data_nascimento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("data_nascimento")),
                    Sexo = reader.IsDBNull(reader.GetOrdinal("sexo")) ? (char?)null : reader.GetString(reader.GetOrdinal("sexo"))[0],
                    Telefone = reader.IsDBNull(reader.GetOrdinal("telefone")) ? null : reader.GetString(reader.GetOrdinal("telefone")),
                    Email = reader.IsDBNull(reader.GetOrdinal("email")) ? null : reader.GetString(reader.GetOrdinal("email")),
                    NomeAcademia = reader.GetString(reader.GetOrdinal("nome_academia")),
                    NomeModalidade = reader.GetString(reader.GetOrdinal("nome_modalidade"))
                });
            }
            return professores;
        }

        public Professor GetById(int id)
        {
            Professor professor = null;
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            string query = @"
                SELECT
                    p.id_professor,
                    p.id_academia,
                    p.id_modalidade,
                    p.nome,
                    p.cpf,
                    p.data_nascimento,
                    p.sexo,
                    p.telefone,
                    p.email,
                    ac.nome AS nome_academia,
                    m.nome_modalidade
                FROM Professor p
                JOIN Academia ac ON p.id_academia = ac.id_academia
                JOIN Modalidade m ON p.id_modalidade = m.id_modalidade
                WHERE p.id_professor = @id_professor;";
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("id_professor", id);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                professor = new Professor
                {
                    IdProfessor = reader.GetInt32(reader.GetOrdinal("id_professor")),
                    IdAcademia = reader.GetInt32(reader.GetOrdinal("id_academia")),
                    IdModalidade = reader.GetInt32(reader.GetOrdinal("id_modalidade")),
                    Nome = reader.GetString(reader.GetOrdinal("nome")),
                    Cpf = reader.GetString(reader.GetOrdinal("cpf")),
                    DataNascimento = reader.IsDBNull(reader.GetOrdinal("data_nascimento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("data_nascimento")),
                    Sexo = reader.IsDBNull(reader.GetOrdinal("sexo")) ? (char?)null : reader.GetString(reader.GetOrdinal("sexo"))[0],
                    Telefone = reader.IsDBNull(reader.GetOrdinal("telefone")) ? null : reader.GetString(reader.GetOrdinal("telefone")),
                    Email = reader.IsDBNull(reader.GetOrdinal("email")) ? null : reader.GetString(reader.GetOrdinal("email")),
                    NomeAcademia = reader.GetString(reader.GetOrdinal("nome_academia")),
                    NomeModalidade = reader.GetString(reader.GetOrdinal("nome_modalidade"))
                };
            }
            return professor;
        }

        public void Add(Professor professor)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            string query = @"
                INSERT INTO Professor (id_academia, id_modalidade, nome, cpf, data_nascimento, sexo, telefone, email)
                VALUES (@id_academia, @id_modalidade, @nome, @cpf, @data_nascimento, @sexo, @telefone, @email);";
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("id_academia", professor.IdAcademia);
            cmd.Parameters.AddWithValue("id_modalidade", professor.IdModalidade);
            cmd.Parameters.AddWithValue("nome", professor.Nome);
            cmd.Parameters.AddWithValue("cpf", professor.Cpf);
            cmd.Parameters.AddWithValue("data_nascimento", (object)professor.DataNascimento ?? DBNull.Value);
            cmd.Parameters.AddWithValue("sexo", professor.Sexo.HasValue ? professor.Sexo.ToString() : (object)DBNull.Value);
            cmd.Parameters.AddWithValue("telefone", (object)professor.Telefone ?? DBNull.Value);
            cmd.Parameters.AddWithValue("email", (object)professor.Email ?? DBNull.Value);
            cmd.ExecuteNonQuery();
        }

        public void Update(Professor professor)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            string query = @"
                UPDATE Professor
                SET id_academia = @id_academia,
                    id_modalidade = @id_modalidade,
                    nome = @nome,
                    cpf = @cpf,
                    data_nascimento = @data_nascimento,
                    sexo = @sexo,
                    telefone = @telefone,
                    email = @email
                WHERE id_professor = @id_professor;";
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("id_academia", professor.IdAcademia);
            cmd.Parameters.AddWithValue("id_modalidade", professor.IdModalidade);
            cmd.Parameters.AddWithValue("nome", professor.Nome);
            cmd.Parameters.AddWithValue("cpf", professor.Cpf);
            cmd.Parameters.AddWithValue("data_nascimento", (object)professor.DataNascimento ?? DBNull.Value);
            cmd.Parameters.AddWithValue("sexo", professor.Sexo.HasValue ? professor.Sexo.ToString() : (object)DBNull.Value);
            cmd.Parameters.AddWithValue("telefone", (object)professor.Telefone ?? DBNull.Value);
            cmd.Parameters.AddWithValue("email", (object)professor.Email ?? DBNull.Value);
            cmd.Parameters.AddWithValue("id_professor", professor.IdProfessor);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            string query = "DELETE FROM Professor WHERE id_professor = @id_professor;";
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("id_professor", id);
            cmd.ExecuteNonQuery();
        }
    }
}