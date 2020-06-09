using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewService.gRPC.Server.Protos;

namespace ViewService.App
{
    public class Controller
    {
        public static async Task<GrpcViewAsString> GetViewAsync(GrpcGetViewRequest request)
        {
            try
            {
                
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
