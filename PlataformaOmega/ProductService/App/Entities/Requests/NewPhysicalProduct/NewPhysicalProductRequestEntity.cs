using ProductService.App.Entities.PhysicalProductDataFields;
using ProductService.App.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.Entities
{
    public class NewPhysicalProductRequestEntity
    {
        public static async Task ValidateRequest(ICreateNewPhysicalProductRequest request)
        {
            try
            {
                await NewProductRequestEntity.ValidateRequest(request);
                await ValidateDataFields(request);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static async Task ValidateDataFields(ICreateNewPhysicalProductRequest request)
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
