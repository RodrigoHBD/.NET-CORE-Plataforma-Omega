using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreLibrary.Models.Input
{
    public class Pagination
    {
        public int Offset { get; set; }

        public int Limit { get; set; }
    }
}
