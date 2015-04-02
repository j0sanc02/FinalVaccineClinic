using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UniversityofLouisvilleVaccine.Startup))]
namespace UniversityofLouisvilleVaccine
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
