using ShippingService.Correios.Models.Sro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Boundries.MailerTypeAdapters.Output
{
    public class BoundryMessageFactory
    {
        public static string GetMessage(SroJsonResponse json) =>
            new BoundryMessageFactory(json).GetMessage();

        public string GetMessage()
        {
            
            if (Json.evento.Count > 0)
            {
                var @event = Json.evento[0];
                return @event.descricao[0];
            }
            return "";
        }

        public BoundryMessageFactory(SroJsonResponse json)
        {
            Json = json;
        }

        private SroJsonResponse Json { get; }
    }
}
