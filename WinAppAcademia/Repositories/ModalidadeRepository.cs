using System;
using System.Collections.Generic;
using Npgsql; // Usando Npgsql
using WinAppAcademia.Models;
using WinAppAcademia.Utils; // Para Conexao

namespace WinAppAcademia.Repositories
{
    internal class ModalidadeRepository
    {
        private readonly string _connectionString;

        public ModalidadeRepository()
        {
            _connectionString = Conexao.ObterStringConexao();
        }

        public List<Modalidade> GetAll()
        {
            var modalidades = new List<Modalidade>();
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            string query = "SELECT id_modalidade, nome_modalidade, descricao, valor_mensalidade FROM Modalidade;";
            using var cmd = new NpgsqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                modalidades.Add(new Modalidade
                {
                    IdModalidade = reader.GetInt32(reader.GetOrdinal("id_modalidade")),
                    NomeModalidade = reader.GetString(reader.GetOrdinal("nome_modalidade")),
                    Descricao = reader.IsDBNull(reader.GetOrdinal("descricao")) ? null : reader.GetString(reader.GetOrdinal("descricao")),
                    ValorMensalidade = reader.GetDecimal(reader.GetOrdinal("valor_mensalidade"))
                });
            }
            return modalidades;
        }

        public Modalidade GetById(int id)
        {
            Modalidade modalidade = null;
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            string query = "SELECT id_modalidade, nome_modalidade, descricao, valor_mensalidade FROM Modalidade WHERE id_modalidade = @id_modalidade;";
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("id_modalidade", id);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                modalidade = new Modalidade
                {
                    IdModalidade = reader.GetInt32(reader.GetOrdinal("id_modalidade")),
                    NomeModalidade = reader.GetString(reader.GetOrdinal("nome_modalidade")),
                    Descricao = reader.IsDBNull(reader.GetOrdinal("descricao")) ? null : reader.GetString(reader.GetOrdinal("descricao")),
                    ValorMensalidade = reader.GetDecimal(reader.GetOrdinal("valor_mensalidade"))
                };
            }
            return modalidade;
        }

        public void Add(Modalidade modalidade)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            string query = @"
                INSERT INTO Modalidade (nome_modalidade, descricao, valor_mensalidade)
                VALUES (@nome_modalidade, @descricao, @valor_mensalidade);";
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("nome_modalidade", modalidade.NomeModalidade);
            cmd.Parameters.AddWithValue("descricao", (object)modalidade.Descricao ?? DBNull.Value);
            cmd.Parameters.AddWithValue("valor_mensalidade", modalidade.ValorMensalidade);
            cmd.ExecuteNonQuery();
        }

        public void Update(Modalidade modalidade)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            string query = @"
                UPDATE Modalidade
                SET nome_modalidade = @nome_modalidade,
                    descricao = @descricao,
                    valor_mensalidade = @valor_mensalidade
                WHERE id_modalidade = @id_modalidade;";
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("nome_modalidade", modalidade.NomeModalidade);
            cmd.Parameters.AddWithValue("descricao", (object)modalidade.Descricao ?? DBNull.Value);
            cmd.Parameters.AddWithValue("valor_mensalidade", modalidade.ValorMensalidade);
            cmd.Parameters.AddWithValue("id_modalidade", modalidade.IdModalidade);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            string query = "DELETE FROM Modalidade WHERE id_modalidade = @id_modalidade;";
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("id_modalidade", id);
            cmd.ExecuteNonQuery();
        }
    }
}