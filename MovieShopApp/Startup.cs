using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieShopApp.Startup))]
namespace MovieShopApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
