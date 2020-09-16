using HttpClientLibrary;
using MercadoLivreLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreLibrary.Methods.Pack
{
    public class Get : MercadoLivreMethod
    {
        public async Task<PackJson> Execute(long packId, long accountId, string token)
        {
            try
            {
                var req = GetRequest(packId, accountId, token);
                var json = await HttpClientLib.Get<PackJson, ErrorJson>(req);
                return json;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private string GetUri(long packId, long accountId)
        {
            return $"{BaseUri}/messages/packs/{packId}/sellers/{accountId}";
        }

        private List<UriParam> GetParams(string token)
        {
            return new List<UriParam>()
            {
                new UriParam(){ Name = "access_token", Data = token }
            };
        }

        private GetRequest GetRequest(long packId, long accountId, string token)
        {
            return new GetRequest()
            {
                Uri = GetUri(packId, accountId),
                Params = GetParams(token)
            };
        }
    }
}
