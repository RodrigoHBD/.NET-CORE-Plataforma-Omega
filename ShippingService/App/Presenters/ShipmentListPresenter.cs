using ShippingService.App.Models.Output;
using ShippingService.gRPC.Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Presenters
{
    public class ShipmentListPresenter
    {
        public static GrpcShipmentList Present(ShipmentList list) => 
            new ShipmentListPresenter(list).GetPresented();

        public GrpcShipmentList GetPresented()
        {
            SetData();
            SetPagination();
            SetSorting();
            return Presented;
        }

        public ShipmentListPresenter(ShipmentList list)
        {
            List = list;
        }

        private ShipmentList List { get; }

        private GrpcShipmentList Presented { get; set; } = new GrpcShipmentList();

        private void SetData()
        {
            List.Data.ForEach(shipment => 
            {
                Presented.Data.Add(ShipmentPresenter.Present(shipment));
            });
        }

        private void SetPagination()
        {
            Presented.Pagination = PaginationPresenter.Present(List.Pagination);
        }

        private void SetSorting()
        {
            Presented.Sorting = "nao implementado";
        }
    }
}
