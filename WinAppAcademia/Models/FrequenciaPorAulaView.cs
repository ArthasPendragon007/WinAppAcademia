namespace WinAppAcademia.Models
{
    public class FrequenciaPorAulaView
    {
        public int IdAula { get; set; }
        public int IdProfessor { get; set; }
        public int TotalPresentes { get; set; }
        public string NomeAula { get; set; } // Adicionado para exibir o nome da aula (ex: nome da modalidade da aula)
        public string NomeProfessor { get; set; } // Adicionado para exibir o nome do professor
    }
}