using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.UseCases
{
    public class AccountUseCases
    {
        public static GetAccountById GetById { get; } = new GetAccountById();
        public static GetAccountByMercadoLivreId GetByMercadoLivreId { get; } = new GetAccountByMercadoLivreId();
    }
}
