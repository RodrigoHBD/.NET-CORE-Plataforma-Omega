using ProductService.App.Entities.PhysicalProductDataFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.Models
{
    public class PhysicalProduct : Product
    {
        public double Weight { get; set; }
        public PhysicalProductMeasurements Measurements { get; set; }
        public PhysicalProduct()
        {
            Measurements = new PhysicalProductMeasurements();
            Type = "Physical";
        }
    }

    public class PhysicalProductMeasurements
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
    }
}
