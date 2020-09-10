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
                if (!response.IsOk)
                {
                    throw response.Exception;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
