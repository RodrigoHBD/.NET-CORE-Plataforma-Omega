using ProductService.App.Boundries.DAO;
using ProductService.App.CustomExceptions;
using ProductService.App.Entities.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProductService.App.Entities.BrandDataFields
{
    public class Cnpj
    {
        private static int MinumumLength { get; } = 14;
        private static int MaximumLength { get; } = 14;

        private static void Validate(string cnpj)
        {

            try
            {
                StringDataFieldEntity.CheckIfNotNull(cnpj, "CNPJ");
                cnpj = NormilizeCnpj(cnpj);
                StringDataFieldEntity.CheckIsWithinRange(MinumumLength, MaximumLength, cnpj, "CNPJ");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task ValidateNew(string cnpj)
        {
            try
            {
                Validate(cnpj);
                var exists = await BrandDAO.CheckBrandCnpjExist(cnpj);

                if (exists)
                {
                    throw new ValidationException("CNPJ", "Esse CNPJ de marca já está cadastrado");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static string NormilizeCnpj(string cnpj)
        {
            try
            {
                return Regex.Replace(cnpj, @"[^0-9]", "");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
