using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViewService.App.UseCases
{
    public class GetView
    {
        public static async Task<string> Execute(string path)
        {
            try
            {
                var viewFolderPath = PathHelper.ViewsFolderPath;
                path = $"{viewFolderPath}\\{path}";
                return await FileReader.ReadFileAsStringAsync(path);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
