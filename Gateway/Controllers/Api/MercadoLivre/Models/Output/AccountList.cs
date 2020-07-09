using Gateway.Controllers.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Controllers.Api.MercadoLivreModels.Output
{
    public class AccountList
    {
        public List<Account> Accounts { get; set; } = new List<Account>();
        public PaginationOut Pagination { get; set; } = new PaginationOut();
    }
}
