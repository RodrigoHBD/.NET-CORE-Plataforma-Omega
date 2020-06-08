using ProductService.App.CustomExceptions;
using ProductService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.Entities.ProductDataFields
{
    public class Warranty
    {
        private static int MinumumWarrantyTimeInDays = 10; 
        public static void Validate(ProductWarranty warranty)
        {
            try
            {
                var warrantyTimeTooSmall = warranty.TimeInDays < MinumumWarrantyTimeInDays;

                if (warrantyTimeTooSmall)
                {
                    throw new ValidationException("Tempo de Garantia do Produto", $"Tempo de garantia não pode ser menor que: {MinumumWarrantyTimeInDays}");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
