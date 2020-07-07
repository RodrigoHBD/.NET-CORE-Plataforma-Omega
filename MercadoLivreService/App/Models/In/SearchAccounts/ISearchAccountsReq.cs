using MercadoLivreService.App.Models.SearchFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Models
{
    public interface ISearchAccountsReq
    {
        IStringSearchField User { get; set; }
        IStringSearchField Name { get; set;  }
        IPaginationIn Pagination { get; }
    }
}
