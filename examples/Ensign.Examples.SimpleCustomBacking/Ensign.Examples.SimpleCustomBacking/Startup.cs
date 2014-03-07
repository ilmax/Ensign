using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EnsignLib.Examples.SimpleCustomBacking.Startup))]
namespace EnsignLib.Examples.SimpleCustomBacking
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
