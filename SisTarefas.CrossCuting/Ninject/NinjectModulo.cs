using Ninject.Modules;
using SisTarefas.Aplication;
using SisTarefas.Aplication.Interface;
using SisTarefas.Repository;
using SisTarefas.Repository.Interface;

namespace SisTarefas.CrossCuting.Ninject
{
    public class NinjectModulo : NinjectModule
    {
        public override void Load()
        {
            //APP SERVICE

            Bind<ITarefasAppService>().To<TarefasAppService>();

            //REPOSITORY

            Bind<ITarefaRepository>().To<TarefaRepository>();

        }
    }
}
