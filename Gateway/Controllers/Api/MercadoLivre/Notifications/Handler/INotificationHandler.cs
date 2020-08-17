using Gateway.Controllers.Api.MercadoLivreModels.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Controllers.Api.MercadoLivre.Notifications
{
    public interface INotificationHandler
    {
        bool TestShouldHandle(Notification notification);
        Task Handle(Notification notification);
    }
}
