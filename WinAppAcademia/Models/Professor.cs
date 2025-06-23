using System;

namespace WinAppAcademia.Models
{
    public class Professor
    {
        public int IdProfessor { get; set; }
        public int IdAcademia { get; set; } // FK
        public int IdModalidade { get; set; } // FK
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime? DataNascimento { get; set; } // DATE, pode ser nulo
        public char? Sexo { get; set; } // CHAR(1), pode ser nulo
        public string Telefone { get; set; }
        public string Email { get; set; }

        // Propriedades para exibição (nomes das entidades relacionadas)
        public string NomeAcademia { get; set; }
        public string NomeModalidade { get; set; }
    }
}