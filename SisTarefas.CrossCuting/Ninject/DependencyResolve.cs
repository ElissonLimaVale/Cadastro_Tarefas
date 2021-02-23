
using Ninject;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace SisTarefas.CrossCuting.Ninject
{
    public class DependencyResolve: IDependencyResolver
    {
        private IKernel _kernel;

        public DependencyResolve()
        {
            _kernel = RegisterServices();
            _kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            _kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
        }

        public DependencyResolve(IKernel kernel)
        {
            _kernel = kernel;
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        public static StandardKernel RegisterServices()
        {
            return new Container().GetModules();
        }
    }
}
