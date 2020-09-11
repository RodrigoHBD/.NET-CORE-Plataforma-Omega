using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreLibrary.Models
{
    public class PagingJson
    {
        public int total { get; set; }

        public int offset { get; set; }

        public int limit { get; set; }
    }
}
