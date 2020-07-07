using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Models
{
    public interface IPaginationIn
    {
        int Offset { get; }
        int Limit { get; }
    }
}
