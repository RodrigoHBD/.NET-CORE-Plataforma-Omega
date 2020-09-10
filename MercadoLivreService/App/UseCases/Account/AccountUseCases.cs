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

        public static GetRefreshedTokens RefreshAccountTokens { get { return new GetRefreshedTokens(); } }

        public static RefreshTokensDynamically RefreshTokensDynamically { get { return new RefreshTokensDynamically(); } }

        public static UpdateAccountTokens UpdateAccountTokens { get { return new UpdateAccountTokens(); } }

        public static GetRefreshedTokens GetRefreshedTokens { get { return new GetRefreshedTokens(); } }
    }
}
