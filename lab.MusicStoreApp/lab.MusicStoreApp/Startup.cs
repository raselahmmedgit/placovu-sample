using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(lab.MusicStoreApp.Startup))]
namespace lab.MusicStoreApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
