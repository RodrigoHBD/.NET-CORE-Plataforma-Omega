using Gateway.App.Boundries.SCI.ViewFactories;
using Gateway.gRPC.Client;
using Gateway.gRPC.Client.ViewClientProtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.App.Boundries.SCI
{
    public class ViewSCI
    {
        public static async Task<string> GetViewAsync(string path)
        {
            try
            {
                var request = GrpcGetViewRequestFactory.Make(path);
                var response = await ViewClient.GetViewAsync(request);
                return response.Data;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task<string> GetStaticFileAsync(string path)
        {
            try
            {
                var request = GrpcGetStaticFileRequestFactory.Make(path);
                var response = await ViewClient.GetStaticFileAsync(request);
                return response.Data;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
