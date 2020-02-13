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

        public PackagesService(ApplicationDbContext db)
        {
            this.db = db;
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

        public IQueryable<Package> GetAllByStatus(Status status )
        {
            var packages = this.db.Packages
                    .Where(x => x.Status == status); 

            return packages;
        }
    }
}
