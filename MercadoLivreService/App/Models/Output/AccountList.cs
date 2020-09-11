using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Models.Out
{
    public class AccountList
    {
        public List<Account> Data { get; set; }

        public PaginationOut Pagination { get; set; }
    }
}
