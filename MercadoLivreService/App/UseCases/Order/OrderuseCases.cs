using MercadoLivreService.App.UseCases.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.UseCases
{
    public class OrderUseCases
    {
        public static GetOrderDetails GetDetails { get; } = new GetOrderDetails();

        public static CheckAllRecentOrders CheckAllRecentOrders { get { return new CheckAllRecentOrders(); } }

        public static GetOrderPackId GetPackId { get { return new GetOrderPackId(); } }
    }
}
