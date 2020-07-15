using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Boundries.MercadoLivreModels
{
    public class MercadoLivreBoundryCall : IMercadoLivreBoundryCall
    {
        public string AccessToken { get; set; } = "";

        public string AppId { get; set; } = "";

        public string AppToken { get; set; } = "";

        public int BuyerId { get; set; }

        public int SellerId { get; set; }
    }
}
