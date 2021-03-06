﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using SalesService.App.Controller;
using SalesService.gRPC.Server.Protos;

namespace SalesService.gRPC.Server.Services
{
    public class SalesServiceImplementation : GrpcSaleService.GrpcSaleServiceBase
    {
        public override async Task<GrpcStatusResponse> RegisterSale(GrpcRegisteSaleRequest request, ServerCallContext context)
        {
            try
            {
                return await Controller.RegisterNewSale(request);
            }
            catch (Exception e)
            {
                throw HandleException(e);
            }
        }

        public override async Task<GrpcSale> GetSaleByMarketplaceId(GrpcStringMessage request, ServerCallContext context)
        {
            try
            {
                return await Controller.GetSaleByMarketplaceId(request);
            }
            catch (Exception e)
            {
                throw HandleException(e);
            }
        }

        public static RpcException HandleException(Exception e)
        {
            return new RpcException(new Status(StatusCode.Internal, e.Message));
        }
    }
}
