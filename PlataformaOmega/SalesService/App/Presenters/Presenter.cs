using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using SalesService.gRPC.Server.Protos;

namespace SalesService.App.Presenters
{
    public class Presenter
    {
        public static GrpcStatusResponse PresentStatusResponse(bool status, string message = "")
        {
            try
            {
                return new GrpcStatusResponse()
                {
                    Ok = status,
                    Message = message
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
