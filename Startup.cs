using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_21S2_BZ_2.Startup))]
namespace _21S2_BZ_2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
