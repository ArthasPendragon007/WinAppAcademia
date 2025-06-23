using System; // Adicionado para ArgumentException
using System.Collections.Generic;
using WinAppAcademia.Models;
using WinAppAcademia.Repositories;

namespace WinAppAcademia.Controllers
{
    internal class AcademiaController
    {
        private readonly AcademiaRepository _repository;

        public AcademiaController()
        {
            _repository = new AcademiaRepository();
        }

        public List<Academia> BuscarTodos() => _repository.GetAll();

        public void Salvar(Academia academia)
        {
            // Validações de negócio
            if (string.IsNullOrWhiteSpace(academia.Nome))
            {
                throw new ArgumentException("O nome da academia não pode ser vazio.");
            }

            if (academia.IdAcademia == 0)
                _repository.Add(academia);
            else
                _repository.Update(academia);
        }

        public void Remover(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID da academia inválido para remoção.");
            }
            _repository.Delete(id);
        }
    }
}