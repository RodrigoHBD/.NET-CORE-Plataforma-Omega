using MercadoLivreService.App.Boundries;
using MercadoLivreService.App.Boundries.MercadoLivreModels;
using MercadoLivreService.App.Models;
using MercadoLivreService.MercadoLivreModels.In;
using MercadoLivreService.MercadoLivreModels.Out;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.UseCases
{
    public class SearchRecentOrders
    {
        public static async Task<ApiCallResponse> Execute(Account account)
        {
            try
            {
                var request = new MercadoLivreBoundryCall()
                {
                    AccessToken = account.Tokens.AccessToken,
                    SellerId = account.MercadoLivreId
                };
                var response = await MercadoLivreBoundry.SearchRecentOrdersAsync(request);

                ValidateJsonDeserialization.Execute(response);
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static async Task ProcessSearchResult(ApiCallResponse response)
        {
            try
            {
                if (!response.HasDeserializationException)
                {
                    
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
