using MercadoLivreService.App.CustomExceptions;
using MercadoLivreService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Entities.AccountSearchDataFields
{
    public class PaginationEntity
    {
        private static int LimitMin { get; }

        private static int LimitMax { get; }

        private static int OffsetMin { get; }

        public static void Validate(IPaginationIn pagination)
        {
            try
            {
                var limitIsInRange = pagination.Limit >= LimitMin && pagination.Limit <= LimitMax;
                var offsetIsInRange = pagination.Offset >= OffsetMin;

                if (!limitIsInRange)
                {
                    throw new ValidationException("Limit", $"Limite de paginação deve estar entre {LimitMin} e {LimitMax}");
                }
                if (!offsetIsInRange)
                {
                    throw new ValidationException("Offset", $"Offset de paginação deve ter valor mínimo de {OffsetMin}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
