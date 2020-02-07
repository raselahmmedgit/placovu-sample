using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QuizGamingApp.Web.Startup))]
namespace QuizGamingApp.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
