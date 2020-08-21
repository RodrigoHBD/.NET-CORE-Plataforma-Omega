using ShippingService.App.Boundries;
using ShippingService.App.CustomExceptions;
using ShippingService.App.Entities.PackageDataField;
using ShippingService.App.Factories;
using ShippingService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Entities
{
    public class PackageEntity
    {
        private static PackageDataFields DataFields { get; } = new PackageDataFields();

        public static async Task ValidateNew(Package package)
        {
            try
            {
                await ValidateDataFields(package);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task ValidatePackageId(string id)
        {
            try
            {
                var idExist = await PackageDAO.CheckIdPackageIdExist(id);

                if(!idExist)
                {
                    throw new ValidationException("Id", "Esse pacote nao existe.");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static async Task ValidateDataFields(Package package)
        {
            try
            {
                
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
