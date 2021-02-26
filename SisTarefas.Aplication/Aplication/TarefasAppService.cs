using AutoMapper;
using SisTarefas.Application.Interface;
using SisTarefas.Application.Models;
using SisTarefas.Domain.Base;
using SisTarefas.Repository.Interface;
using System.Collections.Generic;

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

        public dynamic CadastrarContato(ContatosViewModel contato)
        {
            return _repository.CadastrarContato(Mapper.Map<ContatosViewModel, Contatos>(contato));
        }

        public dynamic AddNotification(NotificacoesViewModel notific)
        {
            return _repository.AddNotification(Mapper.Map<NotificacoesViewModel, Notificacoes>(notific));
        }

        public List<string> ListarContatos()
        {
            return _repository.ListarContatos();
        }

        public TarefaViewModel BuscarTarefa(int id)
        {
            return Mapper.Map<Tarefa, TarefaViewModel>(_repository.BuscarTarefa(id));
        }

        public dynamic NotificationVerific(string usuario)
        {
            return _repository.NotificationVerific(usuario);
        }

    }
}
