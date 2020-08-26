using Google.Protobuf.Collections;
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
        public static GrpcPackage PresentePackage(Package package)
        {
            try
            {
                var presented = new GrpcPackage()
                {
                    Id = package.Id.ToString(),
                    Name = package.Name,
                    WeightInGrams = package.WeightInGrams,
                    HeightInMm = package.Measurement.HeightInMm,
                    WidthInMm = package.Measurement.WidthInMm,
                    LengthInMm = package.Measurement.LengthInMm
                };
                package.Content.ProductIds.ForEach(id => presented.ContentIds.Add(id));
                return presented;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        

    }
}
