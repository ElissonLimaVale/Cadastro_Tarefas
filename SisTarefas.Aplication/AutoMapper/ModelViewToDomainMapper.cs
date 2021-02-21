using AutoMapper;
using SisTarefas.Application.Models;
using SisTarefas.Domain.Base;

namespace SisTarefas
{
    public class ModelViewToDomainMapper: Profile
    {
        public override string ProfileName
        {
            get { return "ModelViewToDomainMapper"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<TarefaViewModel, Tarefa>();
            Mapper.CreateMap<ContatosViewModel, Contatos>();
            Mapper.CreateMap<NotificacoesViewModel, Notificacoes>();
        }
    }
}
