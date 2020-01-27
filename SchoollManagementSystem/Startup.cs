using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SchoollManagementSystem.Startup))]
namespace SchoollManagementSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
