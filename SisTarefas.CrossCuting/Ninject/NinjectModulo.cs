using Ninject.Modules;
using SisTarefas.Application;
using SisTarefas.Application.Interface;
using SisTarefas.Repository;
using SisTarefas.Repository.Interface;

namespace SisTarefas.CrossCuting.Ninject
{
    public class NinjectModulo : NinjectModule
    {
        public override void Load()
        {
            //APP SERVICE
            //Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            Bind<ITarefasAppService>().To<TarefasAppService>();

            //REPOSITORY

            Bind<ITarefaRepository>().To<TarefaRepository>();

        }
    }
}
