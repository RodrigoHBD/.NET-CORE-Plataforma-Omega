using MercadoLivreService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Boundries.DAO.Implementations
{
    public class Pagination : IPaginationOut
    {
        public int Offset { get; set; }
        public int Limit { get; set; }
        public long Total { get; set; }
    }
}
