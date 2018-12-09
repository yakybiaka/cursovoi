using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BusTour.Startup))]
namespace BusTour
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
