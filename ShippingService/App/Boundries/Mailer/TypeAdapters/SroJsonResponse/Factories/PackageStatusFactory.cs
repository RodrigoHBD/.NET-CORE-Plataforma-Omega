using ShippingService.App.Entities;
using ShippingService.App.Models;
using ShippingService.Correios.Models.Sro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Boundries.MailerTypeAdapters.SroJsonResponseFactories
{
    public class PackageStatusFactory
    {
        public static PackageStatus MakeStatus(SroJsonResponse response, PackageLocation locations)
        {
            try
            {
                var status = new PackageStatus();

                status.HasBeenPosted = CheckIfPosted(response);
                status.HasBeenDelivered = CheckIfDelivered(response);
                status.IsRejected = CheckIfRejected(response);
                status.IsAwaitingForPickUp = CheckIfAwaitingForPickUp(response);
                status.IsBeingTransported = CheckIfBeingTransported(locations);
                return status;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private static bool CheckIfPosted(SroJsonResponse response)
        {
            try
            {
                var isPosted = false;
                response.evento.ForEach(evento =>
                {
                    isPosted = evento.tipo[0] == "PO" && (evento.status[0] == "09" || evento.status[0] == "01");
                });
                return isPosted;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private static bool CheckIfDelivered(SroJsonResponse response)
        {
            try
            {
                var isDelivered = false;
                response.evento.ForEach(evento =>
                {
                    var deliveredBDE = evento.tipo[0] == "BDE" && (evento.status[0] == "01" || evento.status[0] == "23"
                    || evento.status[0] == "67" || evento.status[0] == "70");

                    var deliveredBDI = evento.tipo[0] == "BDI" && (evento.status[0] == "01" || evento.status[0] == "23"
                    || evento.status[0] == "67" || evento.status[0] == "70");

                    var deliveredBDR = evento.tipo[0] == "BDR" && (evento.status[0] == "01" || evento.status[0] == "23"
                    || evento.status[0] == "67" || evento.status[0] == "70");

                    if (deliveredBDE || deliveredBDI || deliveredBDR)
                    {
                        isDelivered = true;
                    }
                });

                return isDelivered;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private static bool CheckIfRejected(SroJsonResponse response)
        {
            try
            {
                var isPosted = false;
                response.evento.ForEach(evento =>
                {
                    var rejectedBDE = evento.tipo[0] == "BDE" && (evento.status[0] == "04" || evento.status[0] == "05"
                    || evento.status[0] == "06" || evento.status[0] == "07" || evento.status[0] == "08" || evento.status[0] == "10"
                    || evento.status[0] == "21" || evento.status[0] == "26" || evento.status[0] == "36" || evento.status[0] == "48"
                    || evento.status[0] == "49" || evento.status[0] == "89");

                    var rejectedBDI = evento.tipo[0] == "BDI" && (evento.status[0] == "04" || evento.status[0] == "05"
                    || evento.status[0] == "06" || evento.status[0] == "07" || evento.status[0] == "08" || evento.status[0] == "10"
                    || evento.status[0] == "21" || evento.status[0] == "26" || evento.status[0] == "36" || evento.status[0] == "48"
                    || evento.status[0] == "49" || evento.status[0] == "89");

                    var rejectedBDR = evento.tipo[0] == "BDR" && (evento.status[0] == "04" || evento.status[0] == "05"
                    || evento.status[0] == "06" || evento.status[0] == "07" || evento.status[0] == "08" || evento.status[0] == "10"
                    || evento.status[0] == "21" || evento.status[0] == "26" || evento.status[0] == "36" || evento.status[0] == "48"
                    || evento.status[0] == "49" || evento.status[0] == "64");

                    if (rejectedBDE || rejectedBDI || rejectedBDR)
                    {
                        isPosted = true;
                    }
                });
                return isPosted;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private static bool CheckIfAwaitingForPickUp(SroJsonResponse response)
        {
            try
            {
                var isAwaitingForPickUp = false;
                var evento = response.evento[0];
                var awaitingBDE = evento.tipo[0] == "BDE" && (evento.status[0] == "24");
                var awaitingBDI = evento.tipo[0] == "BDI" && (evento.status[0] == "24");
                var awaitingBDR = evento.tipo[0] == "BDR" && (evento.status[0] == "24");
                var awaitingLDI = evento.tipo[0] == "LDI" && (evento.status[0] == "01" || evento.status[0] == "02"
                    || evento.status[0] == "03" || evento.status[0] == "04" || evento.status[0] == "11" || evento.status[0] == "13"
                    || evento.status[0] == "14");

                if (awaitingBDE || awaitingBDI || awaitingBDR || awaitingLDI)
                {
                    isAwaitingForPickUp = true;
                }
                return isAwaitingForPickUp;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private static bool CheckIfBeingTransported(PackageLocation locations)
        {
            try
            {
                var locationsMatch = LocationEntity.CompareLocationsBool(locations.CurrentLocation, locations.HeadedTo);
                return !locationsMatch;
            }
            catch (Exception e)
            {
                throw;
            }
        }


    }
}
