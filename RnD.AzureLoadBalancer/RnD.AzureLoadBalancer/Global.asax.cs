using RnD.AzureLoadBalancer.App_Start;
using System;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.WebPages;

namespace RnD.AzureLoadBalancer
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //AutoMapper
            AutoMapperConfig.RegisterMapper();

            //Enable xml configuration file for log4net
            var configFile = ConfigurationManager.AppSettings.Get("log4net.Config");
            if (!string.IsNullOrEmpty(configFile))
            {
                configFile = Environment.ExpandEnvironmentVariables(configFile);
                log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(@configFile));
            }

            // Display Mode for Mobile View
            DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("WP")
            {
                ContextCondition = (context => context.GetOverriddenUserAgent().
                    IndexOf("Windows Phone OS", StringComparison.OrdinalIgnoreCase) >= 0)
            });

            DisplayModeProvider.Instance.Modes.Insert(1, new DefaultDisplayMode("iPhone")
            {
                ContextCondition = (context => context.GetOverriddenUserAgent().
                    IndexOf("iPhone", StringComparison.OrdinalIgnoreCase) >= 0)
            });

            DisplayModeProvider.Instance.Modes.Insert(2, new DefaultDisplayMode("Android")
            {
                ContextCondition = (context => context.GetOverriddenUserAgent().
                    IndexOf("Android", StringComparison.OrdinalIgnoreCase) >= 0)
            });
        }

        protected void Application_BeginRequest()
        {
            if (!HttpContext.Current.IsDebuggingEnabled)
            {
                if (!Context.Request.IsSecureConnection)
                {
                    Response.Redirect(Context.Request.Url.ToString().Replace("http:", "https:"));
                }
            }
        }

        void Session_Start(object sender, EventArgs e)
        {
            var timeOutInMinute = ConfigurationManager.AppSettings["SessionTimoutAfterLoginInMinute"] == null ? 1440 : int.Parse(ConfigurationManager.AppSettings["SessionTimoutAfterLoginInMinute"]);
            Session["SessionExpiry"] = DateTime.Now.AddMinutes(timeOutInMinute);
        }

        void Application_AcquireRequestState(object sender, EventArgs e)
        {
            try
            {
                if (base.Context.Session != null && base.Context.Session["SessionExpiry"] != null)
                {
                    DateTime expiry = (DateTime)base.Context.Session["SessionExpiry"];

                    if (expiry <= DateTime.Now)
                    {
                        Session.Clear();

                        // the abandoned session won't kick in until the next page request.
                        // here I am redirecting back to the current page, but you may want to do something else
                        // like redirect to a "Session Expired" page.
                        Response.Redirect("/Account/Logoff");
                        base.Context.ApplicationInstance.CompleteRequest();
                    }
                }

            }
            catch (Exception)
            {

            }
        }
    }
}
