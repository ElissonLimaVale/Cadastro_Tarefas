using SisTarefas.Application.Models;

namespace SisTarefas.Application.Interface
{
    public interface ITarefasAppService
    {
        dynamic Cadastrar(TarefaViewModel tarefa);
    }
}
