using Gateway.Controllers.Api.Shipping.Models.Output;
using Gateway.gRPC.Client.ShippingClientProto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Gateway.Controllers.Api.Shipping.Factories
{
    public class PackageListFactory
    {
        public static PackageList Make(GrpcPackageList data)
        {
            try
            {
                var list = new PackageList() 
                {
                    Pagination = PaginationFactory.Make(data.Pagination)
                };
                data.Data.ToList().ForEach(id => { list.Data.Add(PackageDataFactory.Make(id)); });
                return list;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static string MakeSerialized(GrpcPackageList data)
        {
            try
            {
                var list = Make(data);
                return JsonSerializer.Serialize(list);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
