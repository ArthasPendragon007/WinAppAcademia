using System;

namespace WinAppAcademia.Models
{
    public class Modalidade
    {
        public int IdModalidade { get; set; }
        public string NomeModalidade { get; set; } // Usando 'NomeModalidade' para seguir o nome da coluna
        public string Descricao { get; set; }
        public decimal ValorMensalidade { get; set; } // DECIMAL(10,2)

        // Sobrescrita para exibir o nome da modalidade em ComboBoxes
        public override string ToString()
        {
            return NomeModalidade;
        }
    }
}