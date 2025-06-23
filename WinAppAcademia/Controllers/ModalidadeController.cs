using System;
using System.Collections.Generic;
using WinAppAcademia.Models;
using WinAppAcademia.Repositories;

namespace WinAppAcademia.Controllers
{
    internal class ModalidadeController
    {
        private readonly ModalidadeRepository _repository;

        public ModalidadeController()
        {
            _repository = new ModalidadeRepository();
        }

        public List<Modalidade> BuscarTodos() => _repository.GetAll();

        public void Salvar(Modalidade modalidade)
        {
            // Validações de negócio
            if (string.IsNullOrWhiteSpace(modalidade.NomeModalidade))
            {
                throw new ArgumentException("O nome da modalidade não pode ser vazio.");
            }
            if (modalidade.ValorMensalidade < 0)
            {
                throw new ArgumentException("O valor da mensalidade não pode ser negativo.");
            }

            if (modalidade.IdModalidade == 0)
                _repository.Add(modalidade);
            else
                _repository.Update(modalidade);
        }

        public void Remover(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID da modalidade inválido para remoção.");
            }
            _repository.Delete(id);
        }
    }
}