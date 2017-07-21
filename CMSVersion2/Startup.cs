using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CMSVersion2.Startup))]
namespace CMSVersion2
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
