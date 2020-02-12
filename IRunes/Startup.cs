using SIS.HTTP;
using SIS.MvcFramework;
using System.Collections.Generic;

namespace IRunes
{
    public class Startup : IMvcApplication
    {
        public void Configure(IList<Route> routeTable)
        {
            new ApplicationDbContext().Database.EnsureCreated();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        { 
        }
    }
}
