using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MonsterValueCrew_Project.Startup))]
namespace MonsterValueCrew_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
