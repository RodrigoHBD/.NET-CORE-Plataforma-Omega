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
                throw;
            }
        }

        public static async Task<JsonDeserialized> TryDeserialize<T>(string json)
        {
            var deserialized = new JsonDeserialized();
            var options = new JsonSerializerOptions
            {
                IgnoreNullValues = true
            };

            try
            {
                deserialized.Content = JsonSerializer.Deserialize<T>(json, options);
                deserialized.IsDeserialized = true;
                return deserialized;
            }
            catch (Exception e)
            {
                deserialized.IsDeserialized = false;
                deserialized.DeserializationException = e;
                return deserialized;
            }
        }
    }

    public class JsonDeserialized
    {
        public dynamic Content { get; set; } = null;
        public bool IsDeserialized { get; set; } = false;
        public Exception DeserializationException { get; set; } = null;
    }
}
