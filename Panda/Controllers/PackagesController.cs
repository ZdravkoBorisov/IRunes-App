using Panda.Models.Enums;
using Panda.Services;
using Panda.ViewModels.Packages;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Panda.Controllers
{
    public class PackagesController : Controller
    {
        private readonly IPackagesService packagesService;
        private readonly IUsersService usersService;

        public PackagesController(IPackagesService packagesService, IUsersService usersService)
        {
            this.packagesService = packagesService;
            this.usersService = usersService;
        }
        public HttpResponse Details()
        {
            return this.View();
        }

        public HttpResponse Create()
        {
            var list = this.usersService.GetUsernames();
            return this.View(list);
        }

        [HttpPost]
        public HttpResponse Create(CreateInputModel input)
        {
            this.packagesService.CreatePackage(input.Description, input.Weight, input.ShippingAddres, input.RecipientName);

            return this.Redirect("/Packages/Pending");
        }

        public HttpResponse Delivered()
        {
            var packages = this.packagesService
                                   .GetAllByStatus(Status.Delivered)
                                   .Select(x => new PackageInputModel
                                   {
                                       Description = x.Description,
                                       Id = x.Id,
                                       Weight = x.Weight,
                                       ShippingAddress = x.ShippingAddress,
                                       RecipientName = x.Recipient.Username
                                   })
                                   .ToList();

            return this.View(new PackagesListViewModel { Packages = packages });

        }

        public HttpResponse Pending()
        {
            var packages = this.packagesService
                                    .GetAllByStatus(Status.Pending)
                                     .Select(x => new PackageInputModel
                                     {
                                         Description = x.Description,
                                         Id = x.Id,
                                         Weight = x.Weight,
                                         ShippingAddress = x.ShippingAddress,
                                         RecipientName = x.Recipient.Username
                                     })
                                     .ToList(); 

            return this.View(new PackagesListViewModel { Packages = packages});
        }
    }
}
