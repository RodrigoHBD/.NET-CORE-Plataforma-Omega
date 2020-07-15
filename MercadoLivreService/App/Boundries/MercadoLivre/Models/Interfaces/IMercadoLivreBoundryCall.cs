using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Boundries.MercadoLivreModels
{
    public interface IMercadoLivreBoundryCall
    {
        string AccessToken { get; }
        string AppId { get; }
        string AppToken { get; }
    }
}
