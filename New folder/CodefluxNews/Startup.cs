using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CodefluxNews.Startup))]
namespace CodefluxNews
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
