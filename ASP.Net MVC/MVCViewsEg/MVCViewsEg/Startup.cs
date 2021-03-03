using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCViewsEg.Startup))]
namespace MVCViewsEg
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
