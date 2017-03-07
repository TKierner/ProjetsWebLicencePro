using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjetsWebLicencePro.Startup))]
namespace ProjetsWebLicencePro
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
