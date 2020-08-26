using ShippingService.HttpClientLibrary.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ShippingService.HttpClientLibrary
{
    public class HttpClient
    {
        private static System.Net.Http.HttpClient Client { get; set; }

        public static async Task<T> GetJson<T>(string uri)
        {
            try
            {
                var response = await Client.GetAsync(uri);
                var responseBody = await response.Content.ReadAsStringAsync();
                var requestIsOk = response.StatusCode == System.Net.HttpStatusCode.OK;

                if (requestIsOk)
                {
                    return await ParseResponse<T>(responseBody);
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static async Task<string> Get(string uri)
        {
            try
            {
                var response = await Client.GetAsync(uri);
                var responseBody = await response.Content.ReadAsStringAsync();
                var requestIsOk = response.StatusCode == System.Net.HttpStatusCode.OK;

                if (requestIsOk)
                {
                    return responseBody;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private static async Task<T> ParseResponse<T>(string serializedResponse)
        {
            try
            {
                return await JsonHelper.Deserialize<T>(serializedResponse);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Initialize()
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            Client = new System.Net.Http.HttpClient(handler);
        }

    }
}
