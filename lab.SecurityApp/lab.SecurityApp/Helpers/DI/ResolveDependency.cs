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

namespace lab.SecurityApp.Helpers.DI
{
    public class ResolveDependency
    {
        public void Resolve()
        {
            const string paramName = "AppDapperDbContext";
            var kernel = new StandardKernel();
            var dbContext = new AppDapperDbContext();

            kernel.Bind(typeof(IBaseService<>)).To(typeof(BaseService<>)).WithConstructorArgument(paramName, dbContext);
            kernel.Bind(typeof(IBaseRepository<>)).To(typeof(BaseRepository<>)).WithConstructorArgument(paramName, dbContext);

            #region User Management

            kernel.Bind(typeof(IRoleRepository)).To(typeof(RoleRepository)).WithConstructorArgument(paramName, dbContext);
            kernel.Bind(typeof(IRoleService)).To(typeof(RoleService)).WithConstructorArgument(paramName, dbContext);
            
            #endregion
                       

            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}