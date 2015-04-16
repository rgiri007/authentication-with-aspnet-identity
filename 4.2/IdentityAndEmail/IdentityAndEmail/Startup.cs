using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IdentityAndEmail.Startup))]
namespace IdentityAndEmail
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
