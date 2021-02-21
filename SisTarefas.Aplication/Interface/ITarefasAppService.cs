using SisTarefas.Aplication.Models;

namespace SisTarefas.Aplication.Interface
{
    public interface ITarefasAppService
    {
        dynamic Cadastrar(TarefaViewModel tarefa);
    }
}
