using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(lab.SBThemeApps.Startup))]
namespace lab.SBThemeApps
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
