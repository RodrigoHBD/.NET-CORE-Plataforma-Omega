using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.MercadoLivreModels.In
{
    public class SearchOrdersApiCall : ApiCall
    {
        public int BuyerId { get; set; }
        public int SellerId { get; set; }
    }
}
