using MercadoLivreService.App.Models;
using MercadoLivreService.App.Models.SearchFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Controllers.Implementations
{
    public class SearchAccountsReq : ISearchAccountsReq
    {
        public IStringSearchField User { get; set; } = new StringSearchField();
        public IStringSearchField Name { get; set; } = new StringSearchField();
        public IPaginationIn Pagination { get; set; } = new PaginationIn();
    }
}
