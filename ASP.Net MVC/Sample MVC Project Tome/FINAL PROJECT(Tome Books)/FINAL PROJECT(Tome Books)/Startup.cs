using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FINAL_PROJECT_Tome_Books_.Startup))]
namespace FINAL_PROJECT_Tome_Books_
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
