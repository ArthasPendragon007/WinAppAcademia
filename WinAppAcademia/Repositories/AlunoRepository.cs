using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using WinAppAcademia.Models;
using WinAppAcademia.Utils;

namespace WinAppAcademia.Repositories
{
    internal class AlunoRepository
    {
        private readonly string _connectionString;

        public AlunoRepository()
        {
            _connectionString = Conexao.ObterStringConexao();
        }

        public List<Aluno> GetAll()
        {
            var lista = new List<Aluno>();
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            using var cmd = new NpgsqlCommand("SELECT * FROM Aluno ORDER BY id_aluno", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Aluno
                {
                    IdAluno = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    CPF = reader.GetString(2),
                    DataNascimento = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3),
                    Sexo = reader.IsDBNull(4) ? "" : reader.GetString(4),
                    Telefone = reader.IsDBNull(5) ? "" : reader.GetString(5),
                    Email = reader.IsDBNull(6) ? "" : reader.GetString(6),
                    DataMatricula = reader.IsDBNull(7) ? DateTime.MinValue : reader.GetDateTime(7),
                    Status = reader.GetString(8)
                });
            }

            return lista;
        }

        public Aluno GetById(int id)
        {
            Aluno Aluno = null;
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            string query = @"
                SELECT
                    a.Id,
                    a.nome,
                    a.cpf,
                    a.data_nascimento,
                    a.sexo,
                    a.telefone,
                    m.email,
                    a.data_matricula
                    a.status
                FROM Aluno a
                WHERE a.id_aula = @Id";
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("id_aula", id);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Aluno = new Aluno
                {
                    IdAluno = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    CPF = reader.GetString(2),
                    DataNascimento = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3),
                    Sexo = reader.IsDBNull(4) ? "" : reader.GetString(4),
                    Telefone = reader.IsDBNull(5) ? "" : reader.GetString(5),
                    Email = reader.IsDBNull(6) ? "" : reader.GetString(6),
                    DataMatricula = reader.IsDBNull(7) ? DateTime.MinValue : reader.GetDateTime(7),
                    Status = reader.GetString(8)
                };
            }
            return Aluno;
        }
     

        public void Add(Aluno aluno)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            var sql = @"INSERT INTO Aluno (nome, cpf, data_nascimento, sexo, telefone, email, data_matricula, status)
                        VALUES (@nome, @cpf, @data_nascimento, @sexo, @telefone, @email, @data_matricula, @status)";
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("nome", aluno.Nome);
            cmd.Parameters.AddWithValue("cpf", aluno.CPF);
            cmd.Parameters.AddWithValue("data_nascimento", aluno.DataNascimento);
            cmd.Parameters.AddWithValue("sexo", aluno.Sexo ?? "");
            cmd.Parameters.AddWithValue("telefone", aluno.Telefone ?? "");
            cmd.Parameters.AddWithValue("email", aluno.Email ?? "");
            cmd.Parameters.AddWithValue("data_matricula", aluno.DataMatricula);
            cmd.Parameters.AddWithValue("status", aluno.Status);
            cmd.ExecuteNonQuery();
        }

        public void Update(Aluno aluno)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            var sql = @"UPDATE Aluno SET nome = @nome, cpf = @cpf, data_nascimento = @data_nascimento,
            sexo = @sexo, telefone = @telefone, email = @email, data_matricula = @data_matricula,
            status = @status WHERE id_aluno = @id";
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("id", aluno.IdAluno);
            cmd.Parameters.AddWithValue("nome", aluno.Nome);
            cmd.Parameters.AddWithValue("cpf", aluno.CPF);
            cmd.Parameters.AddWithValue("data_nascimento", aluno.DataNascimento);
            cmd.Parameters.AddWithValue("sexo", aluno.Sexo ?? "");
            cmd.Parameters.AddWithValue("telefone", aluno.Telefone ?? "");
            cmd.Parameters.AddWithValue("email", aluno.Email ?? "");
            cmd.Parameters.AddWithValue("data_matricula", aluno.DataMatricula);
            cmd.Parameters.AddWithValue("status", aluno.Status);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int idAluno)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            var sql = "DELETE FROM Aluno WHERE id_aluno = @id";
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("id", idAluno);
            cmd.ExecuteNonQuery();
        }
    }
}


