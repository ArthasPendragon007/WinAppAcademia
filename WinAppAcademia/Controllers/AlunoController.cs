using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinAppAcademia.Models;
using WinAppAcademia.Repositories;

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
            if (aluno.Id == 0)
                _repository.Inserir(aluno);
            else
                _repository.Atualizar(aluno);
        }

        public void Remover(int id) => _repository.Excluir(id);
    }
    }

