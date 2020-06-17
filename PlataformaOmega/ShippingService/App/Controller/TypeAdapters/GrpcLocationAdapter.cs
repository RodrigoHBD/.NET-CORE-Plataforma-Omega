using ShippingService.App.Models;
using ShippingService.gRPC.Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Controller.TypeAdapters
{
    public class GrpcLocationAdapter
    {
        public static Location Adapt(GrpcLocation grpcLocation)
        {
            return new Location()
            {
                Cep = grpcLocation.Cep,
                City = grpcLocation.City,
                State = grpcLocation.State,
                StreetName = grpcLocation.StreetName,
                StreetNumber = grpcLocation.StreetNumber
            };
        }
    }
}
