using MercadoLivreService.App.Boundries.DAO;
using MercadoLivreService.App.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Entities.AccountDataFields
{
    public class MercadoLivreId
    {
        public static async Task ValidateNew(long id)
        {
            try
            {
                var idAlreadyExistInDb = await AccountDAO.CheckIfMercadoLivreIdExists(id);

                if (idAlreadyExistInDb)
                {
                    throw new CustomExceptions.InvalidOperationException("Essa conta já está sincronizada.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
