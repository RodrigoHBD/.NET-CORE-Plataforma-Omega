using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.Models.Input
{
    public interface ICreateNewPhysicalProductRequest : ICreateNewProductRequest
    {
        double Weight { get; }
        PhysicalProductMeasurements Mesuarments { get; }
    }

}
