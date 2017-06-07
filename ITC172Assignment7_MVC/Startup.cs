using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ITC172Assignment7_MVC.Startup))]
namespace ITC172Assignment7_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
