using MercadoLivreService.App.Models;
using MercadoLivreService.MercadoLivre.Models.In;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.MercadoLivre.Methods.Orders
{
    public class OrderMethods
    {
        public GetDetails GetDetails { get; } = new GetDetails();

        public SearchRecentOrders SearchRecentOrders(Account account, PaginationIn pagination) =>
             new SearchRecentOrders(account, pagination);
    }
}
