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
        private static int DefaultLimit { get; } = 30;
        public static void Validate(IPaginationIn pagination)
        {
            try
            {
                var limitIsInRange = pagination.Limit >= LimitMin && pagination.Limit <= LimitMax;
                var limitIsZero = pagination.Limit == 0;

                if (!limitIsInRange)
                {
                    throw new ValidationException("Limite da paginação", $"Está fora do alcance de {LimitMin} a {LimitMax}");
                }
                if (limitIsZero)
                {
                    pagination.Limit = DefaultLimit;
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
