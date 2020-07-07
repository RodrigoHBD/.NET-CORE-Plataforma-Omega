using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App
{
    public class AppCredentials
    {
        private static MercadoLivreAppCredentials Credentials { get; set; } = new MercadoLivreAppCredentials();

        private static bool IsSet { get; set; } = false;

        public static void SetCredentialsFromEnv()
        {
            try
            {
                if (!IsSet)
                {
                    //TODO
                    IsSet = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static MercadoLivreAppCredentials GetInstance()
        {
            return Credentials;
        }

        private AppCredentials()
        {

        }

    }

    public class MercadoLivreAppCredentials
    {
        public string AppId { get; set; } = "8448440710206317";
        public string AppToken { get; set; } = "hQD7kUrcJSbneQ6vko1Xjw749Kg0oxw4";
    }
}
