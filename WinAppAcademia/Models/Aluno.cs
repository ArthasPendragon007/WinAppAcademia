using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAppAcademia.Models
{
    internal class Aluno
    {
        public required int Id { get; set; }
        public required string Nome { get; set; }
        public required string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public required string Sexo { get; set; }
        public required string Telefone { get; set; }
        public required string Email { get; set; }
        public DateTime DataMatricula { get; set; }
        public required string Status { get; set; }
    }
}
