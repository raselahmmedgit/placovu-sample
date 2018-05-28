using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using lab.SBThemeApps.Models;
using lab.SBThemeApps.Manager;
using lab.SBThemeApps.Repository;
using Ninject.Parameters;

namespace lab.SBThemeApps.Helpers.DI
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

    public static class NinjectConfig
    {
        public static void Resolve()
        {
            var kernel = new StandardKernel();

            const string contextParamName = "dbContext";
            var appDbContext = new AppDbContext();

            kernel.Bind(typeof(IStudentRepository)).To(typeof(StudentRepository)).WithConstructorArgument(contextParamName, appDbContext);
            kernel.Bind(typeof(IStudentManager)).To(typeof(StudentManager)).WithConstructorArgument(contextParamName, appDbContext);

            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}