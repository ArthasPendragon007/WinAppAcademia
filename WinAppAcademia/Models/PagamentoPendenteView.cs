using System;

namespace WinAppAcademia.Models
{
    public class PagamentoPendenteView
    {
        public int IdAluno { get; set; }
        public string AlunoNome { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataPagamento { get; set; }
    }
}