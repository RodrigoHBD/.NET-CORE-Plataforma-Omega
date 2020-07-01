using ShippingService.App.CustomExceptions;
using ShippingService.App.Models;
using ShippingService.Correios.Models.Sro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace ShippingService.App.Boundries.MailerTypeAdapters
{
    public class PackageLocationFactory
    {
        public static Location MakeFromLatestLocation(SroJsonResponse response)
        {
            try
            {
                var eventos = response.evento;
                var iterator = 0;
                var location = new Location();

                do
                {
                    var evento = eventos[iterator];
                    var eventoIsValid = ValidateEvento(evento);

                    if (eventoIsValid)
                    {
                        var isTheNotArrivedEvent = CheckEventIsTheNotArrivedEvent(evento);
                        var isTheOutForDeliveryEvent = CheckEventIsTheOutForDeliveryEvent(evento);

                        if (!isTheNotArrivedEvent && !isTheOutForDeliveryEvent)
                        {
                            location = MakeLocationFromEvent(evento);
                            break;
                        }
                    }

                    iterator++;
                }
                while (eventos.Count > iterator);

                return location;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Location MakeFromLatestHeadedToLocation(SroJsonResponse response)
        {
            try
            {
                var eventos = response.evento;
                var iterator = 0;
                var location = new Location();

                do
                {
                    var evento = eventos[iterator];
                    var destinationIsAvailable = CheckIfDestinationIsAvailable(evento);

                    if (destinationIsAvailable)
                    {
                        var destinationIsValid = ValidateDestination(evento);

                        if (destinationIsValid)
                        {
                            location = MakeLocationFromEventDestination(evento);
                            break;
                        }
                    }


                    iterator++;
                }
                while (eventos.Count > iterator);

                return location;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static bool ValidateEvento(SroEvent evento)
        {
            try
            {
                var cityAvailable = evento.cidade.Any();
                var stateAvailable = evento.uf.Any();
                var cepAvailable = evento.codigo.Any();
                var streetNameAvailable = evento.local.Any();

                var somethingUnavailable = !cityAvailable || !stateAvailable || !cepAvailable || !streetNameAvailable;
                var isValid = !somethingUnavailable;
                return isValid;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static bool CheckEventIsTheNotArrivedEvent(SroEvent evento)
        {
            try
            {
                var isTheEventBDE = evento.tipo[0] == "BDE" && (evento.status[0] == "09" || evento.status[0] == "69");
                var isTheEventBDI = evento.tipo[0] == "BDI" && (evento.status[0] == "09" || evento.status[0] == "69");
                var isTheEventBDR = evento.tipo[0] == "BDR" && (evento.status[0] == "09" || evento.status[0] == "69");
                var isTheEvent = isTheEventBDE || isTheEventBDI || isTheEventBDR;
                return isTheEvent;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static bool CheckEventIsTheOutForDeliveryEvent(SroEvent evento)
        {
            try
            {
                var isTheEventOEC = evento.tipo[0] == "OEC" && (evento.status[0] == "01" || evento.status[0] == "09");
                return isTheEventOEC;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static bool CheckIfDestinationIsAvailable(SroEvent evento)
        {
            try
            {
                var destinationIsNotEmpty = evento.destino.Any();
                return destinationIsNotEmpty;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static bool ValidateDestination(SroEvent evento)
        {
            try
            {
                var destination = evento.destino[0];

                var cepAvailable = destination.codigo.Any();
                var cityAvailable = destination.cidade.Any();
                var stateAvailable = destination.uf.Any();
                var streetNameAvailabel = destination.local.Any();

                var somethingUnavailable = !cepAvailable || !cityAvailable || !stateAvailable || !streetNameAvailabel;
                var isValid = !somethingUnavailable;
                return isValid;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static Location MakeLocationFromEvent(SroEvent evento)
        {
            try
            {
                return new Location()
                {
                    Cep = evento.codigo[0],
                    City = evento.cidade[0],
                    State = evento.uf[0],
                    StreetName = evento.local[0]
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static Location MakeLocationFromEventDestination(SroEvent evento)
        {
            try
            {
                var destino = evento.destino[0];
                return new Location()
                {
                    Cep = destino.codigo[0],
                    City = destino.cidade[0],
                    State = destino.uf[0],
                    StreetName = destino.local[0]
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
