using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(testD.Startup))]
namespace testD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
