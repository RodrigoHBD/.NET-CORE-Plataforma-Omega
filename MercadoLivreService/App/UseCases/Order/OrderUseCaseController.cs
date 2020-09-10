using MercadoLivreService.App.Entities;
using MercadoLivreService.MercadoLivreModels.Out;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.UseCases
{
    public class OrderUseCaseController
    {
        public static async Task CheckAllRecentOrders(string id)
        {
            try
            {
                await AccountUseCases.RefreshTokensDynamically.Execute(id);
                await OrderUseCases.CheckAllRecentOrders.Execute(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<OrderDetailJson> GetOrderDetailById(long orderId, long mercadoLivreAccountId)
        {
            try
            {
                await AccountUseCases.RefreshTokensDynamically.ExecuteByMercadoLivreId(mercadoLivreAccountId);
                await AccountEntity.ValidateMercadoLivreId(mercadoLivreAccountId);
                var details = await OrderUseCases.GetDetails.Execute(mercadoLivreAccountId, orderId);
                return details;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
