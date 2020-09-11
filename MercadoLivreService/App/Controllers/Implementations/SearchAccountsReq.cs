using MercadoLivreService.App.Models;
using MercadoLivreService.App.Models.SearchFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Controllers.Implementations
{
    public class SearchAccountsReq : Models.SearchAccountsReq
    {
        public Models.SearchFields.StringSearchField User { get; set; } = new StringSearchField();
        public Models.SearchFields.StringSearchField Name { get; set; } = new StringSearchField();
        public Models.PaginationIn Pagination { get; set; } = new PaginationIn();
    }
}
