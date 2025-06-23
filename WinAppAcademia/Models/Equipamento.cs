using System;

namespace WinAppAcademia.Models
{
    public class Equipamento
    {
        public int IdEquipamento { get; set; }
        public int IdAcademia { get; set; } // FK
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataAquisicao { get; set; } // DATE
        public string Estado { get; set; } // VARCHAR(20) CHECK ('novo', 'usado', 'manutenção', 'danificado')

        // Propriedade para exibição
        public string NomeAcademia { get; set; }
    }
}