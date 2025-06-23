using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAppAcademia.Utils
{
    internal class Conexao
    {
        public static string ObterStringConexao()
        {
            string host = ObterVariavelAmbiente("POSTGRES_HOST", "localhost");
            string user = ObterVariavelAmbiente("POSTGRES_USER", "postgres");
            string password = ObterVariavelAmbiente("POSTGRES_PASSWORD", "1234");
            string database = ObterVariavelAmbiente("POSTGRES_DATABASE", "academia");

            return $"Host={host};Username={user};Password={password};Database={database}";
        }

        private static string ObterVariavelAmbiente(string nome, string padrao)
        {
            return Environment.GetEnvironmentVariable(nome) ?? padrao;
        }
    }
}


