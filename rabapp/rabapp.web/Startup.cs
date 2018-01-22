using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(rabapp.web.Startup))]
namespace rabapp.web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
