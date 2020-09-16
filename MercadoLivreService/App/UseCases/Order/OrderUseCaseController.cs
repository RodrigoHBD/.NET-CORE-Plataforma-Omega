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
                await OrderUseCases.CheckAllRecentOrders.Execute(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
