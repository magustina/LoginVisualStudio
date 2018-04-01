using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(pruebaLogin.Startup))]
namespace pruebaLogin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
