using ShippingService.App.Models;
using ShippingService.gRPC.Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Presenters
{
    public class LocationPresenter
    {
        public static GrpcLocation PresentLocation(Location location)
        {
            return new GrpcLocation()
            {
                Cep = location.Cep,
                City = location.City,
                State = location.State,
                StreetName = location.StreetName
            };
        }
    }
}
