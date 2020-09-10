using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.MercadoLivre.Methods
{
    public class MercadoLivreMethod
    {
        protected string BaseUri { get; set; } = "https://api.mercadolibre.com";

        protected string AuthCodeUri { get { return $"{BaseUri}/oauth/token?grant_type=authorization_code"; } }

        protected string RefreshTokenUri { get { return $"{BaseUri}/oauth/token?grant_type=refresh_token"; } }
    }
}
