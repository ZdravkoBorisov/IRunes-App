using Panda.Models;
using Panda.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Panda.Services
{
    public interface IPackagesService
    {
        void CreatePackage(string description, decimal weight, string shippingAddress, string recipientName);

        IQueryable<Package> GetAllByStatus(Status status);

        void Deliver(string id);
    }
}
