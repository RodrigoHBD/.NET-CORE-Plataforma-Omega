using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.Models.Output
{
    public interface IPhysicalProductSearchOutput
    {
        List<PhysicalProduct> Products { get; }
        IPaginationOut Pagination { get; }
    }
}
