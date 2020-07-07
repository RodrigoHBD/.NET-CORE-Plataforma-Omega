using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Models
{
    public interface IAccountList
    {
        List<Account> Accounts { get; set; }
        IPaginationOut Pagination { get; set; }
    }
}
