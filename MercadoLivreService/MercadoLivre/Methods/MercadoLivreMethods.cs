using MercadoLivreService.MercadoLivre.Methods.Account;
using MercadoLivreService.MercadoLivre.Methods.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.MercadoLivre.Methods
{
    public class MercadoLivreMethods
    {
        public AccountMethods Account { get; set; } = new AccountMethods();
        public TokensMethods Tokens { get; set; } = new TokensMethods();
    }
}
