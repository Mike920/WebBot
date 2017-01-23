using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TravianBot.Startup))]
namespace TravianBot
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
