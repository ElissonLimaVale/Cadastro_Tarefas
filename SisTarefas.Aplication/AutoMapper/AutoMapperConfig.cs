


using AutoMapper;

namespace SisTarefas.Aplication.AutoMapper
{
    public sealed class AutoMapperConfig
    {
        public static void RegisterMapper()
        {
            Mapper.Initialize(m =>
            {
                m.AddProfile<DomainToViewModelMapper>();
                m.AddProfile<ModelViewToDomainMapper>();
            });
        }
    }
}
