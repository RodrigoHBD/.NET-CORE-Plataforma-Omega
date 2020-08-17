using ShippingService.App.Boundries.MailerIntercafe;
using ShippingService.Correios.Models.Sro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Boundries.MailerTypeAdapters.Output
{
    public class SroResponseJsonAdapter
    {
        public static IBoundryShipment Adapt(SroJsonResponse json)
        {
            return GetAdaptedResponse();
        }

        private static IBoundryShipment GetAdaptedResponse(SroJsonResponse json)
        {
            return new BoundryShipment() 
            {
                IsPosted = GetIsPosted(json)
            };
        }

        private static bool GetIsPosted(SroJsonResponse json)
        {
            var isPosted = false;
            json.evento.ForEach(evento =>
            {
                isPosted = evento.tipo[0] == "PO" && (evento.status[0] == "09" || evento.status[0] == "01");
            });
            return isPosted;
        }

        private static bool GetIsDelivered

    }
}
