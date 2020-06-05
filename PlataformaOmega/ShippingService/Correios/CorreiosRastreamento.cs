using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorreioRastreamentoLibrary;
using CorreiosSGEPLibrary;
using System.Text.Json.Serialization;
using System.Threading;
using ShippingService.Correios.Models.Sro;

namespace ShippingService.Correios
{
    public class CorreiosRastreamento
    {
        
        private static string BaseEndpoint { get; } = "https://apiserver.sgpmaisvendas.com.br:80";
        private static string SroEndpoint { get; } = $"{BaseEndpoint}/sro";
        private static string Token { get; } = "6a63304a03007e3fc2ea9d51a2b2df03";

        public static async Task<SroJsonResponse> PegarDadosDeRastreamento(string trackingCode)
        {
            try
            {
                var uri = $"{SroEndpoint}/{Token}/{trackingCode}/T";
                return await HttpClientLibrary.HttpClient.GetJson<SroJsonResponse>(uri);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
    }
}
