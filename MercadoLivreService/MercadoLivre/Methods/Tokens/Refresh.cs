using HttpClientLibrary;
using MercadoLivreLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreLibrary.Methods.Tokens
{
    public class Refresh : MercadoLivreMethod
    {
        private Credentials Credentials { get { return MercadoLivreLib.Credentials; } }

        public async Task<AccessTokensJson> Execute(string code)
        {
            try
            {
                var req = GetRequest(code);
                return await HttpClientLib.Post<AccessTokensJson, ErrorJson>(req);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private string GetUri()
        {
            return $"{RefreshTokenUri}";
        }

        private List<UriParam> GetParams(string code)
        {
            return new List<UriParam>()
            {
                new UriParam(){ Name ="client_id", Data = Credentials.AppId },
                new UriParam(){ Name ="client_secret", Data = Credentials.AppToken },
                new UriParam(){ Name ="refresh_token", Data = code }
            };
        }

        private PostRequest GetRequest(string code)
        {
            return new PostRequest()
            {
                Uri = GetUri(),
                Params = GetParams(code),
                Data = null
            };
        }
    }
}
