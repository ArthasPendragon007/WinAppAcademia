using System;
using System.Collections.Generic;
using WinAppAcademia.Models;
using WinAppAcademia.Repositories;

namespace WinAppAcademia.Controllers
{
    internal class AulaController
    {
        private readonly AulaRepository _repository;

        public AulaController()
        {
            _repository = new AulaRepository();
        }

        public List<Aula> BuscarTodos() => _repository.GetAll();

        public void Salvar(Aula aula)
        {
            if (aula.IdModalidade <= 0)
            {
                throw new ArgumentException("A modalidade da aula é obrigatória.");
            }
            if (aula.IdAcademia <= 0)
            {
                throw new ArgumentException("A academia da aula é obrigatória.");
            }
            if (aula.IdProfessor <= 0)
            {
                throw new ArgumentException("O professor da aula é obrigatório.");
            }

            if (aula.HorarioInicio.HasValue && aula.HorarioFim.HasValue && aula.HorarioInicio.Value >= aula.HorarioFim.Value)
            {
                throw new ArgumentException("O horário de início não pode ser igual ou posterior ao horário de fim.");
            }
            var diasValidos = new List<string> { "Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sábado", "Domingo" };
            if (!string.IsNullOrWhiteSpace(aula.DiaSemana) && !diasValidos.Contains(aula.DiaSemana))
            {
                throw new ArgumentException("Dia da semana inválido.");
            }


            if (aula.IdAula == 0)
                _repository.Add(aula);
            else
                _repository.Update(aula);
        }

        public void Remover(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID da aula inválido para remoção.");
            }
            _repository.Delete(id);
        }
    }
}