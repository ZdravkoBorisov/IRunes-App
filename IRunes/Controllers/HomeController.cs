namespace IRunes.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;

    using Services;
    using ViewModels.Home;

    public class HomeController : Controller
    {
        private readonly IUsersService usersService;

        public HomeController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                var viewModel = new IndexViewModel();

                viewModel.Username = this.usersService
                                            .GetUsername(this.User);

                return this.View(viewModel, "Home");
            }

            return this.View();
        }

        [HttpGet("/Home/Index")]
        public HttpResponse IndexFullPage()
        {
            return this.Index();
        }
    }
}
