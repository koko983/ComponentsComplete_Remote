using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ComponentsComplete.Startup))]
namespace ComponentsComplete
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
