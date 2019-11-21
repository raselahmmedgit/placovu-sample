using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChartDemoApp.Startup))]
namespace ChartDemoApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
