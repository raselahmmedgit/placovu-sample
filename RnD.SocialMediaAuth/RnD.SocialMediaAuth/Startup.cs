using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RnD.SocialMediaAuth.Startup))]
namespace RnD.SocialMediaAuth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
