using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Ninject.Parameters;
using lab.SecurityApp.IoC.Models;
using lab.SecurityApp.IoC.Repository;
using lab.SecurityApp.IoC.Service;

namespace lab.SecurityApp.IoC.Helpers
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

    public static class NinjectConfigHelper
    {
        public static void Resolve()
        {
            var kernel = new StandardKernel();

            #region EF

            const string efParamName = "AppDbContext";
            var efDbContext = new AppDbContext();

            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>)).WithConstructorArgument(efParamName, efDbContext);
            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>)).WithConstructorArgument(efParamName, efDbContext);

            kernel.Bind(typeof(IStudentRepository)).To(typeof(StudentRepository)).WithConstructorArgument(efParamName, efDbContext);
            kernel.Bind(typeof(IStudentService)).To(typeof(StudentService)).WithConstructorArgument(efParamName, efDbContext);

            #endregion

            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}