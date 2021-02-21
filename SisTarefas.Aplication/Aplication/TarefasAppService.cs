using AutoMapper;
using SisTarefas.Application.Interface;
using SisTarefas.Application.Models;
using SisTarefas.Domain.Base;
using SisTarefas.Repository.Interface;

namespace SisTarefas.Application
{
    public class TarefasAppService: ITarefasAppService
    {
        private readonly ITarefaRepository _repository;
        public TarefasAppService(ITarefaRepository repository)
        {
            _repository = repository;
        }

        public dynamic Cadastrar(TarefaViewModel tarefa)
        {
            return _repository.Cadastrar(Mapper.Map<TarefaViewModel,Tarefa>(tarefa));
        }
    }
}
