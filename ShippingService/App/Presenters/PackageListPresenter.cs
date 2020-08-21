using ShippingService.App.Models.Output;
using ShippingService.gRPC.Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Presenters
{
    public class PackageListPresenter
    {
        public static GrpcPackageList PresentPackageList(PackageList list)
        {
            var grpcList = new GrpcPackageList()
            {
                Pagination = new GrpcPagination()
                {
                    Limit = list.Pagination.Limit,
                    Offset = list.Pagination.Offset,
                    Total = list.Pagination.Total
                }
            };

            list.Data.ForEach(package => 
            {
                grpcList.Data.Add(PackagePresenter.PresentePackage(package));
            });

            return grpcList;
        }

    }
}
