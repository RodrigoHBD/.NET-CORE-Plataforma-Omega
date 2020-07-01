using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.Entities.ProductDataFields
{
    public class Brand
    {
        public static async Task Validate(string brand)
        {
            try
            {
                await BrandEntity.ValidateExistent(brand);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
