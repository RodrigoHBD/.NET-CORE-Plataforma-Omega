using MercadoLivreService.MercadoLivreModels.Out;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.UseCases
{
    public class ValidateJsonDataDeserialization
    {
        public static void Execute(ApiCallResponse response)
        {
            try
            {
                var isNull = response.DeserializedJson == null;
                var isDeserialized = response.IsDeserializedWithDataModel;

                if(isNull || !isDeserialized)
                {
                    throw new Exception("Erro de deserializacao, houve um problema com a resposta do mercado livre.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
