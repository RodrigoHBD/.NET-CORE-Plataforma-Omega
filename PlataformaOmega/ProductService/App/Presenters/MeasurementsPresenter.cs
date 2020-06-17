using ProductService.App.Models;
using ProductService.gRPC.Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.Presenters
{
    public class MeasurementsPresenter
    {
        public static GrpcProductMeasurements PresentPhysicalMeasurements(PhysicalProductMeasurements measurements)
        {
            try
            {
                return new GrpcProductMeasurements()
                {
                    Height = measurements.Height,
                    Length = measurements.Length,
                    Width = measurements.Width
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
