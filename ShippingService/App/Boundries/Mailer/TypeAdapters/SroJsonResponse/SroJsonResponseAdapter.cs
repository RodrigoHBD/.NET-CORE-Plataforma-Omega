using CorreioRastreamentoLibrary;
using ShippingService.App.Boundries.MailerTypeAdapters.SroJsonResponseFactories;
using ShippingService.App.Entities;
using ShippingService.App.Models;
using ShippingService.App.Models.MailerService.PackageData;
using ShippingService.Correios.Models.Sro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Boundries.MailerTypeAdapters
{
    public class SroJsonResponseAdapter
    {
        public static MailerServicePackageData AdaptToPackageStatus(SroJsonResponse response)
        {
            try
            {
                ValidateResponse(response);

                var mailerData = new MailerServicePackageData();
                var hasAtLeastOneEvent = CheckIfHasAtLeastOneEvent(response);

                if (hasAtLeastOneEvent)
                {
                    // THE ORDER MATTERS // LOCATIONS COMES FIRST
                    mailerData.Location = BuildLocation(response);
                    mailerData.Status = BuildStatus(response, mailerData.Location);
                    mailerData.Messages = BuildMessages(response);
                }
                
                return mailerData;
            }
            catch (Exception e)
            {
                throw ;
            }
        }

        private static void ValidateResponse(SroJsonResponse response)
        {
            try
            {
                var hasError = response.erro.Any();

                if(hasError)
                {
                    var error = response.erro[0];
                    throw new Exception(error);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static bool CheckIfHasAtLeastOneEvent(SroJsonResponse response)
        {
            try
            {
                var hasAtLeastOneEvent = response.evento.Any();
                return hasAtLeastOneEvent;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static PackageStatusMessages BuildMessages(SroJsonResponse response)
        {
            try
            {
                var messages = new PackageStatusMessages();

                if(response.evento.Count > 0)
                {
                    var evento = response.evento[0];

                    if(evento.descricao.Count > 0)
                    {
                        messages.StatusDescription = evento.descricao[0];
                    }
                }

                return messages;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private static PackageStatus BuildStatus(SroJsonResponse response, PackageLocation locations)
        {
            try
            {
                return PackageStatusFactory.MakeStatus(response, locations);
            }
            catch (Exception e)
            {
                throw ;
            }
        }

        private static PackageLocation BuildLocation(SroJsonResponse response)
        {
            try
            {
                var location = new PackageLocation();

                location.CurrentLocation = PackageLocationFactory.MakeFromLatestLocation(response);
                location.HeadedTo = PackageLocationFactory.MakeFromLatestHeadedToLocation(response);

                return location;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        
        private static string GetStatusMessage(SroJsonResponse response)
        {
            try
            {
                string message = "";
                int index = response.evento.Count - 1;
                var description = response.evento[0].descricao[0];
                return description;
            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
