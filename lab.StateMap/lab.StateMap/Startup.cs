using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(lab.StateMap.Startup))]
namespace lab.StateMap
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
