using Autofac;
using lab.SecurityApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using Autofac.Integration.Mvc;
using lab.SecurityApp.Service;

namespace lab.SecurityApp.Helpers.DI
{
    public class AutofacHelper
    {
        public void Resolve()
        {
            try
            {
                //Implement Autofac

                var builder = new ContainerBuilder();

                // Register MVC controllers using assembly scanning.
                builder.RegisterControllers(Assembly.GetExecutingAssembly());

                // Register MVC controller and API controller dependencies per request.
                builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerDependency();
                builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerLifetimeScope();

                // Register service
                builder.RegisterAssemblyTypes(typeof(ApplicationInfoService).Assembly)
                        .Where(t => t.Name.EndsWith("Service"))
                        .AsImplementedInterfaces().InstancePerDependency();

                // Register repository
                builder.RegisterAssemblyTypes(typeof(ApplicationInfoRepository).Assembly)
                        .Where(t => t.Name.EndsWith("Repository"))
                        .AsImplementedInterfaces().InstancePerDependency();

                var container = builder.Build();

                //for MVC Controller Set the dependency resolver implementation.
                var resolverMvc = new AutofacDependencyResolver(container);
                System.Web.Mvc.DependencyResolver.SetResolver(resolverMvc);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
