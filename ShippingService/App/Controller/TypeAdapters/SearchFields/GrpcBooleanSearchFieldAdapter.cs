using ShippingService.App.Controller.Implementations;
using ShippingService.App.Models.Input.SearchDataFields;
using ShippingService.gRPC.Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.TypeAdapters
{
    public class GrpcBooleanSearchFieldAdapter
    {
        public static IBooleanSearchField Adapt(GrpcBooleanSearchField grpcModel)
        {
            try
            {
                return new BooleanSearchField()
                {
                    IsActive = grpcModel.IsActive,
                    Value = grpcModel.Value
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
