﻿using HttpClientLibrary;
using MercadoLivreLibrary.Models;
using MercadoLivreService.MercadoLivre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreLibrary.Methods.Shipping
{
    public class GetDetail : MercadoLivreMethod
    {
        public async Task<ShipmentJson> Execute(string shipmentId, string token)
        {
            try
            {
                var req = GetRequest(shipmentId, token);
                return await HttpClientLib.Get<ShipmentJson, ErrorJson>(req);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string GetUri(string shipmentId)
        {
            return $"{BaseUri}/shipments/{shipmentId}";
        }

        private List<UriParam> GetParams(string token)
        {
            return new List<UriParam>()
            {
                new UriParam(){ Name = "access_token", Data = token }
            };
        }

        private GetRequest GetRequest(string shipmentId, string token)
        {
            return new GetRequest()
            {
                Uri = GetUri(shipmentId),
                Params = GetParams(token)
            };
        }
    }
}
