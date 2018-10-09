using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(evaluacoinASP.Startup))]
namespace evaluacoinASP
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
