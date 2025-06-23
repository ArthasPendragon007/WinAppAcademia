using System;
using System.Windows.Forms;
using Npgsql;

namespace WinAppAcademia.Utils
{
    internal class DBconfig
    {
        public static void CriarEstruturaDoBanco()
        {
            string host = ObterVariavelAmbiente("POSTGRES_HOST", "localhost");
            string adminUser = ObterVariavelAmbiente("POSTGRES_ADMIN_USER", "postgres");
            string adminPassword = ObterVariavelAmbiente("POSTGRES_ADMIN_PASSWORD", "1234");
            string appUser = ObterVariavelAmbiente("POSTGRES_USER", "academia_user");
            string appPassword = ObterVariavelAmbiente("POSTGRES_PASSWORD", "1234");
            string database = ObterVariavelAmbiente("POSTGRES_DATABASE", "academia");

            string connStrPostgres = $"Host={host};Username={adminUser};Password={adminPassword};Database=postgres";
            string connStrApp = $"Host={host};Username={adminUser};Password={adminPassword};Database={database}";

            using (var conn = new NpgsqlConnection(connStrPostgres))
            {
                conn.Open();
                var cmd = new NpgsqlCommand($"SELECT 1 FROM pg_database WHERE datname = '{database}'", conn);
                if (cmd.ExecuteScalar() == null)
                {
                    new NpgsqlCommand($"CREATE DATABASE {database}", conn).ExecuteNonQuery();
                    MessageBox.Show("Banco de dados criado com sucesso!");
                }
            }

            using (var conn = new NpgsqlConnection(connStrApp))
            {
                conn.Open();

                string[] scripts = new string[]
                {
                    // Tabelas
                 @"
                    CREATE TABLE IF NOT EXISTS Academia (
                        id_academia SERIAL PRIMARY KEY,
                        nome VARCHAR(255) NOT NULL,
                        endereco VARCHAR(255),
                        telefone VARCHAR(15),
                        email VARCHAR(100)
                    );",

                    @"
                    CREATE TABLE IF NOT EXISTS Modalidade (
                        id_modalidade SERIAL PRIMARY KEY,
                        nome_modalidade VARCHAR(100) NOT NULL,
                        descricao TEXT,
                        valor_mensalidade DECIMAL(10, 2)
                    );",

                    @"
                    CREATE TABLE IF NOT EXISTS Aluno (
                        id_aluno SERIAL PRIMARY KEY,
                        nome VARCHAR(255) NOT NULL,
                        cpf VARCHAR(14) UNIQUE NOT NULL,
                        data_nascimento DATE,
                        sexo CHAR(1),
                        telefone VARCHAR(15),
                        email VARCHAR(100),
                        data_matricula DATE,
                        status VARCHAR(10) CHECK (status IN ('ativo', 'inativo')) NOT NULL
                    );",

                    @"
                    CREATE TABLE IF NOT EXISTS Professor (
                        id_professor SERIAL PRIMARY KEY,
                        id_academia INT NOT NULL,
                        id_modalidade INT NOT NULL,
                        nome VARCHAR(255) NOT NULL,
                        cpf VARCHAR(14) UNIQUE NOT NULL,
                        data_nascimento DATE,
                        sexo CHAR(1) CHECK (sexo IN ('M', 'F')),
                        telefone VARCHAR(15),
                        email VARCHAR(100),
                        FOREIGN KEY (id_academia) REFERENCES Academia(id_academia),
                        FOREIGN KEY (id_modalidade) REFERENCES Modalidade(id_modalidade)
                    );",

                    @"
                    CREATE TABLE IF NOT EXISTS Aula (
                        id_aula SERIAL PRIMARY KEY,
                        id_modalidade INT NOT NULL,
                        id_academia INT NOT NULL,
                        id_professor INT NOT NULL,
                        dia_semana VARCHAR(15), 
                        horario_inicio TIME,
                        horario_fim TIME,
                        capacidade_maxima INT,
                        FOREIGN KEY (id_professor) REFERENCES Professor(id_professor),
                        FOREIGN KEY (id_modalidade) REFERENCES Modalidade(id_modalidade),
                        FOREIGN KEY (id_academia) REFERENCES Academia(id_academia)
                    );",

                    @"
                    CREATE TABLE IF NOT EXISTS Matricula (
                        id_matricula SERIAL PRIMARY KEY,
                        id_aluno INT NOT NULL,
                        id_modalidade INT NOT NULL,
                        data_inicio DATE NOT NULL,
                        data_fim DATE,
                        status_matricula VARCHAR(10) CHECK (status_matricula IN ('ativa', 'cancelada')) NOT NULL,
                        FOREIGN KEY (id_aluno) REFERENCES Aluno(id_aluno),
                        FOREIGN KEY (id_modalidade) REFERENCES Modalidade(id_modalidade)
                    );",

                    @"
                    CREATE TABLE IF NOT EXISTS Frequencia (
                        id_frequencia SERIAL PRIMARY KEY,
                        id_aluno INT NOT NULL,
                        id_aula INT NOT NULL,
                        data_aula DATE NOT NULL,
                        presenca VARCHAR(3) CHECK (presenca IN ('sim', 'não')) NOT NULL,
                        FOREIGN KEY (id_aluno) REFERENCES Aluno(id_aluno),
                        FOREIGN KEY (id_aula) REFERENCES Aula(id_aula)
                    );",

                    @"
                    CREATE TABLE IF NOT EXISTS Pagamento (
                        id_pagamento SERIAL PRIMARY KEY,
                        id_aluno INT NOT NULL,
                        data_pagamento DATE NOT NULL,
                        valor DECIMAL(10, 2) NOT NULL,
                        status_pagamento VARCHAR(10) CHECK (status_pagamento IN ('pago', 'pendente')) NOT NULL,
                        FOREIGN KEY (id_aluno) REFERENCES Aluno(id_aluno)
                    );",

                    @"
                    CREATE TABLE IF NOT EXISTS Equipamento (
                        id_equipamento SERIAL PRIMARY KEY,
                        id_academia INT NOT NULL,
                        nome VARCHAR(255) NOT NULL,
                        descricao TEXT,
                        data_aquisicao DATE,
                        estado VARCHAR(20) CHECK (estado IN ('novo', 'usado', 'manutenção', 'danificado')) NOT NULL,
                        FOREIGN KEY (id_academia) REFERENCES Academia(id_academia)
                    );",

                    // Procedure: Registrar Pagamento
                    @"
                    CREATE OR REPLACE PROCEDURE registrar_pagamento(p_id_aluno INT, p_valor DECIMAL, p_data DATE)
                    LANGUAGE plpgsql
                    AS $$
                    BEGIN
                        INSERT INTO Pagamento (id_aluno, data_pagamento, valor, status_pagamento)
                        VALUES (p_id_aluno, p_data, p_valor, 'pago');
                    END;
                    $$;",

                    // Function: Total Pago
                    @"
                    CREATE OR REPLACE FUNCTION total_pago_por_aluno(p_id_aluno INT)
                    RETURNS DECIMAL AS $$
                    DECLARE
                        total DECIMAL;
                    BEGIN
                        SELECT SUM(valor) INTO total
                        FROM Pagamento
                        WHERE id_aluno = p_id_aluno AND status_pagamento = 'pago';

                        RETURN COALESCE(total, 0);
                    END;
                    $$ LANGUAGE plpgsql;",

                    // Procedure: Atualizar Status da Matrícula
                    @"
                    CREATE OR REPLACE PROCEDURE atualizar_status_matricula(p_id_matricula INT, p_status VARCHAR)
                    LANGUAGE plpgsql
                    AS $$
                    BEGIN
                        IF p_status NOT IN ('ativa', 'cancelada') THEN
                            RAISE EXCEPTION 'Status invalido!';
                        END IF;

                        UPDATE Matricula
                        SET status_matricula = p_status
                        WHERE id_matricula = p_id_matricula;
                    END;
                    $$;",

                    // Trigger Function
                    @"
                    CREATE OR REPLACE FUNCTION trigger_inativar_aluno()
                    RETURNS TRIGGER AS $$
                    BEGIN
                        IF NEW.status_matricula = 'cancelada' THEN
                            UPDATE Aluno
                            SET status = 'inativo'
                            WHERE id_aluno = NEW.id_aluno;
                        END IF;
                        RETURN NEW;
                    END;
                    $$ LANGUAGE plpgsql;",

                    // Trigger
                    @"
                    DO $$
                    BEGIN
                       IF NOT EXISTS(SELECT 1 FROM pg_trigger WHERE tgname = 'trg_inativar_aluno') THEN
                           CREATE TRIGGER trg_inativar_aluno
                           AFTER UPDATE ON Matricula
                           FOR EACH ROW
                           WHEN(OLD.status_matricula<> 'cancelada' AND NEW.status_matricula = 'cancelada')
                           EXECUTE FUNCTION trigger_inativar_aluno();
                    END IF;
                    END $$;",

                    // Views
                    @"
                    CREATE OR REPLACE VIEW vw_alunos_ativos_modalidades AS
                    SELECT a.nome AS aluno_nome, m.nome_modalidade, ma.status_matricula
                    FROM Aluno a
                    JOIN Matricula ma ON a.id_aluno = ma.id_aluno
                    JOIN Modalidade m ON ma.id_modalidade = m.id_modalidade
                    WHERE a.status = 'ativo' AND ma.status_matricula = 'ativa';",

                    @"
                    CREATE OR REPLACE VIEW vw_frequencia_por_aula AS
                    SELECT
                        f.id_aula,
                        a.id_professor,
                        COUNT(*) FILTER (WHERE f.presenca = 'sim') AS total_presentes
                    FROM Frequencia f
                    JOIN Aula a ON f.id_aula = a.id_aula
                    GROUP BY f.id_aula, a.id_professor;",

                    @"
                    CREATE OR REPLACE VIEW vw_pagamentos_pendentes AS
                    SELECT p.id_aluno, a.nome AS aluno_nome, p.valor, p.data_pagamento
                    FROM Pagamento p
                    JOIN Aluno a ON p.id_aluno = a.id_aluno
                    WHERE p.status_pagamento = 'pendente';",

                    // Usuário da aplicação e permissões
                    $@"
                    DO $$
                    BEGIN
                        IF NOT EXISTS (SELECT FROM pg_roles WHERE rolname = '{appUser}') THEN
                            CREATE USER {appUser} WITH PASSWORD '{appPassword}';
                        END IF;
                    END $$;"
                };

                foreach (var script in scripts)
                {
                    new NpgsqlCommand(script, conn).ExecuteNonQuery();

                }

                new NpgsqlCommand($@"GRANT CONNECT ON DATABASE {database} TO {adminUser};", conn).ExecuteNonQuery();
                new NpgsqlCommand($@"GRANT USAGE ON SCHEMA public TO {adminUser};", conn).ExecuteNonQuery();
                new NpgsqlCommand($@"GRANT SELECT, INSERT, UPDATE, DELETE ON ALL TABLES IN SCHEMA public TO {adminUser};", conn).ExecuteNonQuery();
                new NpgsqlCommand($@"GRANT EXECUTE ON ALL FUNCTIONS IN SCHEMA public TO {adminUser};", conn).ExecuteNonQuery();
            }
        }

        private static string ObterVariavelAmbiente(string nome, string padrao)
        {
            return Environment.GetEnvironmentVariable(nome) ?? padrao;
        }
    }
}
