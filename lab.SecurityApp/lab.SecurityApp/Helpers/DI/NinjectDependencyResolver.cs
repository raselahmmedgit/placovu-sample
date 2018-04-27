using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Ninject;
using Ninject.Parameters;

namespace lab.SecurityApp.Helpers.DI
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
        }
        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType, new IParameter[0]);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType, new IParameter[0]);
        }
    }
}