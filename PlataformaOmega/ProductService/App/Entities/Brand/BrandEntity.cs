using ProductService.App.Entities.BrandDataFields;
using ProductService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProductService.App.Entities
{
    public class BrandEntity
    {
        public static async Task ValidateNew(Brand brand)
        {
            try
            {
                await ValidateDataFields(brand);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task ValidateExistent(string brand)
        {
            try
            {
                await Name.ValidateExistent(brand);
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
                return Cnpj.NormilizeCnpj(cnpj);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static async Task ValidateDataFields(Brand brand)
        {
            try
            {
                await Name.ValidateNew(brand.Name);
                await Cnpj.ValidateNew(brand.Cnpj);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
