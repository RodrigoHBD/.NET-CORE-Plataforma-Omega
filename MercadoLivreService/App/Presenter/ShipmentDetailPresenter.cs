using MercadoLivreService.gRPC.Server.Protos;
using MercadoLivreService.MercadoLivre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Presenter
{
    public class ShipmentDetailPresenter
    {
        public static GrpcShipmentDetail Present(ShipmentJson json)
        {
            return new GrpcShipmentDetail()
            {
                TrackingCode = json.tracking_number,
                OrderId = json.order_id
            };
        }
    }
}
