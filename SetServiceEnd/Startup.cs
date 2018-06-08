using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SetServiceEnd.Startup))]
namespace SetServiceEnd
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
