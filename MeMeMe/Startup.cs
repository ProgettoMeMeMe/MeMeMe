using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MeMeMe.Startup))]
namespace MeMeMe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
