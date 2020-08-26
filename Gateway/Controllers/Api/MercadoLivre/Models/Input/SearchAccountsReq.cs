using Gateway.Controllers.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Controllers.Api.MercadoLivreModels.Input
{
    public class SearchAccountsReq
    {
        public string Owner { get; set; } = "";
        public string Name { get; set; } = "";
        public PaginationIn Pagination { get; set; } = new PaginationIn();
    }
}
