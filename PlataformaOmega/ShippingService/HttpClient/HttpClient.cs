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
                // This only exist because some intern put the json inside of an array
                responseBody = responseBody.Remove(0, 1);
                responseBody = responseBody.Remove(responseBody.Length-1);

                var requestIsOk = response.StatusCode == System.Net.HttpStatusCode.OK;

                if (requestIsOk)
                {
                    return await JsonHelper.Deserialize<T>(responseBody);
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
