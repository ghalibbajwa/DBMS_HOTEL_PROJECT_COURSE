using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DBMS_HOTEL_PROJECT_COURSE.Startup))]
namespace DBMS_HOTEL_PROJECT_COURSE
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
