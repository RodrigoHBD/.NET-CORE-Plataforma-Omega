using Gateway.Controllers.Api.Shipping.Models.Output;
using Gateway.gRPC.Client.ShippingClientProto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Controllers.Api.Shipping.Factories
{
    public class LocationFactory
    {
        public static Location Make(GrpcLocation data)
        {
            return new Location()
            {
                Cep = data.Cep,
                City = data.City,
                State = data.State,
                StreetName = data.StreetName,
                StreetNumber = data.StreetNumber
            };
        }
    }
}
