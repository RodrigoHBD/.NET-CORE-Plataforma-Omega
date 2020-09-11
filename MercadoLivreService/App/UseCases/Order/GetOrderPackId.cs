using MercadoLivreService.MercadoLivreModels.Out;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.UseCases.Order
{
    public class GetOrderPackId
    {
        public async Task<long?> Execute(long accountId, long orderId)
        {
            try
            {
                var details = await GetDetailJson(accountId, orderId);
                return GetPackId(details);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<OrderDetailJson> GetDetailJson(long accountId, long orderId)
        {
            return await OrderUseCases.GetDetails.Execute(accountId, orderId);
        }

        private long? GetPackId(OrderDetailJson details)
        {
            return details.pack_id;
        }
    }
}
