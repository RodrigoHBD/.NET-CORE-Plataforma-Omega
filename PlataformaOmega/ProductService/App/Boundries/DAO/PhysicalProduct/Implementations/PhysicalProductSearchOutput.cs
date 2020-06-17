using ProductService.App.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.Boundries.DAO
{
    public class PhysicalProductSearchOutput : IPhysicalProductSearchOutput
    {
        public List<Models.PhysicalProduct> Products { get; set; }

        public IPaginationOut Pagination { get; set; }
    }
}
