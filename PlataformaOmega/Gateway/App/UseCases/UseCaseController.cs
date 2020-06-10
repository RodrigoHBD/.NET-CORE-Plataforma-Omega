using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.App.UseCases
{
    public class UseCaseController
    {
        public static async Task<string> GetHtmlAsync(string path)
        {
            try
            {
                return await GetView.Execute(path);
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
                return await GetStaticFile.Execute(path);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
