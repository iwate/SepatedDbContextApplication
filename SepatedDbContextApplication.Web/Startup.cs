using Microsoft.Owin;
using SepatedDbContextApplication.DataAccess;
using Owin;
[assembly: OwinStartup(typeof(SepatedDbContextApplication.Web.Startup))]
namespace SepatedDbContextApplication.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            ConfigureData(app);
        }
    }
}