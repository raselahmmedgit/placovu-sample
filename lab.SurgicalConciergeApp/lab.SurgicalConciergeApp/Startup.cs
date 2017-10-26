using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(lab.SurgicalConciergeApp.Startup))]
namespace lab.SurgicalConciergeApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
