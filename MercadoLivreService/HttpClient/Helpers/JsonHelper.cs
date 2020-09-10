using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MercadoLivreService.HttpClientLibrary.Helpers
{
    public class JsonHelper
    {
        public static T TryDeserialize<T>(string json)
        {
            try
            {
                var options = new JsonSerializerOptions()
                {
                    IgnoreNullValues = true
                };
                var data = JsonSerializer.Deserialize<T>(json, options);
                return data;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }

}
