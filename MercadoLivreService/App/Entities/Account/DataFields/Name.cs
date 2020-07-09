using MercadoLivreService.App.Boundries.DAO;
using MercadoLivreService.App.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Entities.AccountDataFields
{
    public class Name
    {
        private static int MinLength { get; } = 5;

        private static int MaxLength { get; } = 120;

        public static async Task Validate(string owner, string name = "")
        {
            try
            {
                var isInRange = name.Length >= MinLength && name.Length <= MaxLength;
                var nameIsTaken = await AccountDAO.CheckIfAccountNameForUserIsTaken(owner, name);

                if (!isInRange)
                {
                    throw new ValidationException("Nome", $"Nome da conta deve ter entre {MinLength} e {MaxLength} caracteres.");
                }
                if (nameIsTaken)
                {
                    throw new ValidationException("Nome", "Você já cadastrou uma conta com esse nome, use outro.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
