using IRunes.Services;
using IRunes.ViewModels.Users;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRunes.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Login()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginInputModel input)
        {
            var userId = this.usersService.GetUserId(input.Username, input.Password);
           
            if (userId != null)
            {
                this.SignIn(userId);
                return this.Redirect("/");
            }

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel inputModel)
        {
            if (string.IsNullOrWhiteSpace(inputModel.Email))
            {
                return this.Error("Email cannot be empty!");
            }

            if (inputModel.Username.Length < 4 || inputModel.Username.Length > 10)
            {
                return this.Error("Username must be between 4 and 10 characters!");
            }

            if (inputModel.Password.Length < 6 || inputModel.Password.Length > 20)
            {
                return this.Error("Password must be between 4 and 20 characters!");
            }

            if (inputModel.Password != inputModel.ConfirmPassword)
            {
                return this.Error("Passwords should match");
            }

            if (this.usersService.EmailExist(inputModel.Email))
            {
                return this.Error("Email already in use!");
            }

            if (this.usersService.UserExist(inputModel.Username))
            {
                return this.Error("Username already in use!");
            }

            this.usersService.Register(inputModel.Username, inputModel.Email, inputModel.Password);

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            this.SignOut();
            return this.Redirect("/");
        }
    }
}
