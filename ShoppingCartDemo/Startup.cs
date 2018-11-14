using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShoppingCartDemo.Startup))]
namespace ShoppingCartDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
