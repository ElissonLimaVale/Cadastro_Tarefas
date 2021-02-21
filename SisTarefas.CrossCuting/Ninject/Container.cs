using Ninject;

namespace SisTarefas.CrossCuting.Ninject
{
    public class Container
    {
        public Container()
        {

        }

        public StandardKernel GetModules()
        {
            return new StandardKernel(new NinjectModulo());
        }
    }
}
