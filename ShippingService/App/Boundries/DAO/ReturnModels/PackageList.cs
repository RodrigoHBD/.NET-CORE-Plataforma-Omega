using ShippingService.App.Models;
using ShippingService.App.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Boundries.DAO.ReturnModels
{
    public class PackageList : IPackageList
    {
        public List<Package> Packages { get; set; }

        public IPaginationOut Pagination { get; set; }
    }
}
