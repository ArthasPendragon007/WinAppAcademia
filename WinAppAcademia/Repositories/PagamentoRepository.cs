using System;
using System.Collections.Generic;
using Npgsql; // Usando Npgsql
using WinAppAcademia.Models;
using WinAppAcademia.Utils; // Para Conexao

namespace WinAppAcademia.Repositories
{
    internal class PagamentoRepository
    {
        private readonly string _connectionString;

        public PagamentoRepository()
        {
            _connectionString = Conexao.ObterStringConexao();
        }

        public List<Pagamento> GetAll()
        {
            var pagamentos = new List<Pagamento>();
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            string query = @"
                SELECT
                    p.id_pagamento,
                    p.id_aluno,
                    p.data_pagamento,
                    p.valor,
                    p.status_pagamento,
                    a.nome AS nome_aluno
                FROM Pagamento p
                JOIN Aluno a ON p.id_aluno = a.id_aluno;";
            using var cmd = new NpgsqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                pagamentos.Add(new Pagamento
                {
                    IdPagamento = reader.GetInt32(reader.GetOrdinal("id_pagamento")),
                    IdAluno = reader.GetInt32(reader.GetOrdinal("id_aluno")),
                    DataPagamento = reader.GetDateTime(reader.GetOrdinal("data_pagamento")),
                    Valor = reader.GetDecimal(reader.GetOrdinal("valor")),
                    StatusPagamento = reader.GetString(reader.GetOrdinal("status_pagamento")),
                    NomeAluno = reader.GetString(reader.GetOrdinal("nome_aluno"))
                });
            }
            return pagamentos;
        }

        public Pagamento GetById(int id)
        {
            Pagamento pagamento = null;
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            string query = @"
                SELECT
                    p.id_pagamento,
                    p.id_aluno,
                    p.data_pagamento,
                    p.valor,
                    p.status_pagamento,
                    a.nome AS nome_aluno
                FROM Pagamento p
                JOIN Aluno a ON p.id_aluno = a.id_aluno
                WHERE p.id_pagamento = @id_pagamento;";
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("id_pagamento", id);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                pagamento = new Pagamento
                {
                    IdPagamento = reader.GetInt32(reader.GetOrdinal("id_pagamento")),
                    IdAluno = reader.GetInt32(reader.GetOrdinal("id_aluno")),
                    DataPagamento = reader.GetDateTime(reader.GetOrdinal("data_pagamento")),
                    Valor = reader.GetDecimal(reader.GetOrdinal("valor")),
                    StatusPagamento = reader.GetString(reader.GetOrdinal("status_pagamento")),
                    NomeAluno = reader.GetString(reader.GetOrdinal("nome_aluno"))
                };
            }
            return pagamento;
        }

        public void Add(Pagamento pagamento)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            string query = @"
                INSERT INTO Pagamento (id_aluno, data_pagamento, valor, status_pagamento)
                VALUES (@id_aluno, @data_pagamento, @valor, @status_pagamento);";
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("id_aluno", pagamento.IdAluno);
            cmd.Parameters.AddWithValue("data_pagamento", pagamento.DataPagamento);
            cmd.Parameters.AddWithValue("valor", pagamento.Valor);
            cmd.Parameters.AddWithValue("status_pagamento", pagamento.StatusPagamento);
            cmd.ExecuteNonQuery();
        }

        public void Update(Pagamento pagamento)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            string query = @"
                UPDATE Pagamento
                SET id_aluno = @id_aluno,
                    data_pagamento = @data_pagamento,
                    valor = @valor,
                    status_pagamento = @status_pagamento
                WHERE id_pagamento = @id_pagamento;";
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("id_aluno", pagamento.IdAluno);
            cmd.Parameters.AddWithValue("data_pagamento", pagamento.DataPagamento);
            cmd.Parameters.AddWithValue("valor", pagamento.Valor);
            cmd.Parameters.AddWithValue("status_pagamento", pagamento.StatusPagamento);
            cmd.Parameters.AddWithValue("id_pagamento", pagamento.IdPagamento);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            string query = "DELETE FROM Pagamento WHERE id_pagamento = @id_pagamento;";
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("id_pagamento", id);
            cmd.ExecuteNonQuery();
        }
    }
}