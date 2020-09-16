using MercadoLivreService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.UseCases
{
    public class AccountUseCases
    {
        public static CreateAccount Create(AddAccountRequest req) => new CreateAccount(req);

        public static GetAccount Get { get { return new GetAccount(); } }

        public static SearchAccounts Search { get { return new SearchAccounts(); } }
    }
}
