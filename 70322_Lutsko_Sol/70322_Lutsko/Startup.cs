using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_70322_Lutsko.Startup))]
namespace _70322_Lutsko
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
