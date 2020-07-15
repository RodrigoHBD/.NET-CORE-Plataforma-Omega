using Grpc.Core;
using MercadoLivreService.App.Entities.AccountDataFields;
using MercadoLivreService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Entities
{
    public class AccountEntity
    {
        public static async Task ValidateNew(Account account)
        {
            try
            {
                await ValidateDataFieldsForNew(account);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static async Task ValidateDataFieldsForNew(Account account)
        {
            try
            {
                await Owner.Validate(account.Owner);
                await Name.Validate(account.Owner, account.Name);
                Tokens.Validate(account.Tokens);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
