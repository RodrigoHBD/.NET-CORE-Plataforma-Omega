using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Models
{
    public interface IPaginationOut
    {
        int Offset { get; set; }
        int Limit { get; set; }
        long Total { get; set; }
    }
}
