using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PremierMvc.Startup))]
namespace PremierMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
