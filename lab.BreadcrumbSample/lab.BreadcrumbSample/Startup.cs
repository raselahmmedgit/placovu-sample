using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(lab.BreadcrumbSample.Startup))]
namespace lab.BreadcrumbSample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
