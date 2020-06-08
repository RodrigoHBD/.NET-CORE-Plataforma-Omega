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
                return new MailerServicePackageData()
                {
                    Status = BuildStatus(response),
                    Location = BuildLocation(response)
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static PackageStatus BuildStatus(SroJsonResponse response)
        {
            try
            {
                var status = new PackageStatus();
                var headedToLocationIsAvailable = CheckIfHeadedToLocationIsAvailable(response);

                status.HasBeenPosted = CheckIfIsPosted(response);
                status.HasBeenDelivered = CheckIfIsDelivered(response);
                status.Message = GetStatusMessage(response);
                status.IsAwaitingForPickUp = CheckIfIsAwaitingForPickUp(response);
                status.IsRejected = CheckIfIsRejected(response);

                if (headedToLocationIsAvailable)
                {
                    var headedToLocation = GetLatestHeadedToLocation(response);
                    status.IsBeingTransported = !CheckIfHasArrivedInLatestHeadedToLocation(response, headedToLocation);
                }

                return status;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static PackageLocation BuildLocation(SroJsonResponse response)
        {
            try
            {
                var evento = response.evento[0];
                var location = new PackageLocation();
                BuildCurrentLocation(evento, location);
                BuildHeadedToLocation(response, location);

                return location;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static void BuildCurrentLocation(SroEvent evento, PackageLocation location)
        {
            try
            {
                location.CurrentLocation.Cep = evento.codigo[0];
                location.CurrentLocation.City = evento.cidade[0];
                location.CurrentLocation.State = evento.uf[0];
                location.CurrentLocation.StreetName = evento.local[0];
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static void BuildHeadedToLocation(SroJsonResponse response, PackageLocation location)
        {
            try
            {
                var locationIsAvailable = CheckIfHeadedToLocationIsAvailable(response);

                if (locationIsAvailable)
                {
                    location.HeadedTo = GetLatestHeadedToLocation(response);
                }
                else
                {
                    location.HeadedTo = LocationEntity.ExportInstanceOfDefaultLocation();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static bool CheckIfHeadedToLocationIsAvailable(SroJsonResponse response)
        {
            try
            {
                var isAvailable = false;
                for (var index = 0; isAvailable == false || index < response.evento.Count; index++)
                {
                    var evento = response.evento[index];
                    if (evento.destino != null)
                    {
                        isAvailable = true;
                    }
                }
                return isAvailable;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static Location GetLatestHeadedToLocation(SroJsonResponse response)
        {
            try
            {
                var isFound = false;
                Location location = new Location();

                do
                {
                    for (var index = 0; index < response.evento.Count && !isFound; index++)
                    {
                        var evento = response.evento[index];
                        if (evento.destino != null)
                        {
                            isFound = true;
                            location.Cep = evento.destino[0].codigo[0];
                            location.City = evento.destino[0].cidade[0];
                            location.State = evento.destino[0].uf[0];
                            location.StreetName = evento.destino[0].local[0];
                        }
                    }
                } while (!isFound);

                return location;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static bool CheckIfHasArrivedInLatestHeadedToLocation(SroJsonResponse response, Location headedToLocation)
        {
            try
            {
                var hasArrived = false;
                response.evento.ForEach(evento =>
                {
                    if (evento.destino != null)
                    {
                        var location = new Location()
                        {
                            Cep = evento.codigo[0],
                            City = evento.cidade[0],
                            State = evento.uf[0],
                            StreetName = evento.local[0]
                        };
                        var isAMatch = CompareLocationsBool(location, headedToLocation);
                        var mailerStatusIsOk = !(evento.tipo[0] == "BDI" && evento.status[0] == "69");

                        if (isAMatch && mailerStatusIsOk)
                        {
                            hasArrived = true;
                        }
                    }
                });
                return hasArrived;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static bool CheckIfIsPosted(SroJsonResponse response)
        {
            try
            {
                var isPosted = false;
                response.evento.ForEach(evento =>
                {
                    var statusIsOk = evento.status[0] == "09";
                    var tipoIsOk = evento.tipo[0] == "PO";
                    if (statusIsOk && tipoIsOk)
                    {
                        isPosted = true;
                    }
                });
                return isPosted;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static bool CheckIfIsDelivered(SroJsonResponse response)
        {
            try
            {
                var isPosted = false;
                response.evento.ForEach(evento =>
                {
                    var statusIsOk = evento.status[0] == "01" || evento.status[0] == "23";
                    var tipoIsOk = evento.tipo[0] == "BDE";
                    if (statusIsOk && tipoIsOk)
                    {
                        isPosted = true;
                    }
                });
                return isPosted;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static bool CheckIfIsAwaitingForPickUp(SroJsonResponse response)
        {
            try
            {
                var isPosted = false;
                var evento = response.evento[0];
                var statusIsOk = evento.status[0] == "03" || evento.status[0] == "04";
                var tipoIsOk = evento.tipo[0] == "LDI";
                if (statusIsOk && tipoIsOk)
                {
                    isPosted = true;
                }
                return isPosted;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static bool CheckIfIsRejected(SroJsonResponse response)
        {
            try
            {
                var isPosted = false;
                response.evento.ForEach(evento =>
                {
                    var statusIsOk = evento.status[0] == "26";
                    var tipoIsOk = evento.tipo[0] == "BDI";
                    if (statusIsOk && tipoIsOk)
                    {
                        isPosted = true;
                    }
                });
                return isPosted;
            }
            catch (Exception e)
            {
                throw e;
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
                throw e;
            }
        }

        private static bool CompareLocationsBool(Location location1, Location location2)
        {
            try
            {
                var locationsMatch = Location.Equals(location1, location2);
                return locationsMatch;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
