using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GoolgleZonas.Startup))]
namespace GoolgleZonas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
