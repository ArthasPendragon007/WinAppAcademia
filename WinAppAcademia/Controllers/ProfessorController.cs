using System;
using System.Collections.Generic;
using WinAppAcademia.Models;
using WinAppAcademia.Repositories;

namespace WinAppAcademia.Controllers
{
    internal class ProfessorController
    {
        private readonly ProfessorRepository _repository;
        private readonly AcademiaRepository _academiaRepository;
        private readonly ModalidadeRepository _modalidadeRepository;

        public ProfessorController()
        {
            _repository = new ProfessorRepository();
            _academiaRepository = new AcademiaRepository();
            _modalidadeRepository = new ModalidadeRepository();
        }

        public List<Professor> BuscarTodos() => _repository.GetAll();

        public void Salvar(Professor professor)
        {
            // Validações de negócio
            if (professor.IdAcademia <= 0)
            {
                throw new ArgumentException("ID da academia inválido para o professor.");
            }
            if (professor.IdModalidade <= 0)
            {
                throw new ArgumentException("ID da modalidade inválido para o professor.");
            }
            if (string.IsNullOrWhiteSpace(professor.Nome))
            {
                throw new ArgumentException("O nome do professor não pode ser vazio.");
            }
            if (string.IsNullOrWhiteSpace(professor.Cpf) || professor.Cpf.Length != 11)
            {
                throw new ArgumentException("CPF do professor inválido.");
            }
            if (professor.DataNascimento.HasValue && professor.DataNascimento.Value > DateTime.Today)
            {
                throw new ArgumentException("Data de nascimento do professor não pode ser futura.");
            }

            if (_academiaRepository.GetById(professor.IdAcademia) == null)
            {
            throw new ArgumentException("Academia não encontrada para este professor.");
            }
            if (_modalidadeRepository.GetById(professor.IdModalidade) == null)
            {
            throw new ArgumentException("Modalidade não encontrada para este professor.");
             }

            if (professor.IdProfessor == 0)
                _repository.Add(professor);
            else
                _repository.Update(professor);
        }

        public void Remover(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID do professor inválido para remoção.");
            }
            _repository.Delete(id);
        }
    }
}