using System;
using System.Collections.Generic;
using WinAppAcademia.Models;
using WinAppAcademia.Repositories;

namespace WinAppAcademia.Controllers
{
    internal class EquipamentoController
    {
        private readonly EquipamentoRepository _repository;

        public EquipamentoController()
        {
            _repository = new EquipamentoRepository();
        }

        public List<Equipamento> BuscarTodos() => _repository.GetAll();

        public void Salvar(Equipamento equipamento)
        {
            if (equipamento.IdAcademia <= 0) 
            {
                throw new ArgumentException("A academia associada ao equipamento é obrigatória.");
            }
            if (string.IsNullOrWhiteSpace(equipamento.Nome))
            {
                throw new ArgumentException("O nome do equipamento não pode ser vazio.");
            }
            if (string.IsNullOrWhiteSpace(equipamento.Estado)) 
            {
                throw new ArgumentException("O estado do equipamento deve ser selecionado.");
            }
         


            if (equipamento.IdEquipamento == 0)
                _repository.Add(equipamento);
            else
                _repository.Update(equipamento);
        }

        public void Remover(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID do equipamento inválido para remoção.");
            }
            _repository.Delete(id);
        }
    }
}