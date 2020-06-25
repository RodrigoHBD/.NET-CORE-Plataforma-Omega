using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShippingService.App.Controller.TypeAdapters;
using ShippingService.App.Models;
using ShippingService.App.Models.Input;
using ShippingService.gRPC.Server.Protos;

namespace ShippingService.App.TypeAdapters
{
    public class ShipNewPackageRequestAdapter
    {
        public static IShipPackageRequest AdaptFromGrpc(GrpcShipPackageRequest grpcRequest)
        {
            try
            {
                var request = new ShipPackageRequest()
                {
                    SaleId = grpcRequest.SaleId,
                    Name = grpcRequest.Name,
                    TrackingCode = grpcRequest.TrackingCode,
                    Weight = grpcRequest.Weight,
                    Platform = DeterminePlatform(grpcRequest),
                    CreatedManually = grpcRequest.CreatedManually,
                    SetWatcher = grpcRequest.SetWatcher,
                    PackageInitialLocation = GrpcLocationAdapter.Adapt(grpcRequest.InitialLocation)
                };
                grpcRequest.Content.ToList().ForEach(product => { request.Content.Add(product); });
                return request;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static AvailablePlatformsToBind DeterminePlatform(GrpcShipPackageRequest grpcRequest)
        {
            try
            {
                var platform = grpcRequest.Platform;

                if (platform == 0)
                {
                    return AvailablePlatformsToBind.MercadoLivre;
                }
                else if (platform == 1)
                {
                    return AvailablePlatformsToBind.B2W;
                }
                else
                {
                    return AvailablePlatformsToBind.None;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }

    public class ShipPackageRequest : IShipPackageRequest
    {
        public string Name { get; set; } = "";
        public string TrackingCode { get; set; } = "";
        public bool SetWatcher { get; set; } = false;
        public Location PackageInitialLocation { get; set; } = new Location();
        public string SaleId { get; set; } = "";
        public double Weight { get; set; } 
        public AvailablePlatformsToBind Platform { get; set; }
        public List<string> Content { get; set; } = new List<string>();
        public bool CreatedManually { get; set; } = false;
    }
}
