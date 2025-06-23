// Controllers/FrequenciaController.cs
using System;
using System.Collections.Generic;
using WinAppAcademia.Models;
using WinAppAcademia.Repositories;

namespace WinAppAcademia.Controllers
{
    internal class FrequenciaController
    {
        private FrequenciaRepository _repository;

        public FrequenciaController()
        {
            _repository = new FrequenciaRepository();
        }

        public void Salvar(Frequencia frequencia)
        {
            // Validações de Negócio
            if (frequencia.IdAluno <= 0)
            {
                throw new ArgumentException("O Aluno deve ser selecionado.");
            }
            if (frequencia.IdAula <= 0)
            {
                throw new ArgumentException("A Aula deve ser selecionada.");
            }
            if (string.IsNullOrWhiteSpace(frequencia.Presenca))
            {
                throw new ArgumentException("A Presença deve ser informada (Ex: 'Presente' ou 'Faltou').");
            }
            if (frequencia.DataAula == DateTime.MinValue)
            {
                throw new ArgumentException("A Data da Aula deve ser válida.");
            }
            if (frequencia.DataAula > DateTime.Now.AddDays(1)) // Não permitir frequência no futuro distante
            {
                throw new ArgumentException("A Data da Aula não pode ser no futuro.");
            }

            if (frequencia.IdFrequencia == 0)
            {
                // Verifica se já existe uma frequência para o mesmo aluno na mesma aula e data
                // Isso requer um método de busca no repositório, ou você pode buscar todos e filtrar.
                // Para simplificar, faremos uma busca mais específica:
                if (ExisteFrequenciaParaAlunoAulaData(frequencia.IdAluno, frequencia.IdAula, frequencia.DataAula.Date))
                {
                    throw new ArgumentException("Já existe um registro de frequência para este aluno nesta aula e data.");
                }
                _repository.Add(frequencia);
            }
            else
            {
                // Ao atualizar, verifique se a nova combinação Aluno/Aula/DataAula não conflita
                // com outro registro existente (que não seja ele mesmo)
                var frequenciaExistente = _repository.GetById(frequencia.IdFrequencia);
                if (frequenciaExistente != null &&
                    (frequencia.IdAluno != frequenciaExistente.IdAluno ||
                    frequencia.IdAula != frequenciaExistente.IdAula ||
                    frequencia.DataAula.Date != frequenciaExistente.DataAula.Date))
                {
                    if (ExisteFrequenciaParaAlunoAulaData(frequencia.IdAluno, frequencia.IdAula, frequencia.DataAula.Date, frequencia.IdFrequencia))
                    {
                        throw new ArgumentException("A alteração resultaria em um registro de frequência duplicado para este aluno nesta aula e data.");
                    }
                }
                _repository.Update(frequencia);
            }
        }

        public void Remover(int idFrequencia)
        {
            if (idFrequencia <= 0)
            {
                throw new ArgumentException("ID da frequência inválido para remoção.");
            }
            // Opcional: Verificar se o registro existe antes de tentar remover
            var frequencia = _repository.GetById(idFrequencia);
            if (frequencia == null)
            {
                throw new ArgumentException("Registro de frequência não encontrado para exclusão.");
            }
            _repository.Delete(idFrequencia);
        }

        public List<Frequencia> BuscarTodos()
        {
            return _repository.GetAll();
        }

        public Frequencia BuscarPorId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID de frequência inválido.");
            }
            return _repository.GetById(id);
        }

        // Método auxiliar para verificar duplicidade, pode ser adicionado ao Repository
        private bool ExisteFrequenciaParaAlunoAulaData(int idAluno, int idAula, DateTime dataAula, int? idFrequenciaExcluir = null)
        {
            // Este método pode ser movido para FrequenciaRepository para melhor encapsulamento.
            // Por simplicidade, vou implementá-lo aqui chamando BuscarTodos e filtrando.
            // Para grandes volumes de dados, uma consulta SQL otimizada seria melhor.
            var todasFrequencias = _repository.GetAll();
            foreach (var freq in todasFrequencias)
            {
                if (freq.IdAluno == idAluno &&
                    freq.IdAula == idAula &&
                    freq.DataAula.Date == dataAula.Date)
                {
                    // Se estivermos atualizando, ignoramos o próprio registro sendo atualizado
                    if (idFrequenciaExcluir.HasValue && freq.IdFrequencia == idFrequenciaExcluir.Value)
                    {
                        continue;
                    }
                    return true;
                }
            }
            return false;
        }
    }
}