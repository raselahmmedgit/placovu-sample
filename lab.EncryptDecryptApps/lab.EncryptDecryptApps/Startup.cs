using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(lab.EncryptDecryptApps.Startup))]
namespace lab.EncryptDecryptApps
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
