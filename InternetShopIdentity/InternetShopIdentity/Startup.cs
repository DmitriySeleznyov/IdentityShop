using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InternetShopIdentity.Startup))]
namespace InternetShopIdentity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
