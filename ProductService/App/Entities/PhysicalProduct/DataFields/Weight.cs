using ProductService.App.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.Entities.PhysicalProductDataFields
{
    public class Weight
    {
        private static double MinimumWeight = 0.01;
        private static double MaximumWeight;
        public static void Valdiate(double weight)
        {
            try
            {
                var isTooLight = weight < MinimumWeight;

                if (isTooLight)
                {
                    throw new ValidationException("Peso do Produto", $"Não pode pesar menos que {MinimumWeight}");
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
