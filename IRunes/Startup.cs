namespace IRunes
{
    using System.Collections.Generic;

    using SIS.HTTP;
    using SIS.MvcFramework;

    using Services;

    public class Startup : IMvcApplication
    {
        public void Configure(IList<Route> routeTable)
        {
            new ApplicationDbContext().Database.EnsureCreated();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<IAlbumsService, AlbumsService>();
            serviceCollection.Add<ITracksService, TracksService>();
        }
    }
}
