using MercadoLivreService.App.Boundries;
using MercadoLivreService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.UseCases
{
    public class GetRefreshedTokens
    {
        public async Task<AccountTokens> Execute(string refreshToken)
        {
            try
            {
                return await MercadoLivreBoundry.RefreshTokens(refreshToken);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
