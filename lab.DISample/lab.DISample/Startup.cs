using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(lab.DISample.Startup))]
namespace lab.DISample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
