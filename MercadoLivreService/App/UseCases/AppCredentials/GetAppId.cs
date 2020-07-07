using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.UseCases
{
    public class GetAppId
    {
        public static string Execute()
        {
            try
            {
                return AppCredentials.GetInstance().AppId;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
