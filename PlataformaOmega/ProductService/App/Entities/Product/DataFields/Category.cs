using ProductService.App.CustomExceptions;
using ProductService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.Entities.ProductDataFields
{
    public class Category
    {
        public static void Validate(ProductCategory category)
        {
            try
            {
                var enumMax = ProductCategory.Invalid;
                var enumMin = ProductCategory.Teste;
                var categoryIsOutOfRange = (category > enumMax) || (category < enumMin);

                if (category == ProductCategory.Invalid)
                {
                    throw new ValidationException("Categoria", "Categoria Não Existe");
                }
                if (categoryIsOutOfRange)
                {
                    throw new ValidationException("Categoria", "Categoria Inválida");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
