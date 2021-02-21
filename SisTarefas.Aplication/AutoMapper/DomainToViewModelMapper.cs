using AutoMapper;
using SisTarefas.Aplication.Models;
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
        }
    }
}