using System;
using System.Collections.Generic;
using Npgsql; // Usando Npgsql
using WinAppAcademia.Models;
using WinAppAcademia.Utils; // Para Conexao

namespace WinAppAcademia.Repositories
{
    internal class EquipamentoRepository
    {
        private readonly string _connectionString;

        public EquipamentoRepository()
        {
            _connectionString = Conexao.ObterStringConexao();
        }

        public List<Equipamento> GetAll()
        {
            var equipamentos = new List<Equipamento>();
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            string query = @"
                SELECT
                    e.id_equipamento,
                    e.id_academia,
                    e.nome,
                    e.descricao,
                    e.data_aquisicao,
                    e.estado,
                    a.nome AS nome_academia
                FROM Equipamento e
                JOIN Academia a ON e.id_academia = a.id_academia;";
            using var cmd = new NpgsqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                equipamentos.Add(new Equipamento
                {
                    IdEquipamento = reader.GetInt32(reader.GetOrdinal("id_equipamento")),
                    IdAcademia = reader.GetInt32(reader.GetOrdinal("id_academia")),
                    Nome = reader.GetString(reader.GetOrdinal("nome")),
                    Descricao = reader.IsDBNull(reader.GetOrdinal("descricao")) ? null : reader.GetString(reader.GetOrdinal("descricao")),
                    DataAquisicao = reader.IsDBNull(reader.GetOrdinal("data_aquisicao")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("data_aquisicao")),
                    Estado = reader.GetString(reader.GetOrdinal("estado")),
                    NomeAcademia = reader.GetString(reader.GetOrdinal("nome_academia"))
                });
            }
            return equipamentos;
        }

        public Equipamento GetById(int id)
        {
            Equipamento equipamento = null;
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            string query = @"
                SELECT
                    e.id_equipamento,
                    e.id_academia,
                    e.nome,
                    e.descricao,
                    e.data_aquisicao,
                    e.estado,
                    a.nome AS nome_academia
                FROM Equipamento e
                JOIN Academia a ON e.id_academia = a.id_academia
                WHERE e.id_equipamento = @id_equipamento;";
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("id_equipamento", id);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                equipamento = new Equipamento
                {
                    IdEquipamento = reader.GetInt32(reader.GetOrdinal("id_equipamento")),
                    IdAcademia = reader.GetInt32(reader.GetOrdinal("id_academia")),
                    Nome = reader.GetString(reader.GetOrdinal("nome")),
                    Descricao = reader.IsDBNull(reader.GetOrdinal("descricao")) ? null : reader.GetString(reader.GetOrdinal("descricao")),
                    DataAquisicao = reader.IsDBNull(reader.GetOrdinal("data_aquisicao")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("data_aquisicao")),
                    Estado = reader.GetString(reader.GetOrdinal("estado")),
                    NomeAcademia = reader.GetString(reader.GetOrdinal("nome_academia"))
                };
            }
            return equipamento;
        }

        public void Add(Equipamento equipamento)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            string query = @"
                INSERT INTO Equipamento (id_academia, nome, descricao, data_aquisicao, estado)
                VALUES (@id_academia, @nome, @descricao, @data_aquisicao, @estado);";
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("id_academia", equipamento.IdAcademia);
            cmd.Parameters.AddWithValue("nome", equipamento.Nome);
            cmd.Parameters.AddWithValue("descricao", (object)equipamento.Descricao ?? DBNull.Value);
            cmd.Parameters.AddWithValue("data_aquisicao", (object)equipamento.DataAquisicao ?? DBNull.Value);
            cmd.Parameters.AddWithValue("estado", equipamento.Estado);
            cmd.ExecuteNonQuery();
        }

        public void Update(Equipamento equipamento)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            string query = @"
                UPDATE Equipamento
                SET id_academia = @id_academia,
                    nome = @nome,
                    descricao = @descricao,
                    data_aquisicao = @data_aquisicao,
                    estado = @estado
                WHERE id_equipamento = @id_equipamento;";
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("id_academia", equipamento.IdAcademia);
            cmd.Parameters.AddWithValue("nome", equipamento.Nome);
            cmd.Parameters.AddWithValue("descricao", (object)equipamento.Descricao ?? DBNull.Value);
            cmd.Parameters.AddWithValue("data_aquisicao", (object)equipamento.DataAquisicao ?? DBNull.Value);
            cmd.Parameters.AddWithValue("estado", equipamento.Estado);
            cmd.Parameters.AddWithValue("id_equipamento", equipamento.IdEquipamento);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            string query = "DELETE FROM Equipamento WHERE id_equipamento = @id_equipamento;";
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("id_equipamento", id);
            cmd.ExecuteNonQuery();
        }
    }
}