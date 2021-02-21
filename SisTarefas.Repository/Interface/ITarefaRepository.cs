

using SisTarefas.Domain.Base;

namespace SisTarefas.Repository.Interface
{
    public interface ITarefaRepository
    {
        dynamic Cadastrar(Tarefa tarefa);
    }
}
