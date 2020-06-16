
using ProductService.App.Boundries.DAO;
using ProductService.App.CustomExceptions;
using ProductService.App.Entities.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.Entities.BrandDataFields
{
    public class Name
    {
        private static int MinumumLength { get; } = 3;
        private static int MaximumLength { get; } = 25;

        private static void Validate(string name)
        {
            
            try
            {
                StringDataFieldEntity.CheckIfNotNull(name, "Nome");
                StringDataFieldEntity.CheckIsWithinRange(MinumumLength, MaximumLength, name, "Nome");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task ValidateNew(string name)
        {
            try
            {
                Validate(name);
                var exists = await BrandDAO.CheckBrandNameExist(name);

                if (exists)
                {
                    throw new ValidationException("Nome da Marca", "Esse nome de marca já existe");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task ValidateExistent(string name)
        {
            try
            {
                Validate(name);
                var exists = await BrandDAO.CheckBrandNameExist(name);

                if (!exists)
                {
                    throw new ValidationException("Nome da Marca", "Esse nome de marca não existe");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
