using lab.SBThemeApps.Controllers;
using lab.SBThemeApps.Manager;
using lab.SBThemeApps.Repository;
using System.Web.Mvc;
using Unity;
using Unity.Injection;

namespace lab.SBThemeApps
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());

            //container.RegisterType<IRepositoryBase, RepositoryBase>();
            //container.RegisterType<IManagerBase, ManagerBase>();

            container.RegisterType<IStudentRepository, StudentRepository>();
            container.RegisterType<IStudentManager, StudentManager>();

            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
            //GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}