using AutoMapper;
using SisTarefas.Aplication.Models;
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
        }
    }
}
