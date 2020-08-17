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
        public static async Task SearchRecentOrdersAsync(string id)
        {
            try
            {
                var account = await AccountUseCaseController.GetAccountByIdAsync(id);
                account.Tokens = await GetValidAccessToken.Execeute(id);
                var search = await SearchRecentOrders.Execute(account);
                Console.WriteLine();
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
