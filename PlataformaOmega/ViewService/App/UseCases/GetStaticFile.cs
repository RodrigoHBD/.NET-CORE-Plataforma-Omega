using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViewService.App.UseCases
{
    public class GetStaticFile
    {
        public static async Task<string> Execute(string path)
        {
            try
            {
                var staticFileFolderPath = PathHelper.StaticFilesFolderPath;
                path = $"{staticFileFolderPath}\\{path}";
                return await FileReader.ReadFileAsStringAsync(path);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
