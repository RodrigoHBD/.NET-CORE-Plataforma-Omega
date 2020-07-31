using MercadoLivreService.MercadoLivreModels.Out;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.UseCases
{
    public class HandleApiCallResponse
    {
        public T Execute<T>(ApiCallResponse response)
        {
			try
			{
				ValidateJsonDataDeserialization.Execute(response);
				return (T) response.DeserializedJson;
			}
			catch (Exception)
			{
				throw;
			}
        }
    }
}
