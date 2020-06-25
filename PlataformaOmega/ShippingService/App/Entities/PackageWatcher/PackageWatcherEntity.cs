using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShippingService.App.Boundries;
using ShippingService.App.CustomExceptions;

namespace ShippingService.App.Entities.PackageWatcher
{
    public class PackageWatcherEntity
    {
        public static async Task ValidateId(string id)
        {
            try
            {
                if(id is null)
                {
                    throw new ValidationException("Id", "Id do monitorador de pacote não pode estar nulo");
                }

                var idExist = await PackageWatcherDAO.CheckIfExistById(id);

                if (!idExist)
                {
                    throw new ValidationException("Id", "Id do monitorador de pacote inexistente");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task CheckIfWatcherAlreadyExistsByPackageId(string packageId, bool toogle)
        {
            try
            {
                var watcherExist = await PackageWatcherDAO.CheckIfExistByPackageId(packageId);
                var message = "";

                if (!toogle)
                {
                    message = "Um monitorador já existe para esse pacote";
                }
                else
                {
                    message = "Esse pacote não tem um monitorador";
                }

                if (watcherExist != toogle)
                {
                    throw new ValidationException("Id", message);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
