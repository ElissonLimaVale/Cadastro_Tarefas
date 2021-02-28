

using SisTarefas.Domain.Base;
using System.Collections.Generic;

namespace SisTarefas.Repository.Interface
{
    public interface ITarefaRepository
    {
        dynamic Cadastrar(Tarefa tarefa);
        dynamic CadastrarContato(Contatos contato);
        dynamic AddNotification(Notificacoes notific);
        List<string> ListarContatos();
        Tarefa BuscarTarefa(int id);
        Tarefa BuscarTarefa(Tarefa tarefa);
        dynamic NotificationVerific(int usuario);
        Notificacoes BuscarNotification(string nome);
    }
}
