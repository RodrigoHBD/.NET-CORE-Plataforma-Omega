using Gateway.Controllers.Api.MercadoLivre.Notifications;
using Gateway.Controllers.Api.MercadoLivreModels.Input;
using Gateway.gRPC.Client;
using Gateway.gRPC.Client.MercadoLivreProto;
using Gateway.gRPC.Client.Sale;
using Gateway.gRPC.Client.SaleClientProto;
using Gateway.gRPC.Client.ShippingClientProto;
using Gateway.ServerGrid.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Gateway.Controllers.Api.MercadoLivre
{
    public class NotificationHandler
    {
        private static List<INotificationHandler> Handlers
        {
            get
            {
                return new List<INotificationHandler>()
                {
                    new ShippingNotificationHandler()
                };
            }
        }

        public static async Task HandleNotification(Notification notification)
        {
            try
            {
                Handlers.ForEach(async handler =>
                {
                    var shouldHandle = handler.TestShouldHandle(notification);

                    if (shouldHandle)
                    {
                        await handler.Handle(notification);
                    }
                });
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
