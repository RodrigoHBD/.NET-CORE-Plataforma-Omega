using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductService.App.CustomExceptions;

namespace ProductService.App.Entities.ProductDataFields
{
    public class Name
    {
        private static int MinimumLength { get; } = 3;
        public static void Validate(string name)
        {
            try
            {
                var isTooShort = name.Length < MinimumLength;

                if (isTooShort)
                {
                    throw new ValidationException("Nome do produto", $"Nome precisa conter no mínimo {MinimumLength} caracteres");
                }
                return;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
