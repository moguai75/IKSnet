using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IKSnet.Startup))]
namespace IKSnet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
