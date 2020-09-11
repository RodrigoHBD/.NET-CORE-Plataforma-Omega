using MercadoLivreService.App.Entities.AccountSearchDataFields;
using MercadoLivreService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Entities
{
    public class AccountSearchEntity
    {
        public static async Task ValidateSearch(SearchAccountsReq request)
        {
            try
            {
                await ValidateDataFields(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static async Task ValidateDataFields(SearchAccountsReq request)
        {
            try
            {
                PaginationEntity.Validate(request.Pagination);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
