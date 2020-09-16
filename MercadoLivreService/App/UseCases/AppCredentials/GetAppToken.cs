using MercadoLivreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.UseCases
{
    public class GetAppToken
    {
        public static string Execute()
        {
            try
            {
                return MercadoLivreLib.Credentials.AppToken;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
