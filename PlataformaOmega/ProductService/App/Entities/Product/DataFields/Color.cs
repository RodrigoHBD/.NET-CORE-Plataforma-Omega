using ProductService.App.CustomExceptions;
using ProductService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.Entities.ProductDataFields
{
    public class Color
    {
        public static void Validate(ProductColor color)
        {
            try
            {
                var enumMax = ProductColor.White;
                var enumMin = ProductColor.Black;
                var colorIsOutOfRange = (color > enumMax) || (color < enumMin);

                if (color == ProductColor.Invalid)
                {
                    throw new ValidationException("Cor", "Cor Não Existe");
                }
                if (colorIsOutOfRange)
                {
                    throw new ValidationException("Cor", "Cor Inválida");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
