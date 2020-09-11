using MercadoLivreLibrary.Methods.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreLibrary.Methods
{
    public class TokensMethods
    {
        public ExchangeAuthCodeForTokens ExchangeAuthCodeForTokens { get { return new ExchangeAuthCodeForTokens(); } }

        public Refresh Refresh { get { return new Refresh(); } }
    }
}
