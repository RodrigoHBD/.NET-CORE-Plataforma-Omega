using ShippingService.App.Controller.Implementations;
using ShippingService.App.Controller.TypeAdapters;
using ShippingService.App.Models.Input;
using ShippingService.App.Models.Input.SearchDataFields;
using ShippingService.gRPC.Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.TypeAdapters
{
    public class GrpcSearchPackageReqAdapter
    {
        public static IPackageSearchRequest Adapt(GrpcSearchPackageRequest grpcRequest)
        {
            try
            {
                var request = new PackageSearchRequest() 
                {
                    Name = new StringSearchField() { Value = grpcRequest.Name },
                    TrackingCode = new StringSearchField() { Value = grpcRequest.TrackingCode },
                    DynamicString = new StringSearchField() { Value =grpcRequest.DynamicField },
                    AwaitingForPickUp = GrpcBooleanSearchFieldAdapter.Adapt(grpcRequest.AwaitingForPickUp),
                    BeingTransported = GrpcBooleanSearchFieldAdapter.Adapt(grpcRequest.BeingTransported),
                    Delivered = GrpcBooleanSearchFieldAdapter.Adapt(grpcRequest.Delivered),
                    Rejected = GrpcBooleanSearchFieldAdapter.Adapt(grpcRequest.Rejected),
                    Pagination = GrpcPaginationAdapter.Adapt(grpcRequest.Pagination)
                };

                if(grpcRequest.DynamicField.Length > 0)
                {
                    request.DynamicString.IsActive = true;
                }

                return request;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }

    
}
