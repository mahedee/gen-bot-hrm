using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HRMBot.Web.Startup))]
namespace HRMBot.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
