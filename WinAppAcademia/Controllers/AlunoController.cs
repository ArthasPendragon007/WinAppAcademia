using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinAppAcademia.Models;
using WinAppAcademia.Repositories; // Assegure-se de que AlunoRepository existe e está acessível

namespace WinAppAcademia.Controllers
{
    internal class AlunoController
    {
        private readonly AlunoRepository _repository;

        public AlunoController()
        {
            _repository = new AlunoRepository();
        }

        public List<Aluno> BuscarTodos() => _repository.GetAll();

        public void Salvar(Aluno aluno)
        {
            if (string.IsNullOrWhiteSpace(aluno.Nome))
            {
                throw new ArgumentException("O nome do aluno não pode ser vazio.");
            }
            if (string.IsNullOrWhiteSpace(aluno.CPF) || aluno.CPF.Length < 11) 
            {
                throw new ArgumentException("CPF do aluno inválido.");
            }
            if (aluno.DataNascimento == DateTime.MinValue) 
            {
                throw new ArgumentException("Data de nascimento do aluno inválida.");
            }
            if (string.IsNullOrWhiteSpace(aluno.Status))
            {
                throw new ArgumentException("Status do aluno não pode ser vazio.");
            }


            if (aluno.IdAluno == 0)
                _repository.Add(aluno); 
            else
                _repository.Update(aluno);
        }

        public void Remover(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID do aluno inválido para remoção.");
            }
            _repository.Delete(id); // Assumindo que AlunoRepository tem um método Delete
        }
    }
}