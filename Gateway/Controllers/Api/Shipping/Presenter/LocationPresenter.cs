using Gateway.Controllers.Common.Models;
using Gateway.gRPC.Client.ShippingClientProto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Controllers.Api.Shipping.Presenter
{
    public class LocationPresenter
    {
        public static Location Present(GrpcLocation location) =>
            new LocationPresenter(location).GetPresented();

        public Location GetPresented()
        {
            return new Location()
            {
                Cep = Location.Cep,
                City = Location.City,
                State = Location.State,
                StreetName = Location.StreetName,
                StreetNumber = Location.StreetNumber
            };
        }

        public LocationPresenter(GrpcLocation location) => Location = location;

        private GrpcLocation Location { get; }
    }
}
