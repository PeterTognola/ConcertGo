using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ConcertGo.Startup))]
namespace ConcertGo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
