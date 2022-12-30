using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCS00210326.Startup))]
namespace MVCS00210326
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
