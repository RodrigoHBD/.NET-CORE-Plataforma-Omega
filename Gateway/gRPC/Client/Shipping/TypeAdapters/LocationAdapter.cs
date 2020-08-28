using Gateway.Controllers.Common.Models;
using Gateway.gRPC.Client.ShippingClientProto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.gRPC.Client.ShippingTypeAdapters
{
    public class LocationAdapter
    {
        public static GrpcLocation Adapt(Location location)
        {
            return new GrpcLocation()
            {
                Cep = location.Cep,
                City = location.City,
                State = location.State,
                StreetName = location.StreetName,
                StreetNumber = location.StreetNumber
            };
        }
    }
}
