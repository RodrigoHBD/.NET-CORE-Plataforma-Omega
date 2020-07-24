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
        public async Task<ApiCallResponse> HandleApiResponse<T>(HttpResponseMessage response)
        {
            try
            {
                var json = await response.Content.ReadAsStringAsync();
                var parsedJson = new JsonDeserialized();
                var apiCallResponse = new ApiCallResponse();
                var isOkStatus = response.StatusCode == System.Net.HttpStatusCode.OK;
                var isUnauthorizedStatus = response.StatusCode == System.Net.HttpStatusCode.Unauthorized;

                if (isOkStatus)
                {
                    parsedJson = await JsonHelper.TryDeserialize<T>(json);
                    apiCallResponse = HandleJsonDeserialization(parsedJson);
                    apiCallResponse.IsDeserializedWithDataModel = true;
                }
                else
                {
                    parsedJson = await JsonHelper.TryDeserialize<ErrorJson>(json);
                    apiCallResponse = HandleJsonDeserialization(parsedJson);
                    apiCallResponse.IsDeserializedWithErrorModel = true;

                }

                return apiCallResponse;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ApiCallResponse HandleJsonDeserialization(JsonDeserialized json)
        {
            try
            {
                var response = new ApiCallResponse();

                if (json.IsDeserialized)
                {
                    response.DeserializedJson = json.Content;
                }
                else
                {
                    response.HasDeserializationException = true;
                    response.DeserializationException = json.DeserializationException;
                }
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
