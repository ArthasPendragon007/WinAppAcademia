using System;
using System.Collections.Generic;
using WinAppAcademia.Models;
using WinAppAcademia.Repositories;

namespace WinAppAcademia.Controllers
{
    internal class MatriculaController
    {
        private readonly MatriculaRepository _repository;

        public MatriculaController()
        {
            _repository = new MatriculaRepository();
        }

        public List<Matricula> BuscarTodos() => _repository.GetAll();

        public void Salvar(Matricula matricula)
        {
            if (matricula.IdAluno <= 0) 
            {
                throw new ArgumentException("O aluno é obrigatório para a matrícula.");
            }
            if (matricula.IdModalidade <= 0) 
            {
                throw new ArgumentException("A modalidade é obrigatória para a matrícula.");
            }
            if (matricula.DataInicio == DateTime.MinValue) 
            {
                throw new ArgumentException("A data de início da matrícula é obrigatória.");
            }
            if (string.IsNullOrWhiteSpace(matricula.StatusMatricula)) 
            {
                throw new ArgumentException("O status da matrícula é obrigatório.");
            }
            if (matricula.StatusMatricula != "ativa" && matricula.StatusMatricula != "cancelada") 
            {
                throw new ArgumentException("O status da matrícula deve ser 'ativa' ou 'cancelada'.");
            }

            // Validação de lógica de datas
            if (matricula.DataFim.HasValue && matricula.DataFim.Value < matricula.DataInicio)
            {
                throw new ArgumentException("A data de fim da matrícula não pode ser anterior à data de início.");
            }


            if (matricula.IdMatricula == 0)
                _repository.Add(matricula);
            else
                _repository.Update(matricula);
        }

        public void Remover(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID da matrícula inválido para remoção.");
            }
            _repository.Delete(id);
        }
    }
}