using MercadoLivreService.App.CustomExceptions;
using MercadoLivreService.App.Models;
using MercadoLivreService.App.Models.In;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Entities.AccountSearchDataFields
{
    public class PaginationEntity
    {
        private static int LimitDefault { get; } = 30;

        private static int LimitMin { get; } = 0;

        private static int LimitMax { get; } = 40;

        private static int OffsetMin { get; }

        public static void Validate(PaginationIn pagination)
        {
            try
            {
                var limitIsInRange = pagination.Limit >= LimitMin && pagination.Limit <= LimitMax;
                var offsetIsInRange = pagination.Offset >= OffsetMin;
                var limitMustBeSetToDefault = pagination.Limit == 0;

                if (!limitIsInRange)
                {
                    throw new ValidationException("Limit", $"Limite de paginação deve estar entre {LimitMin} e {LimitMax}");
                }
                if (!offsetIsInRange)
                {
                    throw new ValidationException("Offset", $"Offset de paginação deve ter valor mínimo de {OffsetMin}");
                }

                if(limitMustBeSetToDefault){
                    pagination.Limit = LimitDefault;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
