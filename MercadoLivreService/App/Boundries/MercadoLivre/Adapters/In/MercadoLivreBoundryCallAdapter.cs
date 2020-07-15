using MercadoLivreService.App.Boundries.MercadoLivreModels;
using MercadoLivreService.MercadoLivreModels.In;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Boundries.MercadoLivreAdapters
{
    public class MercadoLivreBoundryCallAdapter
    {
        public static SearchOrdersApiCall AdaptToSearchOrdersApiCall(MercadoLivreBoundryCall call)
        {
            try
            {
                return new SearchOrdersApiCall()
                {
                    AccessToken = call.AccessToken,
                    SellerId = call.SellerId
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
