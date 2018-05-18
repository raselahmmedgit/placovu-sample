using lab.DISample.Repository;
using lab.DISample.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;

namespace lab.DISample.Helpers.IoC
{
    public static class UnityConfigHelper
    {
        public static void Resolve()
        {
            IUnityContainer container = new UnityContainer();

            //container.RegisterType<IDatabaseFactory, DatabaseFactory>(new HttpContextLifetimeManager<IDatabaseFactory>());
            //container.RegisterType<IUnitOfWork, UnitOfWork>(new HttpContextLifetimeManager<IUnitOfWork>());

            container.RegisterType<IStudentRepository, StudentRepository>(new HttpContextLifetimeManager<IStudentRepository>());
            container.RegisterType<IStudentService, StudentService>(new HttpContextLifetimeManager<IStudentService>());

            //container.RegisterType<IStudentRepository, StudentRepository>();
            //container.RegisterType<IStudentService, StudentService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}