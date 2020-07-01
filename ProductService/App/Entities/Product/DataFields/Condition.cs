using ProductService.App.CustomExceptions;
using ProductService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.Entities.ProductDataFields
{
    public class Condition
    {
        public static void Validate(ProductCondition condition)
        {
            try
            {
                var enumMax = ProductCondition.Invalid;
                var enumMin = ProductCondition.New;
                var conditionIsOutOfRange = (condition > enumMax) || (condition < enumMin);

                if (condition == ProductCondition.Invalid)
                {
                    throw new ValidationException("Condição do Porduto", "Condição Não Existe");
                }
                if (conditionIsOutOfRange)
                {
                    throw new ValidationException("Condição do Porduto", "Condição Inválida");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
