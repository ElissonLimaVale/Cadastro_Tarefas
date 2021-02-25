using Ninject.Modules;
using SisAtividades.Aplication;
using SisAtividades.Interface;
using SisTarefas.Application;
using SisTarefas.Application.Interface;
using SisTarefas.Repository;
using SisTarefas.Repository.Interface;
using SisTarefas.Repository.Repository;

namespace SisTarefas.CrossCuting.Ninject
{
    public class NinjectModulo : NinjectModule
    {
        public override void Load()
        {
            //APP SERVICE
            Bind<ITarefasAppService>().To<TarefasAppService>();
            Bind<ILoginAppService>().To<LoginAppService>();

            //REPOSITORY
            Bind<ITarefaRepository>().To<TarefaRepository>();
            Bind<ILoginRepository>().To<LoginRepository>();

        }
    }
}
