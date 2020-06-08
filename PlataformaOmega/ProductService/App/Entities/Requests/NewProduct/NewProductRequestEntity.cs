using ProductService.App.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.Entities
{
    public class NewProductRequestEntity
    {
        public static async Task ValidateRequest(ICreateNewProductRequest request)
        {
            try
            {
                
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
