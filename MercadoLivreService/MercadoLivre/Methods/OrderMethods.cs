using MercadoLivreLibrary.Methods.Order;
using MercadoLivreLibrary.Models.Input;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreLibrary.Methods
{
    public class OrderMethods
    {
        public GetDetails GetDetails { get; } = new GetDetails();

        public SearchRecentOrders SearchRecentOrders(long accountId, string token, Pagination pagination) =>
             new SearchRecentOrders(accountId, token, pagination);
    }
}
