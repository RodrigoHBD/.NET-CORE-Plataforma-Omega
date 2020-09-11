using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientLibrary
{
    public class ResponseHandler
    {
        //TODO
        public static DataType HanldeResponse<DataType, ErrorType>(HttpResponseMessage resp)
        {
            var requestIsSuccessfull = resp.IsSuccessStatusCode;

            if (requestIsSuccessfull)
            {
                return HandleDeserialization<DataType>(resp.Content);
            }
            else
            {
                throw new Exception("HTTP REQUEST FALHOU NO TODO DO HTTPCLIENT SEU ARROMBADO");
            }
        }

        public static T HandleDeserialization<T>(HttpContent body)
        {
            var contentType = body.Headers.ContentType.MediaType;

            if(contentType == "application/json")
            {
                return JsonResponseHandler.HanldeJsonResponse<T>(body);
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
