using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Boundries.MercadoLivreModels
{
    public class AuthCodeExchangeResult
    {
        public string AccessToken { get; set; } = "";
        public string RefreshToken { get; set; } = "";
        public int UserId { get; set; } = 0;
        public string Email { get; set; } = "";
        public int ExpiresInMiliseconds { get; set; } = 0;
    }
}
