using Microsoft.EntityFrameworkCore;
using Panda.Services;
using SIS.HTTP;
using SIS.MvcFramework;
using System.Collections.Generic;

namespace Panda
{
    public class Startup : IMvcApplication
    {
        public void Configure(IList<Route> routeTable)
        {
            var db = new ApplicationDbContext();
            db.Database.Migrate();
        }
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<IPackagesService, PackagesService>();
            serviceCollection.Add<IReceiptsService, ReceiptsService>();
        }
    }
}
