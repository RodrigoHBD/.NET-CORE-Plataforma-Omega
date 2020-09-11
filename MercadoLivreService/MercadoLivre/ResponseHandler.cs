using MercadoLivreLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MercadoLivreLibrary
{
    public class ResponseHandler
    {
        public JsonResponse HandleApiResponse<T>(HttpResponseMessage response)
        {
            try
            {
                HandleHttpStatus(response);
                return HandleDeserialization<T>(response);
            }
            catch (Exception e)
            {
                return GetExceptionResponse(e);
            }
        }

        private void HandleHttpStatus(HttpResponseMessage resp)
        {
            var isOkStatus = resp.StatusCode == System.Net.HttpStatusCode.OK;
            var isUnauthorizedStatus = resp.StatusCode == System.Net.HttpStatusCode.Unauthorized;

            if (isUnauthorizedStatus)
            {
                throw new Exception("Mercado Livre não autorizou essa requisição");
            }
            else if(isOkStatus == false)
            {
                //throw new Exception("resposta não foi 200 " + resp.StatusCode);
            }
        }

        private JsonResponse HandleDeserialization<T>(HttpResponseMessage resp)
        {
            try
            {
                var json = resp.Content.ReadAsStringAsync().Result;
                return new JsonResponse()
                {
                    DeserializedJson = JsonHelper.TryDeserialize<T>(json),
                    IsOk = true
                };
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private JsonResponse GetExceptionResponse(Exception e)
        {
            try
            {
                return new JsonResponse()
                {
                    IsOk = false,
                    Exception = e
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
