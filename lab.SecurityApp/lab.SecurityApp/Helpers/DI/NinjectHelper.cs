using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using lab.SecurityApp.Models;
using lab.SecurityApp.Service;
using lab.SecurityApp.Repository;
using lab.SecurityApp.Helpers.Dapper;
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

    public class NinjectHelper
    {
        public void Resolve()
        {
            var kernel = new StandardKernel();

            #region Dapper
            const string dapperParamName = "AppDapperDbContext";
            var dapperDbContext = new AppDapperDbContext();

            kernel.Bind(typeof(IBaseRepository<>)).To(typeof(BaseRepository<>)).WithConstructorArgument(dapperParamName, dapperDbContext);
            kernel.Bind(typeof(IBaseService<>)).To(typeof(BaseService<>)).WithConstructorArgument(dapperParamName, dapperDbContext);

            #region User Management

            kernel.Bind(typeof(IRoleRepository)).To(typeof(RoleRepository)).WithConstructorArgument(dapperParamName, dapperDbContext);
            kernel.Bind(typeof(IRoleService)).To(typeof(RoleService)).WithConstructorArgument(dapperParamName, dapperDbContext);

            #endregion
            #endregion

            #region EF

            //const string efParamName = "AppDbContext";
            //var efDbContext = new AppDbContext();

            //kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            //kernel.Bind<IDatabaseFactory>().To<DatabaseFactory>();

            //kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>)).WithConstructorArgument(efParamName, efDbContext);
            //kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>)).WithConstructorArgument(efParamName, efDbContext);

            //kernel.Bind(typeof(IApplicationInfoRepository)).To(typeof(ApplicationInfoRepository)).WithConstructorArgument(efParamName, efDbContext);
            //kernel.Bind(typeof(IApplicationInfoService)).To(typeof(ApplicationInfoService)).WithConstructorArgument(efParamName, efDbContext);

            #endregion

            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}