using Gateway.Controllers.Api.MercadoLivreModels.Input;
using Gateway.ServerGrid.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Gateway.Controllers.Api.MercadoLivre
{
    public class NotificationHandler
    {
        public static async Task HandleNotification(Notification notification)
        {
			try
			{
				await Collections.MLNotifications.InsertOneAsync(new MLNotification()
				{
					Resource = notification.resource,
					Topic = notification.topic,
					UserId = notification.user_id.ToString(),
					RecivedAt = notification.sent
				});
			}
			catch (Exception)
			{
				throw;
			}
        }
    }
}
