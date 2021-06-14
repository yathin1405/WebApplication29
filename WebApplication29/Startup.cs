using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebApplication29.Startup))]
namespace WebApplication29
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
