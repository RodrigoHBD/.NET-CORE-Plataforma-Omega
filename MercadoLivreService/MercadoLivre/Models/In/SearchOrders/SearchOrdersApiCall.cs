using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.MercadoLivreModels.In
{
    public class SearchOrdersApiCall : ApiCall
    {
        public long BuyerId { get; set; }
        public string OrderId { get; set; }
        public long SellerId { get; set; }
    }
}
