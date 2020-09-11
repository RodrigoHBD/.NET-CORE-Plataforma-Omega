using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Models
{
    public interface IAddAccountRequest
    {
        string Owner { get; }
        string Name { get; }
        string Description { get; }
        string AuthCode { get; }
    }
}
