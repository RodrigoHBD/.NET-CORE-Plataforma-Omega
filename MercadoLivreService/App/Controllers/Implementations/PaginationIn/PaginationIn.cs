using MercadoLivreService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Controllers.Implementations
{
    public class PaginationIn : Models.PaginationIn
    {
        public int Offset { get; set; } = 0;

        public int Limit { get; set; } = 0;
    }
}
