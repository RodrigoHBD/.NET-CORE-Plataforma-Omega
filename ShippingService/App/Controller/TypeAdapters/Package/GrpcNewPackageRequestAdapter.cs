using ShippingService.App.Models.Input;
using ShippingService.gRPC.Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Controller.TypeAdapters
{
    public class GrpcNewPackageRequestAdapter
    {
        public static NewPackageRequest GetAdapted(GrpcNewPackageRequest req) =>
            new GrpcNewPackageRequestAdapter(req).GetAdapted();

        public NewPackageRequest GetAdapted()
        {
            return new NewPackageRequest()
            {
                Name = GetName(),
                HeightInMm = GetHeight(),
                WidthInMm = GetWidth(),
                LengthInMm = GetLength(),
                WeightInGrams = GetWeight(),
                ContentIds = GetContentIds()
            };
        }

        public GrpcNewPackageRequestAdapter(GrpcNewPackageRequest req) => Request = req;

        private GrpcNewPackageRequest Request { get; }

        private string GetName() => Request.Name;

        private int GetHeight() => Request.HeightInMm;

        private int GetWidth() => Request.WidthInMm;

        private int GetLength() => Request.LengthInMm;

        private int GetWeight() => Request.WeightInGrams;

        private List<string> GetContentIds() => Request.ContentIds.ToList();
    }
}
