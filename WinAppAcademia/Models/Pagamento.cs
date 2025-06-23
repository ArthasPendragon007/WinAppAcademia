using System;

namespace WinAppAcademia.Models
{
    public class Pagamento
    {
        public int IdPagamento { get; set; }
        public int IdAluno { get; set; } // FK
        public DateTime DataPagamento { get; set; } // DATE NOT NULL
        public decimal Valor { get; set; } // DECIMAL(10,2) NOT NULL
        public string StatusPagamento { get; set; } // VARCHAR(10) CHECK ('pago', 'pendente') NOT NULL

        // Propriedade para exibição
        public string NomeAluno { get; set; }
    }
}