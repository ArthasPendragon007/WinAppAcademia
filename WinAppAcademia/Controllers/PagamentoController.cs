using System;
using System.Collections.Generic;
using WinAppAcademia.Models;
using WinAppAcademia.Repositories;

namespace WinAppAcademia.Controllers
{
    internal class PagamentoController
    {
        private readonly PagamentoRepository _repository;

        public PagamentoController()
        {
            _repository = new PagamentoRepository();
        }

        public List<Pagamento> BuscarTodos() => _repository.GetAll();

        public void Salvar(Pagamento pagamento)
        {
 
            if (pagamento.IdAluno <= 0) 
            {
                throw new ArgumentException("O aluno do pagamento é obrigatório.");
            }
            if (pagamento.DataPagamento == DateTime.MinValue) 
            {
                throw new ArgumentException("A data do pagamento é obrigatória.");
            }
            if (pagamento.Valor <= 0) 
            {
                throw new ArgumentException("O valor do pagamento deve ser positivo.");
            }
            if (string.IsNullOrWhiteSpace(pagamento.StatusPagamento))
            {
                throw new ArgumentException("O status do pagamento é obrigatório.");
            }
            if (pagamento.StatusPagamento != "pago" && pagamento.StatusPagamento != "pendente") 
            {
                throw new ArgumentException("O status do pagamento deve ser 'pago' ou 'pendente'.");
            }

            if (pagamento.IdPagamento == 0)
                _repository.Add(pagamento);
            else
                _repository.Update(pagamento);
        }

        public void Remover(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID do pagamento inválido para remoção.");
            }
            _repository.Delete(id);
        }
    }
}