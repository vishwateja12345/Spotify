using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SpotifyAPIClient.Startup))]
namespace SpotifyAPIClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
