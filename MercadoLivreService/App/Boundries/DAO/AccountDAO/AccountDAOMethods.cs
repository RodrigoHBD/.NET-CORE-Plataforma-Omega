using MercadoLivreService.App.Models;
using MercadoLivreService.App.Models.Out;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Boundries.AccountDAO
{
    public class AccountDAOMethods
    {
        public Get Get { get { return new Get(); } }

        public Count Count { get { return new Count(); } }

        public Search Search(SearchAccountsReq req) => new Search(req);
    }
}
