using MercadoLivreLibrary;
using MercadoLivreLibrary.Models;
using MercadoLivreService.App.UseCases.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.UseCases
{
    public class GetOrderDetails
    {
        public async Task<OrderDetailJson> Execute(long accountId, long orderId)
        {
			try
			{
				//TODO => validate account id
				var token = await GetToken(accountId);
				return await MercadoLivreLib.Methods.Order.GetDetails.Execute(orderId, accountId, token);
			}
			catch (Exception e)
			{
				throw;
			}
        }

		private async Task<string> GetToken(long accountId)
        {
			return await TokensUseCases.GetValidAccessToken.ForAccount(accountId);
        }

    }
}
