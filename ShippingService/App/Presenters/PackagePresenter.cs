using ShippingService.App.Models;
using ShippingService.gRPC.Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Presenters
{
    public class PackagePresenter
    {
        public static GrpcPackageData PresentePackage(Package package)
        {
            try
            {
                return new GrpcPackageData()
                {

                };
            }
            catch (Exception e)
            {
                throw;
            }
        }

        

    }
}
