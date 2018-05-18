using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Unity;
using Unity.Lifetime;

namespace lab.DISample.Helpers.IoC
{
    public class UnityControllerFactory : DefaultControllerFactory
    {
        IUnityContainer container;
        public UnityControllerFactory(IUnityContainer container)
        {
            this.container = container;
        }
        protected override IController GetControllerInstance(RequestContext reqContext, Type controllerType)
        {
            IController controller;
            if (controllerType == null)
                throw new HttpException(
                        404, String.Format(
                            "The controller for path '{0}' could not be found" +
            "or it does not implement IController.",
                        reqContext.HttpContext.Request.Path));

            if (!typeof(IController).IsAssignableFrom(controllerType))
                throw new ArgumentException(
                        string.Format(
                            "Type requested is not a controller: {0}",
                            controllerType.Name),
                            "controllerType");
            try
            {
                //controller = MvcUnityContainer.Container.Resolve(controllerType)
                //                as IController;
                controller = container.Resolve(controllerType) as IController;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(String.Format(
                                        "Error resolving controller {0}",
                                        controllerType.Name), ex);
            }
            return controller;
        }

    }
    public class HttpContextLifetimeManager<T> : LifetimeManager, IDisposable
    {
        public void Dispose()
        {
            if (HttpContext.Current != null)
                HttpContext.Current.Items.Remove(typeof(T).AssemblyQualifiedName);
        }

        public override object GetValue(ILifetimeContainer container = null)
        {
            if (HttpContext.Current != null && HttpContext.Current.Items.Contains(typeof(T).AssemblyQualifiedName))
            { return HttpContext.Current.Items[typeof(T).AssemblyQualifiedName]; }
            else
            { return null; }
              
        }

        protected override LifetimeManager OnCreateLifetimeManager()
        {
            throw new NotImplementedException();
        }
    }
}