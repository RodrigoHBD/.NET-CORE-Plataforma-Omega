using MercadoLivreService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Boundries.DAO.Implementations
{
    public class AccountList : IAccountList
    {
        public List<Account> Accounts { get; set; }
        public IPaginationOut Pagination { get; set; } = new Pagination();
    }
}
