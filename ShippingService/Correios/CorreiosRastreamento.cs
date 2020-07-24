using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorreioRastreamentoLibrary;
using CorreiosSGEPLibrary;
using System.Text.Json.Serialization;
using System.Threading;
using ShippingService.Correios.Models.Sro;
using ShippingService.HttpClientLibrary.Helpers;
using ShippingService.Correios.Models.Error;

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
                var serializedJson = await HttpClientLibrary.HttpClient.Get(uri);
                serializedJson = TrimJson(serializedJson);
                return await ParseSroJson(serializedJson);
            }
            catch (System.Exception e)
            {
                throw ;
            }
        }

        private static string TrimJson(string json)
        {
            try
            {
                // This only exist because some intern put the json inside of an array
                json = json.Remove(0, 1);
                json = json.Remove(json.Length - 1);
                return json;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        private static async Task<SroJsonResponse> ParseSroJson(string json)
        {
            try
            {
                var parseWithDataModelAttempt = await JsonHelper.TryDeserialize<SroJsonResponse>(json);
                var parseWithErrorModelAttempt = await JsonHelper.TryDeserialize<ErrorJson>(json);

                if (parseWithDataModelAttempt.IsDeserialized)
                {
                    return (SroJsonResponse) parseWithDataModelAttempt.Content;
                }
                else
                {
                    if (parseWithErrorModelAttempt.IsDeserialized)
                    {
                        var error = parseWithErrorModelAttempt.Content as ErrorJson;
                        throw new System.Exception(error.erro[0]);
                    }
                    else
                    {
                        throw parseWithDataModelAttempt.DeserializationException;
                    }
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        
    }
}
