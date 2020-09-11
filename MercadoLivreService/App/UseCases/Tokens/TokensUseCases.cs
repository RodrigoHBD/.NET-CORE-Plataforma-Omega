using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.UseCases.Tokens
{
    public class TokensUseCases
    {
        public static GetValidAccessToken GetValidAccessToken { get { return new GetValidAccessToken(); } }

        public static Refresh Refresh { get { return new Refresh(); } }
    }
}
