using AutoMapper;
using SisTarefas.Application.Models;
using SisTarefas.Domain.Base;
namespace SisTarefas.Aplication.AutoMapper
{
    public class DomainToViewModelMapper: Profile
    {
        public override string ProfileName {
            get { return "DomainToViewModelMapper"; }
        }

        protected override void Configure()
        {
           Mapper.CreateMap<Tarefa, TarefaViewModel >();
           Mapper.CreateMap<Contatos, ContatosViewModel >();
           Mapper.CreateMap<Notificacoes, NotificacoesViewModel >();
           Mapper.CreateMap<Usuario, UsuarioViewModel >();
        }
    }
}