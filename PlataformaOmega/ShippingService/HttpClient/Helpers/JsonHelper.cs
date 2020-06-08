using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShippingService.HttpClientLibrary.Helpers
{
    public class JsonHelper
    {
        public static async Task<T> Deserialize<T>(string json)
        {
            try
            {
                return JsonSerializer.Deserialize<T>(json);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
