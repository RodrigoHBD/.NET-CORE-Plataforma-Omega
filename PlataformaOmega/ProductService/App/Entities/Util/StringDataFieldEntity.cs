using ProductService.App.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.Entities.Util
{
    public class StringDataFieldEntity
    {
        public static void CheckIfNotNull(string _string, string fieldName)
        {
            if (_string is null)
            {
                throw new ValidationException($"{fieldName}", $"{fieldName} não pode ser nulo");
            }
        }

        public static void CheckIsWithinRange(int min, int max, string _string, string fieldName)
        {
            try
            {
                var isInRange = _string.Length >= min && _string.Length <= max;

                if (!isInRange)
                {
                    throw new ValidationException($"{fieldName}", $"{fieldName} não tem um tamanho válido. Precisa estar entre {min} e {max}");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
