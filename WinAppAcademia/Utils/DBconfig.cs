using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            // Certifique-se de que o pacote NuGet Npgsql está instalado no seu projeto.
            // No Visual Studio, clique com o botão direito no projeto > Gerenciar Pacotes NuGet > Procurar por "Npgsql" > Instalar.

            // Ou, pelo terminal integrado do Visual Studio, execute:
            //
            // dotnet add package Npgsql
            //
            // Isso adicionará a referência necessária para que o tipo NpgsqlConnection seja reconhecido.

            // Após instalar, limpe e reconstrua o projeto para garantir que o erro CS0246 desapareça.
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

                // Tabela Aluno
                new NpgsqlCommand(@"
                    CREATE TABLE IF NOT EXISTS aluno (
                        id SERIAL PRIMARY KEY,
                        nome TEXT NOT NULL,
                        cpf TEXT UNIQUE NOT NULL,
                        status TEXT CHECK (status IN ('ativo', 'inativo')) DEFAULT 'ativo'
                    );
                ", conn).ExecuteNonQuery();

                // Função de log
                new NpgsqlCommand(@"
                    CREATE OR REPLACE FUNCTION registrar_log()
                    RETURNS TRIGGER AS $$
                    BEGIN
                        IF TG_OP = 'INSERT' THEN
                            INSERT INTO log_operacoes (operacao, id_alvo) VALUES ('INSERT', NEW.id);
                        ELSIF TG_OP = 'UPDATE' THEN
                            INSERT INTO log_operacoes (operacao, id_alvo) VALUES ('UPDATE', NEW.id);
                        ELSIF TG_OP = 'DELETE' THEN
                            INSERT INTO log_operacoes (operacao, id_alvo) VALUES ('DELETE', OLD.id);
                        END IF;
                        RETURN NEW;
                    END;
                    $$ LANGUAGE plpgsql;
                ", conn).ExecuteNonQuery();

                // Tabela de log
                new NpgsqlCommand(@"
                    CREATE TABLE IF NOT EXISTS log_operacoes (
                        id SERIAL PRIMARY KEY,
                        data_hora TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                        operacao TEXT NOT NULL,
                        id_alvo INTEGER
                    );
                ", conn).ExecuteNonQuery();

                // Triggers
                new NpgsqlCommand(@"
                    DO $$
                    BEGIN
                        IF NOT EXISTS (SELECT 1 FROM pg_trigger WHERE tgname = 'trg_log_insert') THEN
                            CREATE TRIGGER trg_log_insert
                            AFTER INSERT ON aluno
                            FOR EACH ROW EXECUTE FUNCTION registrar_log();
                        END IF;

                        IF NOT EXISTS (SELECT 1 FROM pg_trigger WHERE tgname = 'trg_log_update') THEN
                            CREATE TRIGGER trg_log_update
                            AFTER UPDATE ON aluno
                            FOR EACH ROW EXECUTE FUNCTION registrar_log();
                        END IF;

                        IF NOT EXISTS (SELECT 1 FROM pg_trigger WHERE tgname = 'trg_log_delete') THEN
                            CREATE TRIGGER trg_log_delete
                            AFTER DELETE ON aluno
                            FOR EACH ROW EXECUTE FUNCTION registrar_log();
                        END IF;
                    END $$;
                ", conn).ExecuteNonQuery();

                // Criar usuário da aplicação e permissões
                new NpgsqlCommand($@"
                    DO $$ BEGIN
                        IF NOT EXISTS (SELECT FROM pg_roles WHERE rolname = '{appUser}') THEN
                            CREATE USER {appUser} WITH PASSWORD '{appPassword}';
                        END IF;
                    END $$;
                ", conn).ExecuteNonQuery();

                new NpgsqlCommand($@"GRANT SELECT, INSERT, UPDATE, DELETE ON aluno TO {appUser};", conn).ExecuteNonQuery();
                new NpgsqlCommand($@"GRANT USAGE, SELECT ON SEQUENCE aluno_id_seq TO {appUser};", conn).ExecuteNonQuery();
            }
        }

        private static string ObterVariavelAmbiente(string nome, string padrao)
        {
            return Environment.GetEnvironmentVariable(nome) ?? padrao;
        }
    }
}
 
