using System;
using System.Collections.Generic;
using Npgsql; // Usando Npgsql
using WinAppAcademia.Models;
using WinAppAcademia.Utils; // Para Conexao

namespace WinAppAcademia.Repositories
{
    internal class AcademiaRepository
    {
        private readonly string _connectionString;

        public AcademiaRepository()
        {
            _connectionString = Conexao.ObterStringConexao();
        }

        public List<Academia> GetAll()
        {
            var academias = new List<Academia>();
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            string query = "SELECT id_academia, nome, endereco, telefone, email FROM Academia;";
            using var cmd = new NpgsqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                academias.Add(new Academia
                {
                    IdAcademia = reader.GetInt32(reader.GetOrdinal("id_academia")),
                    Nome = reader.GetString(reader.GetOrdinal("nome")),
                    Endereco = reader.IsDBNull(reader.GetOrdinal("endereco")) ? null : reader.GetString(reader.GetOrdinal("endereco")),
                    Telefone = reader.IsDBNull(reader.GetOrdinal("telefone")) ? null : reader.GetString(reader.GetOrdinal("telefone")),
                    Email = reader.IsDBNull(reader.GetOrdinal("email")) ? null : reader.GetString(reader.GetOrdinal("email"))
                });
            }
            return academias;
        }

        public Academia GetById(int id)
        {
            Academia academia = null;
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            string query = "SELECT id_academia, nome, endereco, telefone, email FROM Academia WHERE id_academia = @id_academia;";
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("id_academia", id);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                academia = new Academia
                {
                    IdAcademia = reader.GetInt32(reader.GetOrdinal("id_academia")),
                    Nome = reader.GetString(reader.GetOrdinal("nome")),
                    Endereco = reader.IsDBNull(reader.GetOrdinal("endereco")) ? null : reader.GetString(reader.GetOrdinal("endereco")),
                    Telefone = reader.IsDBNull(reader.GetOrdinal("telefone")) ? null : reader.GetString(reader.GetOrdinal("telefone")),
                    Email = reader.IsDBNull(reader.GetOrdinal("email")) ? null : reader.GetString(reader.GetOrdinal("email"))
                };
            }
            return academia;
        }

        public void Add(Academia academia)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            string query = @"
                INSERT INTO Academia (nome, endereco, telefone, email)
                VALUES (@nome, @endereco, @telefone, @email);";
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("nome", academia.Nome);
            cmd.Parameters.AddWithValue("endereco", (object)academia.Endereco ?? DBNull.Value);
            cmd.Parameters.AddWithValue("telefone", (object)academia.Telefone ?? DBNull.Value);
            cmd.Parameters.AddWithValue("email", (object)academia.Email ?? DBNull.Value);
            cmd.ExecuteNonQuery();
        }

        public void Update(Academia academia)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            string query = @"
                UPDATE Academia
                SET nome = @nome,
                    endereco = @endereco,
                    telefone = @telefone,
                    email = @email
                WHERE id_academia = @id_academia;";
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("nome", academia.Nome);
            cmd.Parameters.AddWithValue("endereco", (object)academia.Endereco ?? DBNull.Value);
            cmd.Parameters.AddWithValue("telefone", (object)academia.Telefone ?? DBNull.Value);
            cmd.Parameters.AddWithValue("email", (object)academia.Email ?? DBNull.Value);
            cmd.Parameters.AddWithValue("id_academia", academia.IdAcademia);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            string query = "DELETE FROM Academia WHERE id_academia = @id_academia;";
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("id_academia", id);
            cmd.ExecuteNonQuery();
        }
    }
}