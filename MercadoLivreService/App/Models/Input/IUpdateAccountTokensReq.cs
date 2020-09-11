using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Models
{
    public interface IUpdateAccountTokensReq
    {
        string Id { get; }
        string AccessToken { get; }
        string RefreshToken { get; }
    }
}
