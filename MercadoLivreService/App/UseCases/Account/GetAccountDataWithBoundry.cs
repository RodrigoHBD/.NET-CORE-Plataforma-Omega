using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MercadoLivreService.App.Boundries;
using MercadoLivreService.App.Models;
using MercadoLivreService.MercadoLivreModels;
using MercadoLivreService.MercadoLivreModels.In;
using MercadoLivreService.MercadoLivreModels.Out;

namespace MercadoLivreService.App.UseCases
{
    public class GetAccountDataWithBoundry
    {
        public static async Task<AccountSelfDataJson> Execute(string id)
        {
			try
			{
				var account = await AccountUseCases.GetById.Execute(id);
				var call = BuildApiCall(account);
				var result = await MercadoLivreBoundry.GetAccountData(call);
				ValidateJsonDeserialization.Execute(result);
				return (AccountSelfDataJson) result.DeserializedJson;
			}
			catch (Exception)
			{
				throw;
			}
        }

		public static ApiCall BuildApiCall(Account account)
		{
			return new ApiCall()
			{
				AccessToken = account.Tokens.AccessToken
			};
		}

    }
}
