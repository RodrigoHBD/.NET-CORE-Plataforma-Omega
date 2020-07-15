using MercadoLivreService.MercadoLivreModels.Out;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.UseCases
{
    public class ValidateJsonDeserialization
    {
        public static void Execute(ApiCallResponse response)
        {
            try
            {
                var hasError = response.HasDeserializationException;

                if (hasError)
                {
                    throw response.DeserializationException;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
