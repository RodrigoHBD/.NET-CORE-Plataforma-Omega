using MercadoLivreLibrary.Models;
using MercadoLivreService.gRPC.Server.Protos;
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
                TotalAmount = json.total_amount,
                PackId = json.pack_id ?? default(long)
            };
        }
    }
}
