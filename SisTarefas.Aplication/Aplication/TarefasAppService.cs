using AutoMapper;
using SisTarefas.Aplication.Interface;
using SisTarefas.Aplication.Models;
using SisTarefas.Domain.Base;
using SisTarefas.Repository.Interface;

namespace SisTarefas.Aplication
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
