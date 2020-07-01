using ShippingService.gRPC.Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.TypeAdapters
{
    public class GrpcUpdatePackageAdapter
    {
        public static string GetId(GrpcUpdatePackageRequest request)
        {
            try
            {
                return request.Id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
