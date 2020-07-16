using MercadoLivreService.App.Boundries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.UseCases
{
    public class GetAccountData
    {
        public static async Task Execute(string token)
        {
            try
            {
                var result = await MercadoLivreBoundry.GetUserData(token);

                ValidateJsonDeserialization.Execute(result);

                if (!result.IsDeserializedWithDataModel)
                {
                    //var error = result.DeserializedJson
                    //throw new Exception(result.)
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
