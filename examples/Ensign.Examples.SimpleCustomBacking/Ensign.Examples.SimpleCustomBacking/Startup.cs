using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ensign.Examples.SimpleCustomBacking.Startup))]
namespace Ensign.Examples.SimpleCustomBacking
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
