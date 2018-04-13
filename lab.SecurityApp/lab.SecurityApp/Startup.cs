using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(lab.SecurityApp.Startup))]
namespace lab.SecurityApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
