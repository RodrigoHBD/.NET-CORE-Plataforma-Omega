using ProductService.App.CustomExceptions;
using ProductService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.Entities.PhysicalProductDataFields
{
    public class Measurements
    {
        private static int MinumumLength { get; } = 16;

        private static int MinimumHeight { get; } = 2;

        private static int MinimumWidth { get; } = 11;

        public static void Validate(PhysicalProductMeasurements measurements)
        {
            try
            {
                var hasEnoughLength = measurements.Length >= MinumumLength;
                var hasEnoughWidth = measurements.Width >= MinimumWidth;
                var hasEnoughHeight = measurements.Height >= MinimumHeight;

                if (!hasEnoughHeight)
                {
                    throw new ValidationException("Medida de Altura do Produto", $"Altura mínima é {MinimumHeight}");
                }
                if (!hasEnoughLength)
                {
                    throw new ValidationException("Medida de Comprimento do Produto", $"Comprimento mínima é {MinumumLength}");
                }
                if (!hasEnoughWidth)
                {
                    throw new ValidationException("Medida de Largura do Produto", $"Largura mínima é {MinimumWidth}");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
