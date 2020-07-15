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
                account.Tokens = await ValidateAccessToken.Execeute(account);
                var search = await SearchRecentOrders.Execute(account);
                Console.WriteLine();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task GetOrderDetailById(long orderId, long mercadoLivreAccountId)
        {
            try
            {
                //var account = await AccountUseCaseController.GetAccountByIdAsync(id);
                //await ValidateAccessToken.Execeute(account);
                //var search = await SearchRecentOrders.Execute(account);
                Console.WriteLine();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
