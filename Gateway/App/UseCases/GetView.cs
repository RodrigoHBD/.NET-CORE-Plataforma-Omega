using Gateway.App.Boundries.SCI;
using Gateway.gRPC.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.App.UseCases
{
    public class GetView
    {
        public static async Task<string> Execute(string path)
        {
            try
            {
                return await ViewSCI.GetViewAsync(path);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
