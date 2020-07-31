using MercadoLivreService.gRPC.Server.Protos;
using MercadoLivreService.MercadoLivreModels.Out;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Presenter
{
    public class OrderDetailPresenter
    {
        public static GrpcOrder Present(OrderDetailJson json)
        {
            return new GrpcOrder()
            {
                Id = json.id,
                ShippingId = json.shipping.id,
                ShippingStatus = json.shipping.substatus,
                Status = json.status,
                TotalAmount = json.total_amount
            };
        }
    }
}
