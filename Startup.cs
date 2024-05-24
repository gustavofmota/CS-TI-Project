using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TI_Project.Startup))]
namespace TI_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
