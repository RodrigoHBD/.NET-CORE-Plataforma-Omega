using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace HttpClientLibrary
{
    public class Json
    {
        public static JsonDeserializationAttempt AttemptToDeserialize<T>(string json)
        {
            var attempt = new JsonDeserializationAttempt();

            try
            {
                attempt.Data = JsonSerializer.Deserialize<T>(json);
                attempt.ThrewException = false;
            }
            catch (Exception e)
            {
                attempt.Exception = e;
                attempt.ThrewException = true;
            }

            return attempt;
        }

        public static string Serialize(Object obj)
        {
            return JsonSerializer.Serialize(obj);
        }
    }
}
