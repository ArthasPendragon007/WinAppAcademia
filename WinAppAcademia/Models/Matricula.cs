using System;

namespace WinAppAcademia.Models
{
    public class Matricula
    {
        public int IdMatricula { get; set; }
        public int IdAluno { get; set; } // FK
        public int IdModalidade { get; set; } // FK
        public DateTime DataInicio { get; set; } // DATE NOT NULL
        public DateTime? DataFim { get; set; } // DATE
        public string StatusMatricula { get; set; } // VARCHAR(10) CHECK ('ativa', 'cancelada')

        // Propriedades para exibição
        public string NomeAluno { get; set; }
        public string NomeModalidade { get; set; }
    }
}