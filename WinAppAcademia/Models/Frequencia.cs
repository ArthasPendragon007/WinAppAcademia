using System;

namespace WinAppAcademia.Models
{
    internal class Frequencia
    {
        public int IdFrequencia { get; set; }
        public int IdAluno { get; set; }
        public int IdAula { get; set; }
        public DateTime DataAula { get; set; }
        public string Presenca { get; set; }

        public string NomeAluno { get; set; }
        public string NomeAula { get; set; } 
    }
}