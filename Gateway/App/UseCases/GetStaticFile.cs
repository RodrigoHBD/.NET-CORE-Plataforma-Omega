using Gateway.App.Boundries.SCI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.App.UseCases
{
    public class GetStaticFile
    {
        public static async Task<string> Execute(string path)
        {
            try
            {
                return await ViewSCI.GetStaticFileAsync(path);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
