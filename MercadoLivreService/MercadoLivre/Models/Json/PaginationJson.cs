using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.MercadoLivreModels.Out
{
    public class PaginationJson
    {
        public int total { get; set; }

        public int offset { get; set; }

        public int limit { get; set; }
    }
}
