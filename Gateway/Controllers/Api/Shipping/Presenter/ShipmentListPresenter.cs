using Gateway.Controllers.Api.Shipping.Models;
using Gateway.Controllers.Common.Models;
using Gateway.gRPC.Client.ShippingClientProto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Gateway.Controllers.Api.Shipping.Presenter
{
    public class ShipmentListPresenter
    {
        public static ShipmentList GetFrom(GrpcShipmentList list) => 
            new ShipmentListPresenter(list).GetPresented();

        public static string GetSerializedFrom(GrpcShipmentList list) => 
            JsonSerializer.Serialize(GetFrom(list));

        public ShipmentList GetPresented()
        {
            return new ShipmentList()
            {
                Data = GetData(),
                Pagination = GetPagination()
            };
        }

        public ShipmentListPresenter(GrpcShipmentList list) => List = list;
  
        private GrpcShipmentList List { get; }

        private List<Shipment> GetData()
        {
            var list = new List<Shipment>();
            List.Data.ToList().ForEach(shipment =>
            {
                list.Add(ShipmentPresenter.Present(shipment));
            });
            return list;
        }

        private PaginationOut GetPagination()
        {
            return PaginationPresenter.PresentFrom(List.Pagination);
        }
    }
}
