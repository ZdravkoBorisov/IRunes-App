using Panda.Services;
using Panda.ViewModels.Home;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panda.Controllers
{
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
                viewModel.Username = this.usersService.GetUsername(this.User);

                return this.View(viewModel, "IndexLoggedIn");
            }

            return this.View();
        }

        [HttpGet("/Home/Index")]
        public HttpResponse LoggedIndex()
        {
            return this.Index();
        }
    }
}
