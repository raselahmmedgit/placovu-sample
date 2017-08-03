using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(lab.lightbootstrapapps.Startup))]
namespace lab.lightbootstrapapps
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
