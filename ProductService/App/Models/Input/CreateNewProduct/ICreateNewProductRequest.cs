using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.Models.Input
{
    public interface ICreateNewProductRequest
    {
        string Name { get; }
        string Description { get; }
        string Category { get; }
        string Brand { get; }
        string Model { get; }
        ProductColor Color { get; }
        ProductCondition Condition { get; }
        List<string> PicturesUrls { get; }
        ProductWarranty Warranty { get; }
    }

}
