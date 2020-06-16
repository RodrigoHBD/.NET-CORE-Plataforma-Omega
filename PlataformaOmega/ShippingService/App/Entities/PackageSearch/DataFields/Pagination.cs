using ShippingService.App.CustomExceptions;
using ShippingService.App.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Entities.PackageSearchDataFields
{
    public class Pagination
    {
        private static int LimitMax { get; } = 40;
        private static int LimitMin { get; } = 0;
        public static void Validate(IPaginationIn pagination)
        {
            try
            {
                var limitIsInRange = pagination.Limit >= LimitMin && pagination.Limit <= LimitMax;

                if (!limitIsInRange)
                {
                    throw new ValidationException("Limite da paginação", $"Está fora do alcance de {LimitMin} a {LimitMax}");
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
