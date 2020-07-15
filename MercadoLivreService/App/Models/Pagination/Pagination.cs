using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Models
{
    public class Pagination
    {
        public int Offset { get; set; }
        public int Limit { get; set; }
        public int Total { get; set; }
    }
}
