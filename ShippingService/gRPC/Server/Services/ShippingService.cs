using Grpc.Core;
using ShippingService.App.Controller;
using ShippingService.gRPC.Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.gRPC.Server.Services
{
    public class ShippingServiceImplementation : Shipping.ShippingBase
    {
        public override async Task<GrpcVoid> CreateNewShipment(GrpcNewShipmentRequest request, ServerCallContext context)
        {
            try
            {
                return await Controller.CreateNewShipment(request);
            }
            catch (Exception e)
            {
                throw HandleException(e);
            }
        }

        public override async Task<GrpcShipment> GetShipmentById(GrpcString request, ServerCallContext context)
        {
            try
            {
                return await Controller.GetShipmentById(request);
            }
            catch (Exception e)
            {
                throw HandleException(e);
            }
        }

        public override async Task<GrpcShipmentEvents> GetShipmentEvents(GrpcString request, ServerCallContext context)
        {
            try
            {
                return await Controller.GetShipmentEvents(request);
            }
            catch (Exception e)
            {
                throw HandleException(e);
            }
        }

        public override async Task<GrpcVoid> SetShipmentAutoUpdate(GrpcSetAutoUpdateRequest request, ServerCallContext context)
        {
            try
            {
                return await Controller.SetShipmentAutoUpdate(request);
            }
            catch (Exception e)
            {
                throw HandleException(e);
            }
        }

        public override async Task<GrpcShipmentList> SearchShipments(GrpcShipmentSearchRequest request, ServerCallContext context)
        {

            try
            {
                return await Controller.SearchShipments(request);
            }
            catch (Exception e)
            {
                throw HandleException(e);
            }
        }

        public override async Task<GrpcPackage> GetPackageById(GrpcString request, ServerCallContext context)
        {
            try
            {
                return await Controller.GetPackageById(request);
            }
            catch (Exception e)
            {
                throw HandleException(e);
            }
        }

       
        public override async Task<GrpcVoid> RunAutoUpdate(GrpcVoid request, ServerCallContext context)
        {
            try
            {
                return await Controller.RunAutoUpdate();
            }
            catch (Exception e)
            {
                throw HandleException(e);
            }
        }

        public override async Task<GrpcVoid> RunAutoUpdateById(GrpcString request, ServerCallContext context)
        {
            try
            {
                return await Controller.RunAutoUpdateById(request);
            }
            catch (Exception e)
            {
                throw HandleException(e);
            }
        }

        public override async Task<GrpcBoolean> GetIsMarketplaceSaleIdRegistered(GrpcString request, ServerCallContext context)
        {
            try
            {
                return await Controller.GetIsMarketplaceSaleIdRegistered(request);
            }
            catch (Exception e)
            {
                throw HandleException(e);
            }
        }

        public override async Task<GrpcVoid> DeleteShipment(GrpcString request, ServerCallContext context)
        {
            try
            {
                return await Controller.DeleteShipment(request);
            }
            catch (Exception e)
            {
                throw HandleException(e);
            }
        }

        public static RpcException HandleException(Exception exception)
        {
            Console.WriteLine($"--> EXCEPTION MESSAGE : {exception.Message}");
            Console.WriteLine($"--> EXCEPTION STACK TRACE : {exception.StackTrace}");
            return new RpcException(new Status(StatusCode.Unknown, exception.Message));
        }

    }
}
