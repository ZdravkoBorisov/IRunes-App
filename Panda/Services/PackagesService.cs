using Panda.Models;
using Panda.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Panda.Services
{
    public class PackagesService : IPackagesService
    {
        private readonly ApplicationDbContext db;
        private readonly IReceiptsService receiptsService;

        public PackagesService(ApplicationDbContext db, IReceiptsService receiptsService)
        {
            this.db = db;
            this.receiptsService = receiptsService;
        }
        public void CreatePackage(string description, decimal weight, string shippingAddress, string recipientName)
        {
            var recipientId = this.db.Users
                .Where(x => x.Username == recipientName)
                    .Select(x => x.Id)
                        .FirstOrDefault();

            var package = new Package
            {
                Description = description,
                Weight = weight,
                Status = Status.Pending,
                RecipientId = recipientId,
                ShippingAddress = shippingAddress
            };

            this.db.Packages.Add(package);
            this.db.SaveChanges();
        }

        public void Deliver(string id)
        {
            var package = this
                .db.Packages
                .Where(x => x.Id == id)
                .FirstOrDefault();

            package.Status = Status.Delivered;

            this.db.SaveChanges(); 
            this.receiptsService.CreateFromPackage(package.Weight, package.Id, package.RecipientId);

        }

        public IQueryable<Package> GetAllByStatus(Status status)
        {
            var packages = this.db.Packages
                    .Where(x => x.Status == status);

            return packages;
        }


    }
}
