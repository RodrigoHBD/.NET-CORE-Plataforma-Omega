using MercadoLivreService.App.Models.In;
using MercadoLivreService.App.Models.SearchFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Models
{
    public class SearchAccountsReq
    {
        public StringSearchField User { get; set; } = new StringSearchField();

        public StringSearchField Name { get; set; } = new StringSearchField();

        public PaginationIn Pagination { get; set; }
    }
}
