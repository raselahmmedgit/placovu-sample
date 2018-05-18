using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using Autofac.Integration.Mvc;
using lab.SecurityApp.IoC.Repository;
using lab.SecurityApp.IoC.Service;
using lab.SecurityApp.IoC.Models;

namespace lab.SecurityApp.IoC.Helpers
{
    public static class AutofacConfigHelper
    {
        public static void Resolve()
        {
            try
            {
                //Implement Autofac

                var builder = new ContainerBuilder();

                // Register MVC controllers using assembly scanning.
                builder.RegisterControllers(Assembly.GetExecutingAssembly());

                //builder.Register<IStudentRepository>(c => new StudentRepository(new AppDbContext()));
                //builder.Register<IStudentService>(c => new StudentService(new AppDbContext()));

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