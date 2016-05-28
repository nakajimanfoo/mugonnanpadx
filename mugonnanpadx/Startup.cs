using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mugonnanpadx.Startup))]
namespace mugonnanpadx
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
