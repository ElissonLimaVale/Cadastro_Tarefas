using SisTarefas.Application.Models;
using System.Collections.Generic;

namespace SisTarefas.Application.Interface
{
    public interface ITarefasAppService
    {
        dynamic Cadastrar(TarefaViewModel tarefa);
        dynamic CadastrarContato(ContatosViewModel contato);
        dynamic AddNotification(NotificacoesViewModel contato);
        List<string> ListarContatos();
        TarefaViewModel BuscarTarefa(int id);
        TarefaViewModel BuscarTarefa(TarefaViewModel tarefa);
        dynamic NotificationVerific(int usuario);
        NotificacoesViewModel BuscarNotification(string nome);
    }
}
