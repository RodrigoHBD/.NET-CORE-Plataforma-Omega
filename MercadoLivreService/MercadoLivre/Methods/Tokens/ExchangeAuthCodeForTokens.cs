﻿using HttpClientLibrary;
using MercadoLivreLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MercadoLivreLibrary.Methods.Tokens
{
    public class ExchangeAuthCodeForTokens : MercadoLivreMethod
    {
        private Credentials Credentials { get { return MercadoLivreLib.Credentials; } }

        private string RedirectUri { get; } = "https://omega.brazilsouth.cloudapp.azure.com/api/mercadolivre/process-authcode-exchange";

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
            return $"{AuthCodeUri}";
        }

        private List<UriParam> GetParams(string code)
        {
            return new List<UriParam>()
            {
                new UriParam(){ Name ="client_id", Data = Credentials.AppId },
                new UriParam(){ Name ="client_secret", Data = Credentials.AppToken },
                new UriParam(){ Name ="code", Data = code },
                new UriParam(){ Name ="redirect_uri", Data = RedirectUri },
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
