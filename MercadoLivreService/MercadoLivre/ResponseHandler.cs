using MercadoLivreService.HttpClientLibrary.Helpers;
using MercadoLivreService.MercadoLivreModels.Out;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MercadoLivreService.MercadoLivre
{
    public class ResponseHandler
    {
        public ApiCallResponse HandleApiResponse<T>(HttpResponseMessage response)
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

        private ApiCallResponse HandleDeserialization<T>(HttpResponseMessage resp)
        {
            try
            {
                var json = resp.Content.ReadAsStringAsync().Result;
                return new ApiCallResponse()
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

        private ApiCallResponse GetExceptionResponse(Exception e)
        {
            try
            {
                return new ApiCallResponse()
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
