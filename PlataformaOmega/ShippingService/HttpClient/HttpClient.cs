using ShippingService.HttpClientLibrary.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.HttpClientLibrary
{
    public class HttpClient
    {
        private static readonly System.Net.Http.HttpClient Client = new System.Net.Http.HttpClient();

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

    }
}
