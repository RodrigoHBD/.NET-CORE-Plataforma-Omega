using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViewService.App.UseCases
{
    public class UseCaseOperator
    {
        public static async Task<string> GetViewAsync(string path)
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
