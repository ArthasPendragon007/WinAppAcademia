using System;

namespace WinAppAcademia.Models
{
    public class Aula
    {
        public int IdAula { get; set; }
        public int IdModalidade { get; set; }
        public int IdAcademia { get; set; }
        public int IdProfessor { get; set; }
        public string DiaSemana { get; set; }
        public TimeSpan? HorarioInicio { get; set; }
        public TimeSpan? HorarioFim { get; set; }
        public int? CapacidadeMaxima { get; set; }

        public string NomeModalidade { get; set; }
        public string NomeAcademia { get; set; }
        public string NomeProfessor { get; set; } 
    }
}