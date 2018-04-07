using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(DataAccessAPI.Startup))]
namespace DataAccessAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureOAuth(app);
        }
    }
}