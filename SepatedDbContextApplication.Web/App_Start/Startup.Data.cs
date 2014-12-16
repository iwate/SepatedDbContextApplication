using Owin;
using SepatedDbContextApplication.DataAccess;

namespace SepatedDbContextApplication.Web
{
    public partial class Startup
    {
        public void ConfigureData(IAppBuilder app)
        {
            app.CreatePerOwinContext(DataContext.Create);
        }
    }
}