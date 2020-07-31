using Grpc.Core;
using MercadoLivreService.App.Boundries.DAO;
using MercadoLivreService.App.CustomExceptions;
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

        public static async Task ValidateMercadoLivreId(long id)
        {
            try
            {
                var exists = await AccountDAO.CheckIfMercadoLivreIdExists(id);

                if (!exists)
                {
                    throw new Exception("Conta nao sincronizada na base de dados");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task ValidateId(string id)
        {
            try
            {
                var idExists = await AccountDAO.CheckIdExists(id);

                if (!idExists)
                {
                    throw new CustomExceptions.InvalidOperationException("Id inexistente");
                }
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
                await MercadoLivreId.ValidateNew(account.MercadoLivreId);
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
