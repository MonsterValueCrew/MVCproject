using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MonsterValueCrew.Startup))]
namespace MonsterValueCrew
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
