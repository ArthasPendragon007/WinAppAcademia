using System;
using System.Collections.Generic;
using Npgsql;
using WinAppAcademia.Models;
using WinAppAcademia.Utils;

namespace WinAppAcademia.Repositories
{
    internal class AulaRepository
    {
        private readonly string _connectionString;

        public AulaRepository()
        {
            _connectionString = Conexao.ObterStringConexao();
        }

        public List<Aula> GetAll()
        {
            var aulas = new List<Aula>();
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            string query = @"
                    SELECT
                        a.id_aula AS IdAula,
                        a.id_modalidade AS IdModalidade,
                        a.id_academia AS IdAcademia,
                        a.id_professor AS IdProfessor,
                        a.dia_semana AS DiaSemana,
                        a.horario_inicio AS HorarioInicio,
                        a.horario_fim AS HorarioFim,
                        a.capacidade_maxima AS CapacidadeMaxima,
                        m.nome_modalidade AS NomeModalidade,
                        ac.nome AS NomeAcademia,
                        p.nome AS NomeProfessor
                    FROM
                        Aula a
                    JOIN
                        Modalidade m ON a.id_modalidade = m.id_modalidade
                    JOIN
                        Academia ac ON a.id_academia = ac.id_academia
                    JOIN
                        Professor p ON a.id_professor = p.id_professor
                    ORDER BY a.dia_semana, a.horario_inicio;";
            using var cmd = new NpgsqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                aulas.Add(new Aula
                {
                    // CORREÇÃO AQUI: Usar os nomes dos ALIAS definidos na query SELECT
                    IdAula = reader.GetInt32(reader.GetOrdinal("IdAula")),
                    IdModalidade = reader.GetInt32(reader.GetOrdinal("IdModalidade")),
                    IdAcademia = reader.GetInt32(reader.GetOrdinal("IdAcademia")),
                    IdProfessor = reader.GetInt32(reader.GetOrdinal("IdProfessor")),
                    DiaSemana = reader.IsDBNull(reader.GetOrdinal("DiaSemana")) ? null : reader.GetString(reader.GetOrdinal("DiaSemana")),
                    HorarioInicio = reader.IsDBNull(reader.GetOrdinal("HorarioInicio")) ? (TimeSpan?)null : reader.GetTimeSpan(reader.GetOrdinal("HorarioInicio")),
                    HorarioFim = reader.IsDBNull(reader.GetOrdinal("HorarioFim")) ? (TimeSpan?)null : reader.GetTimeSpan(reader.GetOrdinal("HorarioFim")),
                    CapacidadeMaxima = reader.IsDBNull(reader.GetOrdinal("CapacidadeMaxima")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("CapacidadeMaxima")),
                    NomeModalidade = reader.GetString(reader.GetOrdinal("NomeModalidade")),
                    NomeAcademia = reader.GetString(reader.GetOrdinal("NomeAcademia")),
                    NomeProfessor = reader.GetString(reader.GetOrdinal("NomeProfessor")) // Adicionado
                });
            }
            return aulas;
        }

        public Aula GetById(int id)
        {
            Aula aula = null;
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            string query = @"
                    SELECT
                        a.id_aula AS IdAula,
                        a.id_modalidade AS IdModalidade,
                        a.id_academia AS IdAcademia,
                        a.id_professor AS IdProfessor,
                        a.dia_semana AS DiaSemana,
                        a.horario_inicio AS HorarioInicio,
                        a.horario_fim AS HorarioFim,
                        a.capacidade_maxima AS CapacidadeMaxima,
                        m.nome_modalidade AS NomeModalidade,
                        ac.nome AS NomeAcademia,
                        p.nome AS NomeProfessor
                    FROM
                        Aula a
                    JOIN
                        Modalidade m ON a.id_modalidade = m.id_modalidade
                    JOIN
                        Academia ac ON a.id_academia = ac.id_academia
                    JOIN
                        Professor p ON a.id_professor = p.id_professor
                    WHERE
                        a.id_aula = @id_aula;"; // Usar o nome do parâmetro exato aqui
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("id_aula", id); // Nome do parâmetro aqui
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                aula = new Aula
                {
                    // CORREÇÃO AQUI: Usar os nomes dos ALIAS definidos na query SELECT
                    IdAula = reader.GetInt32(reader.GetOrdinal("IdAula")),
                    IdModalidade = reader.GetInt32(reader.GetOrdinal("IdModalidade")),
                    IdAcademia = reader.GetInt32(reader.GetOrdinal("IdAcademia")),
                    IdProfessor = reader.GetInt32(reader.GetOrdinal("IdProfessor")),
                    DiaSemana = reader.IsDBNull(reader.GetOrdinal("DiaSemana")) ? null : reader.GetString(reader.GetOrdinal("DiaSemana")),
                    HorarioInicio = reader.IsDBNull(reader.GetOrdinal("HorarioInicio")) ? (TimeSpan?)null : reader.GetTimeSpan(reader.GetOrdinal("HorarioInicio")),
                    HorarioFim = reader.IsDBNull(reader.GetOrdinal("HorarioFim")) ? (TimeSpan?)null : reader.GetTimeSpan(reader.GetOrdinal("HorarioFim")),
                    CapacidadeMaxima = reader.IsDBNull(reader.GetOrdinal("CapacidadeMaxima")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("CapacidadeMaxima")),
                    NomeModalidade = reader.GetString(reader.GetOrdinal("NomeModalidade")),
                    NomeAcademia = reader.GetString(reader.GetOrdinal("NomeAcademia")),
                    NomeProfessor = reader.GetString(reader.GetOrdinal("NomeProfessor")) // Adicionado
                };
            }
            return aula;
        }

        public void Add(Aula aula)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            string query = @"
                INSERT INTO Aula (id_modalidade, id_academia, id_professor, dia_semana, horario_inicio, horario_fim, capacidade_maxima)
                VALUES (@id_modalidade, @id_academia, @id_professor, @dia_semana, @horario_inicio, @horario_fim, @capacidade_maxima);";
                // CORREÇÃO ACIMA: Adicionado @id_professor e corrigida a ordem dos placeholders
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("id_modalidade", aula.IdModalidade);
            cmd.Parameters.AddWithValue("id_academia", aula.IdAcademia);
            cmd.Parameters.AddWithValue("id_professor", (object)aula.IdProfessor); // Nome do parâmetro correto
            cmd.Parameters.AddWithValue("dia_semana", (object)aula.DiaSemana ?? DBNull.Value);
            cmd.Parameters.AddWithValue("horario_inicio", (object)aula.HorarioInicio ?? DBNull.Value);
            cmd.Parameters.AddWithValue("horario_fim", (object)aula.HorarioFim ?? DBNull.Value);
            cmd.Parameters.AddWithValue("capacidade_maxima", (object)aula.CapacidadeMaxima ?? DBNull.Value);
            cmd.ExecuteNonQuery();
        }

        public void Update(Aula aula)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            string query = @"
                UPDATE Aula
                SET id_modalidade = @id_modalidade,
                    id_academia = @id_academia,
                    id_professor = @id_professor,
                    dia_semana = @dia_semana,
                    horario_inicio = @horario_inicio,
                    horario_fim = @horario_fim,
                    capacidade_maxima = @capacidade_maxima
                WHERE id_aula = @id_aula;";
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("id_modalidade", aula.IdModalidade);
            cmd.Parameters.AddWithValue("id_academia", aula.IdAcademia);
            cmd.Parameters.AddWithValue("id_professor", aula.IdProfessor); // Nome do parâmetro correto
            cmd.Parameters.AddWithValue("dia_semana", (object)aula.DiaSemana ?? DBNull.Value);
            cmd.Parameters.AddWithValue("horario_inicio", (object)aula.HorarioInicio ?? DBNull.Value);
            cmd.Parameters.AddWithValue("horario_fim", (object)aula.HorarioFim ?? DBNull.Value);
            cmd.Parameters.AddWithValue("capacidade_maxima", (object)aula.CapacidadeMaxima ?? DBNull.Value);
            cmd.Parameters.AddWithValue("id_aula", aula.IdAula);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            string query = "DELETE FROM Aula WHERE id_aula = @id_aula;";
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("id_aula", id);
            cmd.ExecuteNonQuery();
        }
    }
}