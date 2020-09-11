using HttpClientLibrary;
using MercadoLivreLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MercadoLivreLibrary.Methods.Account
{
    public class GetDetail : MercadoLivreMethod
    {
        public async Task<AccountJson> Execute(string token)
        {
            try
            {
                var req = GetRequest(token);
                return await HttpClientLib.Get<AccountJson, ErrorJson>(req);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string GetUri()
        {
            return $"{BaseUri}/users/me";
        }

        private List<UriParam> GetParams(string token)
        {
            return new List<UriParam>()
            {
                new UriParam(){ Name = "access_token", Data = token }
            };
        }

        private GetRequest GetRequest(string token)
        {
            return new GetRequest()
            {
                Uri = GetUri(),
                Params = GetParams(token)
            };
        }
    }
}
