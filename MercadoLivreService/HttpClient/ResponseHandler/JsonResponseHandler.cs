using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientLibrary
{
    public class JsonResponseHandler
    {
        public static T HanldeJsonResponse<T>(HttpContent body)
        {
            var data = body.ReadAsStringAsync().Result;
            var attempt = Json.AttemptToDeserialize<T>(data);

            if (attempt.ThrewException)
            {
                throw attempt.Exception;
            }

            return (T)attempt.Data;
        }
    }
}
