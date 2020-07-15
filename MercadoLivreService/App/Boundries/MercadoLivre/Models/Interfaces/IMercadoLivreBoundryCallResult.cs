using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Boundries.MercadoLivreModels
{
    public interface IMercadoLivreBoundryCallResult
    {
        bool IsSuccessfull { get; } 
        bool MustUpdateAccessToken { get; }
    }
}
